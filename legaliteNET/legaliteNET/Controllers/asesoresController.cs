using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using legaliteNET.Models;

namespace legaliteNET.Controllers
{
    public class asesoresController : Controller
    {
        private legaliteEntities db = new legaliteEntities();

        // GET: asesores
        public ActionResult Index()
        {
            //ok ud esta asignandondo sin antte y trate de usar try cath para que qeu no se reviente bayjajaja ok ahora lo molesto aver
        
                if (Session["nombreuser"] != null)

                {
                return Redirect("~/asesores/logIn");

                }

                else
                {
                ViewBag.Controlador = "asesores";
                ViewBag.Title = "Index";

                return View(db.asesores.ToList());
                
                }
      
            

           
        }        
        // GET: asesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asesore asesore = db.asesores.Find(id);
            ViewBag.Controlador = "asesores";
            ViewBag.Title = "Detalles";
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
                ViewBag.Controlador = "asesores";
                ViewBag.Title = "Crear";
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
            ViewBag.Controlador = "asesores";
            ViewBag.Title = "Editar";
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
            ViewBag.Controlador = "asesores";
            ViewBag.Title = "Eliminar";
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
        //valida si el usuario es valido//
        public async Task<ActionResult> logIn()
        {

            if (Session["username"] == null)
            {
                return View("logIn", "");
            }
            else
            {
                return Redirect("~/");
            }
        }

        [HttpPost]
        public ActionResult logIn(Models.asesore user)
        {

            if (ModelState.IsValid)
            {

                if (IsValid(user.nombreusuario, user.password))
                {
                    var usua = from a in db.asesores
                               where a.nombreusuario == user.nombreusuario && a.password == user.password
                               select a;
                    if (usua.First().nivel == 1)
                    {
                        FormsAuthentication.SetAuthCookie(user.nombreusuario, false);

                        String nombreusuario = user.nombreusuario;
                        Session["username"] = user.nombreusuario;
                        Session["asesorid"] = usua.First().idasesor;
                        Session["asesornombre"] = usua.First().nombre;
                        Session["xrol"] = usua.First().nivel;
                        if (usua.First().nivel == 2)
                        {
                            Session["username"] = user.nombreusuario;
                            Session["asesorid"] = usua.First().idasesor;
                            Session["asesornombre"] = usua.First().nombre;
                            Session["xrol"] = usua.First().nivel;
                            return RedirectToAction("`~/solicitudes/index");
                        }               

                        return RedirectToAction("index");
                    }
                    else
                    {
                        return View("index");
                    }
                }
            }
            return View(user);
        }

        private bool IsValid(string username, string password)
        {
            var usua = from a in db.asesores
                       where a.nombreusuario == username && a.password == password
                       select a.nombreusuario;

            if (usua.Count() > 0)
            {
                return true;
            }
            else return false;


        }

        public ActionResult CerrarSesion()
        {
            
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            FormsAuthentication.SignOut();
            return Redirect("~/asesores/logIn");


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
