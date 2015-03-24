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
    public class ProduseController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Produse/

        public ActionResult Index()
        {
            var produse = db.Produse.Include(p => p.UserProfile);
            return View(produse.ToList());
        }

        //
        // GET: /Produse/Details/5

        public ActionResult Details(int id = 0)
        {
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        //
        // GET: /Produse/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Produse/Create

        [HttpPost]
        public ActionResult Create(Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Produse.Add(produse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", produse.UserId);
            return View(produse);
        }

        //
        // GET: /Produse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", produse.UserId);
            return View(produse);
        }

        //
        // POST: /Produse/Edit/5

        [HttpPost]
        public ActionResult Edit(Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", produse.UserId);
            return View(produse);
        }

        //
        // GET: /Produse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        //
        // POST: /Produse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Produse produse = db.Produse.Find(id);
            db.Produse.Remove(produse);
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