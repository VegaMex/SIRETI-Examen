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

        public bool Insert(Usuario usuario)
        {
            try
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

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var sqlCommand = "DELETE FROM usuarios WHERE id_usuario = @id_usuario LIMIT 1";
                var columns = new string[] { "id_usuario" };
                var keys = new string[] { id };

                IConnection localConnection = connection.Create();
                localConnection.Execute(sqlCommand, columns, keys);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Usuario GetOne(string id)
        {
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT * FROM usuarios WHERE id_usuario = @id_usuario", new string[] { "id_usuario" }, new string[] { id });

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
        public bool NewPassword(string newPassword, string id)
        {
            try
            {
                var sqlCommand = "UPDATE usuarios SET contra_usuario = SHA1(@contra_usuario) WHERE id_usuario = @id_usuario LIMIT 1";
                var columns = new string[] { "contra_usuario", "id_usuario" };
                var keys = new string[] { newPassword, id };

                IConnection localConnection = connection.Create();
                localConnection.Execute(sqlCommand, columns, keys);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAll(Usuario usuario)
        {
            try
            {
                var sqlCommand = "UPDATE usuarios SET nombre_usuario = @nombre_usuario, paterno_usuario = @paterno_usuario, materno_usuario = @materno_usuario, correo_usuario = @correo_usuario, carrera_usuario = @carrera_usuario, tipo_usuario = @tipo_usuario WHERE id_usuario = @id_usuario LIMIT 1;";
                var columns = new string[]
                {
                    "id_usuario",
                    "nombre_usuario",
                    "paterno_usuario",
                    "materno_usuario",
                    "correo_usuario",
                    "carrera_usuario",
                    "tipo_usuario"
                };
                var keys = new string[]
                {
                    usuario.IdUsuario.ToString(),
                    usuario.NombreUsuario,
                    usuario.PaternoUsuario,
                    usuario.MaternoUsuario,
                    usuario.CorreoUsuario,
                    usuario.CarreraUsuario.ToString(),
                    usuario.TipoUsuario.ToString()
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

        public bool UpdatePartial(Usuario usuario)
        {
            try
            {
                var sqlCommand = "UPDATE usuarios SET nombre_usuario = @nombre_usuario, paterno_usuario = @paterno_usuario, materno_usuario = @materno_usuario, correo_usuario = @correo_usuario WHERE id_usuario = @id_usuario LIMIT 1";
                var columns = new string[]
                {
                    "id_usuario",
                    "nombre_usuario",
                    "paterno_usuario",
                    "materno_usuario",
                    "correo_usuario"
                };
                var keys = new string[]
                {
                    usuario.IdUsuario.ToString(),
                    usuario.NombreUsuario,
                    usuario.PaternoUsuario,
                    usuario.MaternoUsuario,
                    usuario.CorreoUsuario
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

        public List<Usuario> GetAllUsuarios()
        {
            var list = new List<Usuario>();
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT * FROM usuarios WHERE id_usuario != 1", new string[0], new string [0]);

            Usuario usuario;

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
                    TipoUsuario = (int)row.ItemArray[7],
                    NombreCompletoUsuario = string.Format("{0} {1} {2}", (string)row.ItemArray[1], (string)row.ItemArray[2], (string)row.ItemArray[3]),
                    CarreraUsuarioString = GetText(0, (int)row.ItemArray[6]),
                    TipoUsuarioString = GetText(1, (int)row.ItemArray[7])
                };
                list.Add(usuario);
            }

            return list;
        }

        public List<Usuario> GetAllDocentes(string carrera)
        {
            var list = new List<Usuario>();
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT * FROM usuarios WHERE id_usuario != 1 && tipo_usuario = 4 && carrera_usuario = @carrera_usuario", new string[] { "carrera_usuario" }, new string[] { carrera });

            Usuario usuario;

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
                    TipoUsuario = (int)row.ItemArray[7],
                    NombreCompletoUsuario = string.Format("{0} {1} {2}", (string)row.ItemArray[1], (string)row.ItemArray[2], (string)row.ItemArray[3]),
                    CarreraUsuarioString = GetText(0, (int)row.ItemArray[6]),
                    TipoUsuarioString = GetText(1, (int)row.ItemArray[7])
                };
                list.Add(usuario);
            }

            return list;
        }

        public static string GetText(int key, int value)
        {
            switch (key)
            {
                case 0: //Carrera
                    switch (value) 
                    {
                        case 2:
                            return "Ing. Sistemas Computacionales";
                        case 3:
                            return "Ing. Informática";
                        case 4:
                            return "Ing. Electrónica";
                        case 5:
                            return "Ing. Sistemas Automotrices";
                        case 6:
                            return "Ing. Ambiental";
                        case 7:
                            return "Ing. Industrial";
                        case 8:
                            return "Ing. Gestión Empresarial";
                        case 9:
                            return "Lic. Gastronomía";
                        default:
                            return "Desconocida";
                    }
                case 1: //Tipo
                    switch (value)
                    {
                        case 0:
                            return "Admin";
                        case 1:
                            return "Alumno";
                        case 2:
                            return "Coordinador";
                        case 3:
                            return "Encargado";
                        case 4:
                            return "Docente";
                    }
                    break;
            }
            return "";
        }
    }
}
