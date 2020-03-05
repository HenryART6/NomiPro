using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomiPro.ModelDB;
using NomiPro.helpers;

namespace NomiPro.Controllers
{
    public class PARAXEMPLEsController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: PARAXEMPLEs
        public ActionResult Index()
        {
            var pARAXEMPLE = db.PARAXEMPLE.Include(p => p.EMPLEADOS).Include(p => p.PARAFISCALES);
            return View(pARAXEMPLE.ToList());
        }

        // GET: PARAXEMPLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAXEMPLE pARAXEMPLE = db.PARAXEMPLE.Find(id);
            if (pARAXEMPLE == null)
            {
                return HttpNotFound();
            }
            return View(pARAXEMPLE);
        }

        // GET: PARAXEMPLEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_EmpleP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre");
            ViewBag.ID_Parafiscales = new SelectList(db.PARAFISCALES, "ID_Parafiscales", "Nombre");
            return View();
        }

        // POST: PARAXEMPLEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAEM,ID_Parafiscales,ID_EmpleP,Mes")] PARAXEMPLE pARAXEMPLE)
        {
            if (ModelState.IsValid)
            {
                db.PARAXEMPLE.Add(pARAXEMPLE);
                db.SaveChanges();
                CalculadoraHelper.CalculoDeHoras(pARAXEMPLE, db);
                return RedirectToAction("Index");
            }

            ViewBag.ID_EmpleP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", pARAXEMPLE.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.PARAFISCALES, "ID_Parafiscales", "Nombre", pARAXEMPLE.ID_Parafiscales);
            return View(pARAXEMPLE);
        }

        // GET: PARAXEMPLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAXEMPLE pARAXEMPLE = db.PARAXEMPLE.Find(id);
            if (pARAXEMPLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EmpleP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", pARAXEMPLE.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.PARAFISCALES, "ID_Parafiscales", "Nombre", pARAXEMPLE.ID_Parafiscales);
            return View(pARAXEMPLE);
        }

        // POST: PARAXEMPLEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAEM,ID_Parafiscales,ID_EmpleP,Mes")] PARAXEMPLE pARAXEMPLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARAXEMPLE).State = EntityState.Modified;
                db.SaveChanges();
                CalculadoraHelper.CalculoDeHoras(pARAXEMPLE, db);
                return RedirectToAction("Index");
            }
            ViewBag.ID_EmpleP = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", pARAXEMPLE.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.PARAFISCALES, "ID_Parafiscales", "Nombre", pARAXEMPLE.ID_Parafiscales);
            return View(pARAXEMPLE);
        }

        // GET: PARAXEMPLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAXEMPLE pARAXEMPLE = db.PARAXEMPLE.Find(id);
            if (pARAXEMPLE == null)
            {
                return HttpNotFound();
            }
            return View(pARAXEMPLE);
        }

        // POST: PARAXEMPLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARAXEMPLE PARAXEMPLECal = db.PARAXEMPLE.AsNoTracking().FirstOrDefault(he => he.ID_PAEM == id);
            PARAXEMPLE pARAXEMPLE = db.PARAXEMPLE.Find(id);
            db.PARAXEMPLE.Remove(pARAXEMPLE);
            db.SaveChanges();
            CalculadoraHelper.CalculoDeHoras(pARAXEMPLE, db);
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
