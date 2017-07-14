using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class TipodeContrato
    {
        [Key]
        public byte TipodeContratoId { get; set; }
        public string Name { get; set; }

        public ICollection<Profesor> Profesores { get; set; }
    }
}