using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomiPro.ModelDB;
using Rotativa;

namespace NomiPro.Controllers
{
    public class NOMINAsController : Controller
    {
        private NomiProEntities db = new NomiProEntities();

        // GET: NOMINAs
        public ActionResult Index()
        {
            var nOMINA = db.NOMINA.Include(n => n.CARGOS).Include(n => n.CONTROL_PAGO).Include(n => n.EMPLEADOS);
            return View(nOMINA.ToList());
        }

        // GET: NOMINAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // GET: NOMINAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CargoN = new SelectList(db.CARGOS, "ID_Cargos", "Nombre");
            ViewBag.ID_Control_PagoN = new SelectList(db.CONTROL_PAGO, "ID_Control_Pago", "Mes");
            ViewBag.ID_EmpleN = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre");
            return View();
        }

        // POST: NOMINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nomina,ID_EmpleN,ID_CargoN,ID_Control_PagoN,Mes,Estado,Subtotal,Total")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.NOMINA.Add(nOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CargoN = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", nOMINA.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.CONTROL_PAGO, "ID_Control_Pago", "Mes", nOMINA.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", nOMINA.ID_EmpleN);
            return View(nOMINA);
        }

        // GET: NOMINAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CargoN = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", nOMINA.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.CONTROL_PAGO, "ID_Control_Pago", "Mes", nOMINA.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", nOMINA.ID_EmpleN);
            return View(nOMINA);
        }

        // POST: NOMINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nomina,ID_EmpleN,ID_CargoN,ID_Control_PagoN,Mes,Estado,Subtotal,Total")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CargoN = new SelectList(db.CARGOS, "ID_Cargos", "Nombre", nOMINA.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.CONTROL_PAGO, "ID_Control_Pago", "Mes", nOMINA.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.EMPLEADOS, "ID_Emple", "Nombre", nOMINA.ID_EmpleN);
            return View(nOMINA);
        }

        // GET: NOMINAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINA nOMINA = db.NOMINA.Find(id);
            db.NOMINA.Remove(nOMINA);
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

        //Nominas Report
        public ActionResult Report(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nomina = db.NOMINA.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        public ActionResult PrintNomina(int id)
        {
            return new ActionAsPdf("/Report/" + id) { FileName = "ReporteNomina.pdf" };
            
        }


    }
    
}
