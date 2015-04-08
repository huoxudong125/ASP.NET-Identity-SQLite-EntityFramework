using Mvc4WorkGps.Models;
using PagedList;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Mvc4WorkGps.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /User/

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var users = from s in db.Users
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Name);
                    break;

                case "imsi":
                    users = users.OrderBy(s => s.IMSI);
                    break;

                case "imsi_desc":
                    users = users.OrderByDescending(s => s.IMSI);
                    break;

                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            UserModel usermodel = db.Users.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(usermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usermodel);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserModel usermodel = db.Users.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usermodel);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserModel usermodel = db.Users.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserModel usermodel = db.Users.Find(id);
            db.Users.Remove(usermodel);
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