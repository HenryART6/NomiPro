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
    public class TIPO_VINCULACIONController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: TIPO_VINCULACION
        public ActionResult Index()
        {
            return View(db.TIPO_VINCULACION.ToList());
        }

        // GET: TIPO_VINCULACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VINCULACION tIPO_VINCULACION = db.TIPO_VINCULACION.Find(id);
            if (tIPO_VINCULACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VINCULACION);
        }

        // GET: TIPO_VINCULACION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_VINCULACION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Vinculacion,Descripcion,Estado")] TIPO_VINCULACION tIPO_VINCULACION)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_VINCULACION.Add(tIPO_VINCULACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_VINCULACION);
        }

        // GET: TIPO_VINCULACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VINCULACION tIPO_VINCULACION = db.TIPO_VINCULACION.Find(id);
            if (tIPO_VINCULACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VINCULACION);
        }

        // POST: TIPO_VINCULACION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Vinculacion,Descripcion,Estado")] TIPO_VINCULACION tIPO_VINCULACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_VINCULACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_VINCULACION);
        }

        // GET: TIPO_VINCULACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VINCULACION tIPO_VINCULACION = db.TIPO_VINCULACION.Find(id);
            if (tIPO_VINCULACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VINCULACION);
        }

        // POST: TIPO_VINCULACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_VINCULACION tIPO_VINCULACION = db.TIPO_VINCULACION.Find(id);
            db.TIPO_VINCULACION.Remove(tIPO_VINCULACION);
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
