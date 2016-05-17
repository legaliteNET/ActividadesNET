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
    public class actividadesController : Controller
    {
        private legaliteEntities db = new legaliteEntities();

        // GET: actividades
        public ActionResult Index()
        {
            return View(db.actividades.ToList());
        }

        // GET: actividades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividade actividade = db.actividades.Find(id);
            if (actividade == null)
            {
                return HttpNotFound();
            }
            return View(actividade);
        }

        // GET: actividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: actividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "actividad,Valor,id")] actividade actividade)
        {
            if (ModelState.IsValid)
            {
                db.actividades.Add(actividade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividade);
        }

        // GET: actividades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividade actividade = db.actividades.Find(id);
            if (actividade == null)
            {
                return HttpNotFound();
            }
            return View(actividade);
        }

        // POST: actividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "actividad,Valor,id")] actividade actividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividade);
        }

        // GET: actividades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividade actividade = db.actividades.Find(id);
            if (actividade == null)
            {
                return HttpNotFound();
            }
            return View(actividade);
        }

        // POST: actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            actividade actividade = db.actividades.Find(id);
            db.actividades.Remove(actividade);
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
