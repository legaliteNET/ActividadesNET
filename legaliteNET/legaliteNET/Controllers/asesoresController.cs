using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using legaliteNET.Models;

namespace legaliteNET.Controllers
{
    public class asesoresController : Controller
    {
        private legaliteEntities db = new legaliteEntities();

        // GET: asesores
        public ActionResult Index()
        {
            return View(db.asesores.ToList());
        }

        // GET: asesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asesore asesore = db.asesores.Find(id);
            if (asesore == null)
            {
                return HttpNotFound();
            }
            return View(asesore);
        }

        // GET: asesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idasesor,nombreusuario,password,nivel,nombre,salariobasico,costodiario,costohora")] asesore asesore)
        {
            if (ModelState.IsValid)
            {
                db.asesores.Add(asesore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesore);
        }

        // GET: asesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asesore asesore = db.asesores.Find(id);
            if (asesore == null)
            {
                return HttpNotFound();
            }
            return View(asesore);
        }

        // POST: asesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idasesor,nombreusuario,password,nivel,nombre,salariobasico,costodiario,costohora")] asesore asesore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesore);
        }

        // GET: asesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asesore asesore = db.asesores.Find(id);
            if (asesore == null)
            {
                return HttpNotFound();
            }
            return View(asesore);
        }

        // POST: asesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asesore asesore = db.asesores.Find(id);
            db.asesores.Remove(asesore);
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
