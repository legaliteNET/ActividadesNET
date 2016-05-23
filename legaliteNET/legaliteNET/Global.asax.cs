using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace legaliteNET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/asesores");
        }
        protected void Session_End(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/asesores/logIn");
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContextBase context = new HttpContextWrapper(HttpContext.Current);
            RouteData rd = RouteTable.Routes.GetRouteData(context);

            if (rd != null)
            {
                string controllerName = rd.GetRequiredString("controller");
                string actionName = rd.GetRequiredString("action");
                if (Session["username"] == null && controllerName != "asesores") { HttpContext.Current.Response.Redirect("~/asesores/logIn"); }
                else
                {
                    if (Session["xrol"] != null)
                    {
                        int role = Convert.ToInt32(Session["xrol"].ToString());
                        if (role == 1 && controllerName != "clientes" && controllerName != "asesores" && controllerName != "actividades" && controllerName != "solicitudes" && controllerName != "Reportes") { HttpContext.Current.Response.Redirect("~/default"); };
                        if (role == 2 && controllerName != "solicitudes") { HttpContext.Current.Response.Redirect("~/solicitudes/index"); };
                      
                        }
                }

            }

        }
    }
}
