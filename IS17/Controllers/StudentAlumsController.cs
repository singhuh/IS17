using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IS17.Models;

namespace IS17.Controllers
{
    public class StudentAlumsController : Controller
    {
        private IS17_DBEntities db = new IS17_DBEntities();

        // GET: StudentAlums
        public ActionResult Index()
        {
            return View(db.StudentAlums.ToList());
        }

        // GET: StudentAlums/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAlum studentAlum = db.StudentAlums.Find(id);
            if (studentAlum == null)
            {
                return HttpNotFound();
            }
            return View(studentAlum);
        }

        // GET: StudentAlums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentAlums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MNumber,LastName,FirstName,Gender,Email,AdmitYear,GraduationYear,Country,LinkedIn,Photo")] StudentAlum studentAlum)
        {
            if (ModelState.IsValid)
            {
                db.StudentAlums.Add(studentAlum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentAlum);
        }

        // GET: StudentAlums/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAlum studentAlum = db.StudentAlums.Find(id);
            if (studentAlum == null)
            {
                return HttpNotFound();
            }
            return View(studentAlum);
        }

        // POST: StudentAlums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MNumber,LastName,FirstName,Gender,Email,AdmitYear,GraduationYear,Country,LinkedIn,Photo")] StudentAlum studentAlum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAlum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentAlum);
        }

        // GET: StudentAlums/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAlum studentAlum = db.StudentAlums.Find(id);
            if (studentAlum == null)
            {
                return HttpNotFound();
            }
            return View(studentAlum);
        }

        // POST: StudentAlums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentAlum studentAlum = db.StudentAlums.Find(id);
            db.StudentAlums.Remove(studentAlum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
