using PaELFINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PaELFINAL.ViewModel;

namespace PaELFINAL.Controllers
{
    public class SeccionsController : Controller
    {
        private ApplicationDbContext _db;

        public SeccionsController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        public ActionResult Index()
        {
            var Seccionvm = _db.Seccions.Include(c => c.Asignatura).ToList();

            return View(Seccionvm);
        }

        public ActionResult Details(int id)
        {
            var seccion = _db.Seccions.SingleOrDefault(m => m.asignaturaID == id);

            if (seccion == null)
                return HttpNotFound();

            return View(seccion);
        }
        [Route("Seccion/SeccionForm")]
        public ActionResult New()
        {
            var Asignaturas = _db.Asignatura.ToList();
            var viewModel = new SeccionViewModel
            {
                asignatura = Asignaturas
            };


            return View("SeccionForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Seccion seccion)
        {
            _db.Seccions.Add(seccion);
            _db.SaveChanges();

            return RedirectToAction("Index", "Seccion");
        }
    }
}
