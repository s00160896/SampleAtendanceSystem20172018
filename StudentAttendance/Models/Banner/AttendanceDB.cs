using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentAttendance.Models.Banner
{
    public class AttendanceDB : DbContext
    {
        public AttendanceDB() : base("SchoolDB")
        {
        
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceList> AttendanceList { get; set; }
    }
}