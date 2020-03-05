using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomiPro.ModelDB;

namespace NomiPro.Controllers
{
    public class EMPLEADOSController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: EMPLEADOS
        public ActionResult Index()
        {
            var eMPLEADOS = db.EMPLEADOS.Include(e => e.CARGOS).Include(e => e.HORARIO).Include(e => e.TIPO_VINCULACION);
            return View(eMPLEADOS.ToList());
        }

        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cargos = new SelectList(db.CARGOS, "ID_Cargos", "Nombre");
            ViewBag.ID_Horario = new SelectList(db.HORARIO, "ID_Horario", "Tipo_Horario");
            ViewBag.ID_Vinculacion = new SelectList(db.TIPO_VINCULACION, "ID_Vinculacion", "Descripcion");
            return View();
        }

        // POST: EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Emple,Nombre,Apellido,Correo,Telefono,Tipo_Documento,Numero_Documento,ID_Cargos,ID_Vinculacion,ID_Horario,Estado")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cargos = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", eMPLEADOS.ID_Cargos);
            ViewBag.ID_Horario = new SelectList(db.HORARIO, "ID_Horario", "Tipo_Horario", eMPLEADOS.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.TIPO_VINCULACION, "ID_Vinculacion", "Descripcion", eMPLEADOS.ID_Vinculacion);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cargos = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", eMPLEADOS.ID_Cargos);
            ViewBag.ID_Horario = new SelectList(db.HORARIO, "ID_Horario", "Tipo_Horario", eMPLEADOS.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.TIPO_VINCULACION, "ID_Vinculacion", "Descripcion", eMPLEADOS.ID_Vinculacion);
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Emple,Nombre,Apellido,Correo,Telefono,Tipo_Documento,Numero_Documento,ID_Cargos,ID_Vinculacion,ID_Horario,Estado")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cargos = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", eMPLEADOS.ID_Cargos);
            ViewBag.ID_Horario = new SelectList(db.HORARIO, "ID_Horario", "Tipo_Horario", eMPLEADOS.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.TIPO_VINCULACION, "ID_Vinculacion", "Descripcion", eMPLEADOS.ID_Vinculacion);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            db.EMPLEADOS.Remove(eMPLEADOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
