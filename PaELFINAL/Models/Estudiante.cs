using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class Estudiante
    {
        [Key]
        public string EstudianteID { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public int trimestres_cursados { get; set; }
        public float indice { get; set; }
        public int creditos_aprobados { get; set; }
        public int materias_aprobadas { get; set; }

        public ICollection<Seccion> Secciones { get; set; }
    }
}