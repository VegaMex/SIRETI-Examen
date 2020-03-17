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
    public class DAOUsuario
    {
        public INewConnection connection;

        public DAOUsuario(INewConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Usuario usuario)
        {
            var sqlCommand = "INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario)" +
                "VALUES (@nombre_usuario, @paterno_usuario, @materno_usuario, @correo_usuario, SHA1(@contra_usuario), @carrera_usuario, @tipo_usuario)";
            var columns = new string[]
            {
                "nombre_usuario",
                "paterno_usuario",
                "materno_usuario",
                "correo_usuario",
                "contra_usuario",
                "carrera_usuario",
                "tipo_usuario"
            };
            var keys = new object[]
            {
                usuario.NombreUsuario,
                usuario.PaternoUsuario,
                usuario.MaternoUsuario,
                usuario.CorreoUsuario,
                usuario.ContraUsuario,
                usuario.CarreraUsuario,
                usuario.TipoUsuario
            };

            IConnection localConnection = connection.Create();
            localConnection.Execute(sqlCommand, columns, keys);
        }

        public Usuario Login(string email, string password)
        {
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT * FROM usuarios WHERE correo_usuario = @correo_usuario && contra_usuario = @contra_usuario", new string[] { "correo_usuario", "contra_usuario" }, new string[] { email, password });

            Usuario usuario = null;

            foreach (DataRow row in data.Rows)
            {
                usuario = new Usuario
                {
                    IdUsuario = (int)row.ItemArray[0],
                    NombreUsuario = (string)row.ItemArray[1],
                    PaternoUsuario = (string)row.ItemArray[2],
                    MaternoUsuario = (string)row.ItemArray[3],
                    CorreoUsuario = (string)row.ItemArray[4],
                    ContraUsuario = (string)row.ItemArray[5],
                    CarreraUsuario = (int)row.ItemArray[6],
                    TipoUsuario = (int)row.ItemArray[7]
                };
            }

            return usuario;
        }
    }
}
