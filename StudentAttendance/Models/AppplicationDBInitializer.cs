using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

            roleManager.Create(new IdentityRole { Name = "Admin" });
            roleManager.Create(new IdentityRole { Name = "Lecturer" });
            roleManager.Create(new IdentityRole { Name = "Student" });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "pgorman",
                    Email = "gorman.pearse@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = new PasswordHasher().HashPassword("Pearse$12345"),

                }
                );

            context.SaveChanges();
            var pearse = manager.FindByName("pgorman");
            manager.AddToRole(pearse.Id, "Admin");
            context.SaveChanges();


            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "ppowell",
                   Email = "powell.paul@itsligo.ie",
                   EmailConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString(),
                   PasswordHash = new PasswordHasher().HashPassword("Paul$12345"),

               }
               );

            context.SaveChanges();
            var paul = manager.FindByName("ppowell");
            manager.AddToRole(paul.Id, "Lecturer");
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "doates",
                   Email = "oates.darren@itsligo.ie",
                   EmailConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString(),
                   PasswordHash = new PasswordHasher().HashPassword("Darren$12345"),

               }
               );

            context.SaveChanges();
            var darren = manager.FindByName("doates");
            manager.AddToRole(darren.Id, "Student");
            context.SaveChanges();

            base.Seed(context);
        }

    }
}