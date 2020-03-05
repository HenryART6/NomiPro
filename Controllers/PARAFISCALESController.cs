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
    public class PARAFISCALESController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: PARAFISCALES
        public ActionResult Index()
        {
            return View(db.PARAFISCALES.ToList());
        }

        // GET: PARAFISCALES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAFISCALES pARAFISCALES = db.PARAFISCALES.Find(id);
            if (pARAFISCALES == null)
            {
                return HttpNotFound();
            }
            return View(pARAFISCALES);
        }

        // GET: PARAFISCALES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PARAFISCALES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Parafiscales,Nombre,Valor,Estado")] PARAFISCALES pARAFISCALES)
        {
            if (ModelState.IsValid)
            {
                db.PARAFISCALES.Add(pARAFISCALES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pARAFISCALES);
        }

        // GET: PARAFISCALES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAFISCALES pARAFISCALES = db.PARAFISCALES.Find(id);
            if (pARAFISCALES == null)
            {
                return HttpNotFound();
            }
            return View(pARAFISCALES);
        }

        // POST: PARAFISCALES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Parafiscales,Nombre,Valor,Estado")] PARAFISCALES pARAFISCALES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARAFISCALES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARAFISCALES);
        }

        // GET: PARAFISCALES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAFISCALES pARAFISCALES = db.PARAFISCALES.Find(id);
            if (pARAFISCALES == null)
            {
                return HttpNotFound();
            }
            return View(pARAFISCALES);
        }

        // POST: PARAFISCALES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARAFISCALES pARAFISCALES = db.PARAFISCALES.Find(id);
            db.PARAFISCALES.Remove(pARAFISCALES);
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
