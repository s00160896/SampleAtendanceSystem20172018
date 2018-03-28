using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAttendance.Models.Banner;

namespace StudentAttendance.Models.Interfaces
{
    public class LecturerRepository : ILecturerRepository
    {
        AttendanceDB context = new AttendanceDB();
        public void Add(Lecturer p)
        {
            context.Lecturers.Add(p);
            context.SaveChanges();
        }

        public void Edit(Lecturer p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public Lecturer FindById(int Id)
        {
            var result = (from r in context.Lecturers where r.id == Id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable GetLectures() { return context.Lecturers; }
        public void Remove(int Id) { Lecturer p = context.Lecturers.Find(Id); context.Lecturers.Remove(p); context.SaveChanges(); }
    }
}