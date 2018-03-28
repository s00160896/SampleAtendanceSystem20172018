using StudentAttendance.Models.Banner;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Models.Interfaces
{
    public interface IStudentsRepository
    {
        void Add(Student p);
        void Edit(Student p);
        void Remove(int Id);
        IEnumerable GetStudents(); Student FindById(int Id);
    }
} 
 
