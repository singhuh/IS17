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
    public class WorkHistoriesController : Controller
    {
        private IS17_DBEntities db = new IS17_DBEntities();

        // GET: WorkHistories
        //public ActionResult Index()
        //{
        //    var workHistories = db.WorkHistories.Include(w => w.Company).Include(w => w.StudentAlum).Include(w => w.Title);
        //    return View(workHistories.ToList());
        //}

        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "CompanyName")
            {
                return View(db.WorkHistories.Where(x => x.CompanyName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.WorkHistories.Where(x => x.TitleName.StartsWith(search) || search == null).ToList());
            }
        }


        // GET: WorkHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // GET: WorkHistories/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.MNumber = new SelectList(db.StudentAlums, "MNumber", "LastName");
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName");
            return View();
        }

        // POST: WorkHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkHistoryId,MNumber,LastName,CompanyId,CompanyName,TitleId,TitleName,StartDate,EndDate,FTE,Compensation")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.WorkHistories.Add(workHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", workHistory.CompanyId);
            ViewBag.MNumber = new SelectList(db.StudentAlums, "MNumber", "LastName", workHistory.MNumber);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", workHistory.TitleId);
            return View(workHistory);
        }

        // GET: WorkHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", workHistory.CompanyId);
            ViewBag.MNumber = new SelectList(db.StudentAlums, "MNumber", "LastName", workHistory.MNumber);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", workHistory.TitleId);
            return View(workHistory);
        }

        // POST: WorkHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkHistoryId,MNumber,LastName,CompanyId,CompanyName,TitleId,TitleName,StartDate,EndDate,FTE,Compensation")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", workHistory.CompanyId);
            ViewBag.MNumber = new SelectList(db.StudentAlums, "MNumber", "LastName", workHistory.MNumber);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", workHistory.TitleId);
            return View(workHistory);
        }

        // GET: WorkHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: WorkHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkHistory workHistory = db.WorkHistories.Find(id);
            db.WorkHistories.Remove(workHistory);
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
