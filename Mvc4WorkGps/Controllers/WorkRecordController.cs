using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4WorkGps.Models;

namespace Mvc4WorkGps.Controllers
{
    [Authorize]
    public class WorkRecordController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /WorkRecord/

        public ActionResult Index()
        {
            return View(db.WorkRecords.ToList());
        }

        //
        // GET: /WorkRecord/Details/5

        public ActionResult Details(int id = 0)
        {
            WorkRecordModel workrecordmodel = db.WorkRecords.Find(id);
            if (workrecordmodel == null)
            {
                return HttpNotFound();
            }
            return View(workrecordmodel);
        }

        //
        // GET: /WorkRecord/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WorkRecord/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkRecordModel workrecordmodel)
        {
            if (ModelState.IsValid)
            {
                db.WorkRecords.Add(workrecordmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workrecordmodel);
        }

        //
        // GET: /WorkRecord/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WorkRecordModel workrecordmodel = db.WorkRecords.Find(id);
            if (workrecordmodel == null)
            {
                return HttpNotFound();
            }
            return View(workrecordmodel);
        }

        //
        // POST: /WorkRecord/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkRecordModel workrecordmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workrecordmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workrecordmodel);
        }

        //
        // GET: /WorkRecord/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WorkRecordModel workrecordmodel = db.WorkRecords.Find(id);
            if (workrecordmodel == null)
            {
                return HttpNotFound();
            }
            return View(workrecordmodel);
        }

        //
        // POST: /WorkRecord/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkRecordModel workrecordmodel = db.WorkRecords.Find(id);
            db.WorkRecords.Remove(workrecordmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}