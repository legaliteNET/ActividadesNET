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
    public class ReportesController : Controller
    {
        private legaliteEntities db = new legaliteEntities();
        // GET: Reportes
        public ActionResult ActividadesEnElMes()
        {

            var reporte = db.ActividadesEnElMes();
            return View(reporte.ToList());
        }
        public ActionResult Trabajos_del_mes_asesor(int? idasesor)
        {
            var reporte = db.Trabajos_del_mes_asesores(idasesor);
            var asesor =  from x in reporte select x.Asesor;
            ViewBag.Asesor = asesor;
            return View(reporte.ToList());
        }
        public ActionResult ServerFiltering()
        {
            return View();
        }
    }
}