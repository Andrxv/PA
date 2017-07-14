using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class Asignatura
    {
        [Key]
        public int asignaturaID { get; set; }
        public string NombreAsignatura { get; set; }
        public int creditos { get; set; }
        
        public ICollection<Profesor> Profesores { get; set; }
        public ICollection<Seccion> Secciones { get; set; }

        public int asigID { get; set; }
        [ForeignKey("asigID")]
        public Asignatura prerequisito { get; set; }

        public string cod_area { get; set; }
        [ForeignKey("cod_area")]
        public Area area { get; set; }
    }
}