using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using StudentAttendance.Models.Banner;
using System.Data.Entity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(StudentAttendance.Startup))]

namespace StudentAttendance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login")
            });
        }
    }
}
