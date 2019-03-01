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
    public class MemberReivewsController : Controller
    {
        private AssigmentBeautyParaEntities db = new AssigmentBeautyParaEntities();

        // GET: MemberReivews
        public ActionResult Index()
        {
            var memberReivews = db.MemberReivews.Include(m => m.AspNetUser).Include(m => m.BeautyProduct);
            return View(memberReivews.ToList());
        }

        // GET: MemberReivews/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberReivew memberReivew = db.MemberReivews.Find(id);
            if (memberReivew == null)
            {
                return HttpNotFound();
            }
            return View(memberReivew);
        }

        // GET: MemberReivews/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.PrdouctID = new SelectList(db.BeautyProducts, "ProductID", "ProductName");
            return View();
        }

        public ActionResult Products()
        {
            return RedirectToAction("Index", "BeautyProducts");
        }

        // POST: MemberReivews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,CustomerID,PrdouctID,SuggesstionText")] MemberReivew memberReivew)
        {
            if (ModelState.IsValid)
            {
                db.MemberReivews.Add(memberReivew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", memberReivew.CustomerID);
            ViewBag.PrdouctID = new SelectList(db.BeautyProducts, "ProductID", "ProductName", memberReivew.PrdouctID);
            return View(memberReivew);
        }

        // GET: MemberReivews/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberReivew memberReivew = db.MemberReivews.Find(id);
            if (memberReivew == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", memberReivew.CustomerID);
            ViewBag.PrdouctID = new SelectList(db.BeautyProducts, "ProductID", "ProductName", memberReivew.PrdouctID);
            return View(memberReivew);
        }

        // POST: MemberReivews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,CustomerID,PrdouctID,SuggesstionText")] MemberReivew memberReivew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberReivew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", memberReivew.CustomerID);
            ViewBag.PrdouctID = new SelectList(db.BeautyProducts, "ProductID", "ProductName", memberReivew.PrdouctID);
            return View(memberReivew);
        }

        // GET: MemberReivews/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberReivew memberReivew = db.MemberReivews.Find(id);
            if (memberReivew == null)
            {
                return HttpNotFound();
            }
            return View(memberReivew);
        }

        // POST: MemberReivews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MemberReivew memberReivew = db.MemberReivews.Find(id);
            db.MemberReivews.Remove(memberReivew);
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
