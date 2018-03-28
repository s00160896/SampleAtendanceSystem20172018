using StudentAttendance.Models.Banner;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendance.Models.Interfaces
{
    public interface ILecturerRepository

    {
        void Add(Lecturer p);
        void Edit(Lecturer p);
        void Remove(int Id);
        IEnumerable GetLectures() ; Lecturer FindById(int Id);
    }
} 
   