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
    public class HORARIOsController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: HORARIOs
        public ActionResult Index()
        {
            return View(db.HORARIO.ToList());
        }

        // GET: HORARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // GET: HORARIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HORARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Horario,Tipo_Horario,Hora_Trabajo")] HORARIO hORARIO)
        {
            if (ModelState.IsValid)
            {
                db.HORARIO.Add(hORARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hORARIO);
        }

        // GET: HORARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // POST: HORARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Horario,Tipo_Horario,Hora_Trabajo")] HORARIO hORARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hORARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hORARIO);
        }

        // GET: HORARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // POST: HORARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HORARIO hORARIO = db.HORARIO.Find(id);
            db.HORARIO.Remove(hORARIO);
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
