using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentAttendance.Models.Banner;
using StudentAttendance.Models.Interfaces;

namespace StudentAttendance.Controllers
{


    [Authorize(Roles = "Student")]
    public class StudentsController : Controller
    {
        //private AttendanceDB db = new AttendanceDB();
        private StudentsRepository db = new StudentsRepository();

        [Route("~/Students")]
        // GET: Students
        public ActionResult Index()
        {
            // return View(db.Students.ToList());
            return View(db.GetStudents());
        }



        [Route("~/Students/Details/{id:int}")]
        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Student student = db.Students.Find(id);
            Student student = db.FindById(Convert.ToInt32(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Route("Home/Contact")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,RegistrationID,FirstName,SecondName,Email,PhoneNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                // db.Students.Add(student);
                //db.SaveChanges();
                db.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Student student = db.Students.Find(id);
            Student student = db.FindById(Convert.ToInt32(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,RegistrationID,FirstName,SecondName,Email,PhoneNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                // db.SaveChanges();
                db.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = db.FindById(Convert.ToInt32(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Student student = db.Students.Find(id);
            //  db.Students.Remove(student);
            // db.SaveChanges();
            db.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
