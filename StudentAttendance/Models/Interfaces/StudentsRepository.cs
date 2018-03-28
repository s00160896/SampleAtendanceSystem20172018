using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAttendance.Models.Banner;

namespace StudentAttendance.Models.Interfaces
{
    public class StudentsRepository : IStudentsRepository
    {
        AttendanceDB context = new AttendanceDB();
        public void Add(Student p)
        {
            context.Students.Add(p);
            context.SaveChanges();
        }

        public void Edit(Student p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public Student FindById(int Id)
        {
            var result = (from r in context.Students where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable GetStudents() { return context.Students; }
        public void Remove(int Id) { Student p = context.Students.Find(Id); context.Students.Remove(p); context.SaveChanges(); }
    }
}

