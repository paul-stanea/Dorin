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
    public class StocProduseController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /StocProduse/

        public ActionResult Index()
        {
            return View(db.StocProduse.ToList());
        }

        //
        // GET: /StocProduse/Details/5

        public ActionResult Details(int id = 0)
        {
            StocProduse stocproduse = db.StocProduse.Find(id);
            if (stocproduse == null)
            {
                return HttpNotFound();
            }
            return View(stocproduse);
        }

        //
        // GET: /StocProduse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StocProduse/Create

        [HttpPost]
        public ActionResult Create(StocProduse stocproduse)
        {
            if (ModelState.IsValid)
            {
                db.StocProduse.Add(stocproduse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stocproduse);
        }

        //
        // GET: /StocProduse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StocProduse stocproduse = db.StocProduse.Find(id);
            if (stocproduse == null)
            {
                return HttpNotFound();
            }
            return View(stocproduse);
        }

        //
        // POST: /StocProduse/Edit/5

        [HttpPost]
        public ActionResult Edit(StocProduse stocproduse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocproduse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stocproduse);
        }

        //
        // GET: /StocProduse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StocProduse stocproduse = db.StocProduse.Find(id);
            if (stocproduse == null)
            {
                return HttpNotFound();
            }
            return View(stocproduse);
        }

        //
        // POST: /StocProduse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StocProduse stocproduse = db.StocProduse.Find(id);
            db.StocProduse.Remove(stocproduse);
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