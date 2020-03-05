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
    public class CARGOSController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: CARGOS
        
        public ActionResult Index()
        {
            return View(db.CARGOS.ToList());
        }

        // GET: CARGOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGOS cARGOS = db.CARGOS.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // GET: CARGOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CARGOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cargos,Nombre,Estado,Valor_cargo")] CARGOS cARGOS)
        {
            if (ModelState.IsValid)
            {
                db.CARGOS.Add(cARGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cARGOS);
        }

        // GET: CARGOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGOS cARGOS = db.CARGOS.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // POST: CARGOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cargos,Nombre,Estado,Valor_cargo")] CARGOS cARGOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARGOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cARGOS);
        }

        // GET: CARGOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGOS cARGOS = db.CARGOS.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // POST: CARGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARGOS cARGOS = db.CARGOS.Find(id);
            db.CARGOS.Remove(cARGOS);
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
