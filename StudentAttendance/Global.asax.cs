using StudentAttendance.Models;
using StudentAttendance.Models.Banner;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentAttendance
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
#if DEBUG
            Database.SetInitializer(new AppplicationDBInitializer());
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.Initialize(true);

            Database.SetInitializer(new AttendDbInitializer());
            AttendanceDB att_db = new AttendanceDB();
            att_db.Database.Initialize(true);
#endif
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
