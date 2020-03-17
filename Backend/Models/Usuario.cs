using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string PaternoUsuario { get; set; }
        public string MaternoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string ContraUsuario { get; set; }
        public int CarreraUsuario { get; set; }
        public int TipoUsuario { get; set; }
    }
}
