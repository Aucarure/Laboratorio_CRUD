using aplicacion_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aplicacion_01.Controllers
{
    public class AlumnoController : Controller
    {
        private List<AlumnoModel> ObtenerAlumnos()
        {
            if (Session["alumnos"] == null)
            {
                Session["alumnos"] = new List<AlumnoModel>
                {
                    new AlumnoModel { Id = 1, Nombres = "Carlos", Apellidos = "Ramírez Soto",   Edad = 20, Correo = "carlos.ramirez@tecsup.edu.pe" },
                    new AlumnoModel { Id = 2, Nombres = "María",  Apellidos = "López Huamán",   Edad = 19, Correo = "maria.lopez@tecsup.edu.pe" },
                    new AlumnoModel { Id = 3, Nombres = "Jorge",  Apellidos = "Quispe Mendoza", Edad = 22, Correo = "jorge.quispe@tecsup.edu.pe" }
                };
            }
            return (List<AlumnoModel>)Session["alumnos"];
        }

        private AlumnoModel BuscarAlumno(int id)
        {
            return ObtenerAlumnos().FirstOrDefault(x => x.Id == id);
        }

        // GET: Alumno
        public ActionResult Index()
        {
            return View(ObtenerAlumnos());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            var alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlumnoModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var alumnos = ObtenerAlumnos();
            model.Id = alumnos.Any() ? alumnos.Max(x => x.Id) + 1 : 1;
            alumnos.Add(model);
            return RedirectToAction("Index");
        }

        // GET: Alumno/Edit
        public ActionResult Edit(int id)
        {
            var alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();
            return View(alumno);
        }

        // POST: Alumno/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlumnoModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var alumno = BuscarAlumno(model.Id);
            if (alumno == null) return HttpNotFound();

            alumno.Nombres = model.Nombres;
            alumno.Apellidos = model.Apellidos;
            alumno.Edad = model.Edad;
            alumno.Correo = model.Correo;
            return RedirectToAction("Index");
        }

        // GET: Alumno/Delete
        public ActionResult Delete(int id)
        {
            var alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();
            return View(alumno);
        }

        // POST: Alumno/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var alumno = BuscarAlumno(id);
            if (alumno != null) ObtenerAlumnos().Remove(alumno);
            return RedirectToAction("Index");
        }
    }
}
