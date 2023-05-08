using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDBPracticaS14.Models;

namespace WebDBPracticaS14.Controllers
{
    public class EmpleadoController : Controller
    {
        private BDS14Entities db = new BDS14Entities();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.tb_Empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Empleado tb_Empleado = db.tb_Empleado.Find(id);
            if (tb_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(tb_Empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Edad")] tb_Empleado tb_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.tb_Empleado.Add(tb_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Empleado tb_Empleado = db.tb_Empleado.Find(id);
            if (tb_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(tb_Empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Edad")] tb_Empleado tb_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Empleado tb_Empleado = db.tb_Empleado.Find(id);
            if (tb_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(tb_Empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Empleado tb_Empleado = db.tb_Empleado.Find(id);
            db.tb_Empleado.Remove(tb_Empleado);
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
