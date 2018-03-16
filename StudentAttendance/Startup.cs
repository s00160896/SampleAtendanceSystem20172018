using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using StudentAttendance.Models.Banner;
using System.Data.Entity;

[assembly: OwinStartup(typeof(StudentAttendance.Startup))]

namespace StudentAttendance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
