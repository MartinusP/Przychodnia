﻿using Przychodnia.Models;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Przychodnia
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //IdentityConfig.RegisterIdentities();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Request.Cookies != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["_lang"];
                if (cookie != null && cookie.Value != null)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pl");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl");
                }
            }
        }
    }
}
