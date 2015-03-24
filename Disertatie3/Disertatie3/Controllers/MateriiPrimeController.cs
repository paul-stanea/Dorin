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
    public class MateriiPrimeController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /MateriiPrime/

        public ActionResult Index()
        {
            var materiiprime = db.MateriiPrime.Include(m => m.UserProfile);
            return View(materiiprime.ToList());
        }

        //
        // GET: /MateriiPrime/Details/5

        public ActionResult Details(int id = 0)
        {
            MateriiPrime materiiprime = db.MateriiPrime.Find(id);
            if (materiiprime == null)
            {
                return HttpNotFound();
            }
            return View(materiiprime);
        }

        //
        // GET: /MateriiPrime/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /MateriiPrime/Create

        [HttpPost]
        public ActionResult Create(MateriiPrime materiiprime)
        {
            if (ModelState.IsValid)
            {
                db.MateriiPrime.Add(materiiprime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", materiiprime.UserId);
            return View(materiiprime);
        }

        //
        // GET: /MateriiPrime/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MateriiPrime materiiprime = db.MateriiPrime.Find(id);
            if (materiiprime == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", materiiprime.UserId);
            return View(materiiprime);
        }

        //
        // POST: /MateriiPrime/Edit/5

        [HttpPost]
        public ActionResult Edit(MateriiPrime materiiprime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiiprime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", materiiprime.UserId);
            return View(materiiprime);
        }

        //
        // GET: /MateriiPrime/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MateriiPrime materiiprime = db.MateriiPrime.Find(id);
            if (materiiprime == null)
            {
                return HttpNotFound();
            }
            return View(materiiprime);
        }

        //
        // POST: /MateriiPrime/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MateriiPrime materiiprime = db.MateriiPrime.Find(id);
            db.MateriiPrime.Remove(materiiprime);
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