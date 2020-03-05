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
    public class HETRAXEMPLEADOesController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: HETRAXEMPLEADOes
        public ActionResult Index()
        {
            var hETRAXEMPLEADO = db.HETRAXEMPLEADO.Include(h => h.EMPLEADOS).Include(h => h.HORA_EXTRAS);
            return View(hETRAXEMPLEADO.ToList());
        }

        // GET: HETRAXEMPLEADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HETRAXEMPLEADO hETRAXEMPLEADO = db.HETRAXEMPLEADO.Find(id);
            if (hETRAXEMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(hETRAXEMPLEADO);
        }

        // GET: HETRAXEMPLEADOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Emple = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre");
            ViewBag.ID_HExtras = new SelectList(db.HORA_EXTRAS, "ID_HExtras", "Nombre");
            return View();
        }

        // POST: HETRAXEMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HEXE,ID_Emple,ID_HExtras,Numero_Horas,Mes")] HETRAXEMPLEADO hETRAXEMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.HETRAXEMPLEADO.Add(hETRAXEMPLEADO);
                db.SaveChanges();
                CalculadoraHelper.CalculoDeHoras(hETRAXEMPLEADO, db);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Emple = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", hETRAXEMPLEADO.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.HORA_EXTRAS, "ID_HExtras", "Nombre", hETRAXEMPLEADO.ID_HExtras);
            return View(hETRAXEMPLEADO);
        }

        // GET: HETRAXEMPLEADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HETRAXEMPLEADO hETRAXEMPLEADO = db.HETRAXEMPLEADO.Find(id);
            if (hETRAXEMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Emple = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", hETRAXEMPLEADO.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.HORA_EXTRAS, "ID_HExtras", "Nombre", hETRAXEMPLEADO.ID_HExtras);
            return View(hETRAXEMPLEADO);
        }

        // POST: HETRAXEMPLEADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HEXE,ID_Emple,ID_HExtras,Numero_Horas,Mes")] HETRAXEMPLEADO hETRAXEMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hETRAXEMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                CalculadoraHelper.CalculoDeHoras(hETRAXEMPLEADO, db);
                return RedirectToAction("Index");
            }
            ViewBag.ID_Emple = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", hETRAXEMPLEADO.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.HORA_EXTRAS, "ID_HExtras", "Nombre", hETRAXEMPLEADO.ID_HExtras);
            return View(hETRAXEMPLEADO);
        }

        // GET: HETRAXEMPLEADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HETRAXEMPLEADO hETRAXEMPLEADO = db.HETRAXEMPLEADO.Find(id);
            if (hETRAXEMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(hETRAXEMPLEADO);
        }

        // POST: HETRAXEMPLEADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HETRAXEMPLEADO hETRAXEMPLEADOCal = db.HETRAXEMPLEADO.AsNoTracking().FirstOrDefault(he => he.ID_HEXE == id);
            HETRAXEMPLEADO hETRAXEMPLEADO = db.HETRAXEMPLEADO.Find(id);
            db.HETRAXEMPLEADO.Remove(hETRAXEMPLEADO);
            db.SaveChanges();
            CalculadoraHelper.CalculoDeHoras(hETRAXEMPLEADOCal, db);
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
