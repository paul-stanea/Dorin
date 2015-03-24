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
    public class StocMateriiController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /StocMaterii/

        public ActionResult Index()
        {
            return View(db.StocMaterii.ToList());
        }

        //
        // GET: /StocMaterii/Details/5

        public ActionResult Details(int id = 0)
        {
            StocMaterii stocmaterii = db.StocMaterii.Find(id);
            if (stocmaterii == null)
            {
                return HttpNotFound();
            }
            return View(stocmaterii);
        }

        //
        // GET: /StocMaterii/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StocMaterii/Create

        [HttpPost]
        public ActionResult Create(StocMaterii stocmaterii)
        {
            if (ModelState.IsValid)
            {
                db.StocMaterii.Add(stocmaterii);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stocmaterii);
        }

        //
        // GET: /StocMaterii/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StocMaterii stocmaterii = db.StocMaterii.Find(id);
            if (stocmaterii == null)
            {
                return HttpNotFound();
            }
            return View(stocmaterii);
        }

        //
        // POST: /StocMaterii/Edit/5

        [HttpPost]
        public ActionResult Edit(StocMaterii stocmaterii)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocmaterii).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stocmaterii);
        }

        //
        // GET: /StocMaterii/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StocMaterii stocmaterii = db.StocMaterii.Find(id);
            if (stocmaterii == null)
            {
                return HttpNotFound();
            }
            return View(stocmaterii);
        }

        //
        // POST: /StocMaterii/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StocMaterii stocmaterii = db.StocMaterii.Find(id);
            db.StocMaterii.Remove(stocmaterii);
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