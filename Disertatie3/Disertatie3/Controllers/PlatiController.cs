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
    public class PlatiController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Plati/

        public ActionResult Index()
        {
            var plati = db.Plati.Include(p => p.UserProfile);
            return View(plati.ToList());
        }

        //
        // GET: /Plati/Details/5

        public ActionResult Details(int id = 0)
        {
            Plati plati = db.Plati.Find(id);
            if (plati == null)
            {
                return HttpNotFound();
            }
            return View(plati);
        }

        //
        // GET: /Plati/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Plati/Create

        [HttpPost]
        public ActionResult Create(Plati plati)
        {
            if (ModelState.IsValid)
            {
                db.Plati.Add(plati);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", plati.UserId);
            return View(plati);
        }

        //
        // GET: /Plati/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Plati plati = db.Plati.Find(id);
            if (plati == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", plati.UserId);
            return View(plati);
        }

        //
        // POST: /Plati/Edit/5

        [HttpPost]
        public ActionResult Edit(Plati plati)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plati).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", plati.UserId);
            return View(plati);
        }

        //
        // GET: /Plati/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Plati plati = db.Plati.Find(id);
            if (plati == null)
            {
                return HttpNotFound();
            }
            return View(plati);
        }

        //
        // POST: /Plati/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Plati plati = db.Plati.Find(id);
            db.Plati.Remove(plati);
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