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
    public class HORA_EXTRASController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: HORA_EXTRAS
        public ActionResult Index()
        {
            return View(db.HORA_EXTRAS.ToList());
        }

        // GET: HORA_EXTRAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORA_EXTRAS hORA_EXTRAS = db.HORA_EXTRAS.Find(id);
            if (hORA_EXTRAS == null)
            {
                return HttpNotFound();
            }
            return View(hORA_EXTRAS);
        }

        // GET: HORA_EXTRAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HORA_EXTRAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HExtras,Nombre,Valor,Estado")] HORA_EXTRAS hORA_EXTRAS)
        {
            if (ModelState.IsValid)
            {
                db.HORA_EXTRAS.Add(hORA_EXTRAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hORA_EXTRAS);
        }

        // GET: HORA_EXTRAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORA_EXTRAS hORA_EXTRAS = db.HORA_EXTRAS.Find(id);
            if (hORA_EXTRAS == null)
            {
                return HttpNotFound();
            }
            return View(hORA_EXTRAS);
        }

        // POST: HORA_EXTRAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HExtras,Nombre,Valor,Estado")] HORA_EXTRAS hORA_EXTRAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hORA_EXTRAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hORA_EXTRAS);
        }

        // GET: HORA_EXTRAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORA_EXTRAS hORA_EXTRAS = db.HORA_EXTRAS.Find(id);
            if (hORA_EXTRAS == null)
            {
                return HttpNotFound();
            }
            return View(hORA_EXTRAS);
        }

        // POST: HORA_EXTRAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HORA_EXTRAS hORA_EXTRAS = db.HORA_EXTRAS.Find(id);
            db.HORA_EXTRAS.Remove(hORA_EXTRAS);
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
