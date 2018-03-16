using CsvHelper;
using StudentAttendance.Models.DTO;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System;
using System.Collections.Generic;

namespace StudentAttendance.Models.Banner
{
    public class AttendDbInitializer : CreateDatabaseIfNotExists<AttendanceDB>
    {
       protected override void Seed(AttendanceDB context)
        {
            SeedStudents(context);
            SeedModules(context);
            SeedLecturers(context);
            SeedEnrollments(context);
            SeedDelivery(context, 
                            context.Modules.First(m => m.ModuleName.Equals("AI")),
                            context.Lecturers.First(l => l.FirstName.Equals("Paul") 
                                                    && l.SecondName.Equals("Powell"))) ;
            context.SaveChanges();
            base.Seed(context);
        }

        private void SeedDelivery(AttendanceDB context, Module module, Lecturer lecturer)
        {
            
            int[] slots = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            string[] days = new string[] { "Mon", "Tues", "Wed", "Thurs", "Fri" };
            int slot = new Random().Next(slots.Count());
            string day = days[new Random().Next(days.Count())];
                context.Deliveries.AddOrUpdate(d => new {d.LecturerId,d.ModuleId, d.Day, d.TimeSlot},
                  new Delivery[] {
                    new Delivery {
                        DeliveredBy = lecturer,
                        DeliveryOf = module,
                        Day = day,
                        TimeSlot =new TimeSpan(slot,0,0)
                  } });
            
            context.SaveChanges();
        }

        private void SeedEnrollments(AttendanceDB context)
        {
            // get the first module
            var module = context.Modules.First();
            // get a random selection of students
            foreach (var student in GetRandomStudent(context, 10))
            {
                // enroll the students on the module
                context.Enrollments.AddOrUpdate(e => new { e.StudentId, e.ModuleId },
                    new Enrollment[] {
                        new Enrollment { StudentEnrolled = student,
                                         EnrolledOn = module,
                                        EnrollmentDate = DateTime.Now
                        }
                    });
            }
            context.SaveChanges();
        }

        // Get a ratom count of students 
        private Student[] GetRandomStudent(AttendanceDB Context, int count)
        {
            var randomids = Context.Students.Select(s => new { s.id, order = Guid.NewGuid() })
                                    .OrderBy(o => o.order)
                                    .Select(s => s.id);
            // take count where student record contains selected random ids
               return Context.Students.Where(s => randomids.Contains(s.id))
                                      .Take(count).ToArray();
                                    
        }


        private void SeedLecturers(AttendanceDB context)
        {
            context.Lecturers.AddOrUpdate(p => new { p.FirstName, p.SecondName },
                new Lecturer[]
                {
                    new Lecturer { FirstName="Paul", SecondName="Powell" },
                    new Lecturer { FirstName="Vivion", SecondName="Kinsella" },
                });
            context.SaveChanges();
        }

        private void SeedModules(AttendanceDB context)
        {
            context.Modules.AddOrUpdate(p => p.ModuleName,
                new Module[] {
                    new Module { ModuleName = "AI", Description = "Artificial Intelligence" },
                    new Module { ModuleName = "RAD301", Description = "Rich Application Development 1" },
                    new Module { ModuleName = "RAD302", Description = "Rich Application Development 2" }
                });
            context.SaveChanges();
        }

        public void SeedStudents(AttendanceDB context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "StudentAttendance.App_Data.BSc4.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    var studentData = csvReader.GetRecords<StudentDTO>().ToArray();
                    foreach (var dataItem in studentData)
                    {
                        context.Students.AddOrUpdate(p => p.Email,
                                new Student
                                { RegistrationID = dataItem.RegistrationID,
                                    FirstName = dataItem.FirstName,
                                    SecondName = dataItem.SecondName,
                                    Email = dataItem.RegistrationID + "@mail.itsligo.ie"
                                });
                    }
                }
            }
            context.SaveChanges();
        }
    }
}