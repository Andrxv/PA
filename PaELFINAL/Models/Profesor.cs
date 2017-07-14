using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class Profesor
    {
        [Key]
        public int ProfesorID { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Apellido { get; set; }
        
        public ICollection<Asignatura> asignaturas { get; set; }
        public ICollection<Seccion> secciones { get; set; }

        public byte TipodeContratoId { get; set; }
        [ForeignKey("TipodeContratoId")]
        public TipodeContrato jornada { get; set; }
    }
}