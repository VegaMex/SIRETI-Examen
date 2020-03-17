using System;
using System.Collections.Generic;
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
    }
}
