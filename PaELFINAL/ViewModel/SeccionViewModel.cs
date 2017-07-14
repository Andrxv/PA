using PaELFINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaELFINAL.ViewModel
{
    public class SeccionViewModel
    {
        internal List<Area> area;

        public Seccion seccion { get; set; }

        public ICollection<Profesor> profesores { get; set; }

        public ICollection<Asignatura> asignatura { get; set; }
    }
}