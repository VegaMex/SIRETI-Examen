using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Connections;
using Backend.Models;

namespace Backend.DAOS
{
    public class DAOAlumno
    {
        public INewConnection connection;

        public DAOAlumno(INewConnection connection)
        {
            this.connection = connection;
        }

        public bool Insert(Alumno alumno)
        {
            try
            {
                var sqlCommand = "INSERT INTO alumnos (control_alumno, nombre_alumno, paterno_alumno, materno_alumno, correo_alumno, contra_alumno, carrera_alumno, tipo_alumno) " +
                "VALUES (@control_alumno, @nombre_alumno, @paterno_alumno, @materno_alumno, @correo_alumno, SHA1(@contra_alumno), @carrera_alumno, @tipo_alumno)";
                var columns = new string[]
                {
                "control_alumno",
                "nombre_alumno",
                "paterno_alumno",
                "materno_alumno",
                "correo_alumno",
                "contra_alumno",
                "carrera_alumno",
                "tipo_alumno"
                };
                var keys = new object[]
                {
                alumno.ControlAlumno,
                alumno.NombreAlumno,
                alumno.PaternoAlumno,
                alumno.MaternoAlumno,
                alumno.CorreoAlumno,
                alumno.ContraAlumno,
                alumno.CarreraAlumno,
                alumno.TipoAlumno
                };

                IConnection localConnection = connection.Create();
                localConnection.Execute(sqlCommand, columns, keys);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Alumno Login(string email, string password)
        {
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT * FROM alumnos WHERE correo_alumno = @correo_alumno && contra_alumno = @contra_alumno", new string[] { "correo_alumno", "contra_alumno" }, new string[] { email, password });

            Alumno alumno = null;

            foreach (DataRow row in data.Rows)
            {
                alumno = new Alumno
                {
                    IdAlumno = (int)row.ItemArray[0],
                    ControlAlumno = (string)row.ItemArray[1],
                    NombreAlumno = (string)row.ItemArray[2],
                    PaternoAlumno = (string)row.ItemArray[3],
                    MaternoAlumno = (string)row.ItemArray[4],
                    CorreoAlumno = (string)row.ItemArray[5],
                    ContraAlumno = (string)row.ItemArray[6],
                    CarreraAlumno = (int)row.ItemArray[7],
                    TipoAlumno = (int)row.ItemArray[8]
                };
            }

            return alumno;
        }
    }
}
