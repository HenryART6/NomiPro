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
    public class CONTROL_PAGOController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: CONTROL_PAGO
        public ActionResult Index()
        {
            var cONTROL_PAGO = db.CONTROL_PAGO.Include(c => c.EMPLEADOS);
            return View(cONTROL_PAGO.ToList());
        }

        // GET: CONTROL_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTROL_PAGO cONTROL_PAGO = db.CONTROL_PAGO.Find(id);
            if (cONTROL_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(cONTROL_PAGO);
        }

        // GET: CONTROL_PAGO/Create
        public ActionResult Create()
        {
            ViewBag.ID_EmpleCP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre");
            return View();
        }

        // POST: CONTROL_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Control_Pago,ID_EmpleCP,Valor_Horas_Extra,Valor_Parafiscal,Mes")] CONTROL_PAGO cONTROL_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.CONTROL_PAGO.Add(cONTROL_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EmpleCP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", cONTROL_PAGO.ID_EmpleCP);
            return View(cONTROL_PAGO);
        }

        // GET: CONTROL_PAGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTROL_PAGO cONTROL_PAGO = db.CONTROL_PAGO.Find(id);
            if (cONTROL_PAGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EmpleCP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", cONTROL_PAGO.ID_EmpleCP);
            return View(cONTROL_PAGO);
        }

        // POST: CONTROL_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Control_Pago,ID_EmpleCP,Valor_Horas_Extra,Valor_Parafiscal,Mes")] CONTROL_PAGO cONTROL_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTROL_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EmpleCP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", cONTROL_PAGO.ID_EmpleCP);
            return View(cONTROL_PAGO);
        }

        // GET: CONTROL_PAGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTROL_PAGO cONTROL_PAGO = db.CONTROL_PAGO.Find(id);
            if (cONTROL_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(cONTROL_PAGO);
        }

        // POST: CONTROL_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTROL_PAGO cONTROL_PAGO = db.CONTROL_PAGO.Find(id);
            db.CONTROL_PAGO.Remove(cONTROL_PAGO);
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
