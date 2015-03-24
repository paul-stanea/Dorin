using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Disertatie3.Models;

namespace Disertatie3.Controllers
{
    public class ConsumController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Consum/

        public ActionResult Index()
        {
            var consum = db.Consum.Include(c => c.UserProfile);
            return View(consum.ToList());
        }

        //
        // GET: /Consum/Details/5

        public ActionResult Details(int id = 0)
        {
            Consum consum = db.Consum.Find(id);
            if (consum == null)
            {
                return HttpNotFound();
            }
            return View(consum);
        }

        //
        // GET: /Consum/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Consum/Create

        [HttpPost]
        public ActionResult Create(Consum consum)
        {
            if (ModelState.IsValid)
            {
                db.Consum.Add(consum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consum.UserId);
            return View(consum);
        }

        //
        // GET: /Consum/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Consum consum = db.Consum.Find(id);
            if (consum == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consum.UserId);
            return View(consum);
        }

        //
        // POST: /Consum/Edit/5

        [HttpPost]
        public ActionResult Edit(Consum consum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consum.UserId);
            return View(consum);
        }

        //
        // GET: /Consum/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Consum consum = db.Consum.Find(id);
            if (consum == null)
            {
                return HttpNotFound();
            }
            return View(consum);
        }

        //
        // POST: /Consum/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consum consum = db.Consum.Find(id);
            db.Consum.Remove(consum);
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