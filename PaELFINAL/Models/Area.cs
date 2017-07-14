using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaELFINAL.Models
{
    public class Area
    {
        [Key]
        public string cod_area { get; set; }
        public string cod_nombre { get; set; }
    }
}