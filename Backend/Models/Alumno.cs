using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string ControlAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string PaternoAlumno { get; set; }
        public string MaternoAlumno { get; set; }
        public string CorreoAlumno { get; set; }
        public string ContraAlumno { get; set; }
        public int CarreraAlumno { get; set; }
        public int TipoAlumno { get; set; }
    }
}
