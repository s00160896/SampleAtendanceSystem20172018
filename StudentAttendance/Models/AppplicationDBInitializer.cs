using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentAttendance.Models
{
    public class AppplicationDBInitializer: CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var manager =
                             new UserManager<ApplicationUser>(
                                 new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Super User" });
            roleManager.Create(new IdentityRole { Name = "Purchase Manager" });
            roleManager.Create(new IdentityRole { Name = "Employee" });

            base.Seed(context);
        }

    }
}