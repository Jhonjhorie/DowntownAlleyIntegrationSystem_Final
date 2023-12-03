using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBIT3J_SuperSystem.Models;

namespace SBIT3J_SuperSystem.Controllers.Inventorymanagement
{
    public class RestockDetailsController : Controller
    {
        private SBIT3JEntities db = new SBIT3JEntities();

        // GET: RestockDetails
        public ActionResult Index()
        {
            var restockDetails = db.RestockDetails.Include(r => r.Product).Include(r => r.Restock);
            return View(restockDetails.ToList());
        }

        // GET: RestockDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestockDetail restockDetail = db.RestockDetails.Find(id);
            if (restockDetail == null)
            {
                return HttpNotFound();
            }
            return View(restockDetail);
        }

        // GET: RestockDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode");
            ViewBag.RestockID = new SelectList(db.Restocks, "RestockID", "RestockID");
            return View();
        }

        // POST: RestockDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestockDetailID,RestockID,ProductID,QuantityAdded,TotalAmount")] RestockDetail restockDetail)
        {
            if (ModelState.IsValid)
            {
                db.RestockDetails.Add(restockDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", restockDetail.ProductID);
            ViewBag.RestockID = new SelectList(db.Restocks, "RestockID", "RestockID", restockDetail.RestockID);
            return View(restockDetail);
        }

        // GET: RestockDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestockDetail restockDetail = db.RestockDetails.Find(id);
            if (restockDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", restockDetail.ProductID);
            ViewBag.RestockID = new SelectList(db.Restocks, "RestockID", "RestockID", restockDetail.RestockID);
            return View(restockDetail);
        }

        // POST: RestockDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestockDetailID,RestockID,ProductID,QuantityAdded,TotalAmount")] RestockDetail restockDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restockDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", restockDetail.ProductID);
            ViewBag.RestockID = new SelectList(db.Restocks, "RestockID", "RestockID", restockDetail.RestockID);
            return View(restockDetail);
        }

        // GET: RestockDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestockDetail restockDetail = db.RestockDetails.Find(id);
            if (restockDetail == null)
            {
                return HttpNotFound();
            }
            return View(restockDetail);
        }

        // POST: RestockDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestockDetail restockDetail = db.RestockDetails.Find(id);
            db.RestockDetails.Remove(restockDetail);
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
