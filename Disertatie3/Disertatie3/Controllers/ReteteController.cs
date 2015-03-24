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
    public class ReteteController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Retete/

        public ActionResult Index()
        {
            var retete = db.Retete.Include(r => r.UserProfile);
            return View(retete.ToList());
        }

        //
        // GET: /Retete/Details/5

        public ActionResult Details(int id = 0)
        {
            Retete retete = db.Retete.Find(id);
            if (retete == null)
            {
                return HttpNotFound();
            }
            return View(retete);
        }

        //
        // GET: /Retete/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Retete/Create

        [HttpPost]
        public ActionResult Create(Retete retete)
        {
            if (ModelState.IsValid)
            {
                db.Retete.Add(retete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", retete.UserId);
            return View(retete);
        }

        //
        // GET: /Retete/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Retete retete = db.Retete.Find(id);
            if (retete == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", retete.UserId);
            return View(retete);
        }

        //
        // POST: /Retete/Edit/5

        [HttpPost]
        public ActionResult Edit(Retete retete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", retete.UserId);
            return View(retete);
        }

        //
        // GET: /Retete/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Retete retete = db.Retete.Find(id);
            if (retete == null)
            {
                return HttpNotFound();
            }
            return View(retete);
        }

        //
        // POST: /Retete/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Retete retete = db.Retete.Find(id);
            db.Retete.Remove(retete);
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