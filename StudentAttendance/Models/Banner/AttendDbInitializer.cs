using CsvHelper;
using StudentAttendance.Models.DTO;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentAttendance.Models.Banner
{
    public class AttendDbInitializer : DropCreateDatabaseAlways<AttendanceDB>
    {
        protected override void Seed(AttendanceDB context)
        {

            base.Seed(context);
        }

        public void SeedProducts(AttendanceDB context)
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
                        context.Students.AddOrUpdate(p =>
                                new Student
                                {  RegistrationID = dataItem.RegistrationID,
                                     FirstName = dataItem.FirstName,
                                       SecondName = dataItem.SecondName,
                                      Email = string.Concat(new string[] { dataItem.RegistrationID, "@mail.itsligo.ie" })
                                      
                                });
                    }
                }
            }
            context.SaveChanges();
        }
    }
}