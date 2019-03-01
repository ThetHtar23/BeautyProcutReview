using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyProcutReview;

namespace BeautyProcutReview.Controllers
{
    public class BeautyProductsController : Controller
    {
        private AssigmentBeautyParaEntities db = new AssigmentBeautyParaEntities();

        // GET: BeautyProducts
        public ActionResult Index()
        {
            return View(db.BeautyProducts.ToList());
        }

        // GET: BeautyProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautyProduct beautyProduct = db.BeautyProducts.Find(id);
            if (beautyProduct == null)
            {
                return HttpNotFound();
            }
            return View(beautyProduct);
        }

        // GET: BeautyProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("login", "Account");
        }


        // POST: BeautyProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,image,ProductDescription")] BeautyProduct beautyProduct)
        {
            if (ModelState.IsValid)
            {
                db.BeautyProducts.Add(beautyProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beautyProduct);
        }

        // GET: BeautyProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautyProduct beautyProduct = db.BeautyProducts.Find(id);
            if (beautyProduct == null)
            {
                return HttpNotFound();
            }
            return View(beautyProduct);
        }

        // POST: BeautyProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,image,ProductDescription")] BeautyProduct beautyProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beautyProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beautyProduct);
        }

        // GET: BeautyProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautyProduct beautyProduct = db.BeautyProducts.Find(id);
            if (beautyProduct == null)
            {
                return HttpNotFound();
            }
            return View(beautyProduct);
        }

        // POST: BeautyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeautyProduct beautyProduct = db.BeautyProducts.Find(id);
            db.BeautyProducts.Remove(beautyProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
