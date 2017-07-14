using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class Seccion
    {
        [Key]
        public int seccionID { get; set; }
        public string Horario { get; set; }
        public string Dias { get; set; }
        public string Aula { get; set; }

        public int asignaturaID { get; set; }
        [ForeignKey("asignaturaID")]
        public Asignatura Asignatura { get; set; }

        public string cod_area { get; set; }
        [ForeignKey("cod_area")]
        public Area area { get; set; }
    }
}