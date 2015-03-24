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
    public class IncasariController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Incasari/

        public ActionResult Index()
        {
            var incasari = db.Incasari.Include(i => i.UserProfile);
            return View(incasari.ToList());
        }

        //
        // GET: /Incasari/Details/5

        public ActionResult Details(int id = 0)
        {
            Incasari incasari = db.Incasari.Find(id);
            if (incasari == null)
            {
                return HttpNotFound();
            }
            return View(incasari);
        }

        //
        // GET: /Incasari/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Incasari/Create

        [HttpPost]
        public ActionResult Create(Incasari incasari)
        {
            if (ModelState.IsValid)
            {
                db.Incasari.Add(incasari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", incasari.UserId);
            return View(incasari);
        }

        //
        // GET: /Incasari/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Incasari incasari = db.Incasari.Find(id);
            if (incasari == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", incasari.UserId);
            return View(incasari);
        }

        //
        // POST: /Incasari/Edit/5

        [HttpPost]
        public ActionResult Edit(Incasari incasari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incasari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", incasari.UserId);
            return View(incasari);
        }

        //
        // GET: /Incasari/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Incasari incasari = db.Incasari.Find(id);
            if (incasari == null)
            {
                return HttpNotFound();
            }
            return View(incasari);
        }

        //
        // POST: /Incasari/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Incasari incasari = db.Incasari.Find(id);
            db.Incasari.Remove(incasari);
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