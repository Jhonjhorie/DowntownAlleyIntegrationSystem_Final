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
    public class ReturnsRefundsController : Controller
    {
        private SBIT3JEntities db = new SBIT3JEntities();

        // GET: ReturnsRefunds
        public ActionResult Index()
        {
            var returnsRefunds = db.ReturnsRefunds.Include(r => r.Product).Include(r => r.SalesTransaction);
            return View(returnsRefunds.ToList());
        }

        // GET: ReturnsRefunds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsRefund returnsRefund = db.ReturnsRefunds.Find(id);
            if (returnsRefund == null)
            {
                return HttpNotFound();
            }
            return View(returnsRefund);
        }

        // GET: ReturnsRefunds/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode");
            ViewBag.TransactionID = new SelectList(db.SalesTransactions, "TransactionID", "ReceiptInfo");
            return View();
        }

        // POST: ReturnsRefunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReturnID,TransactionID,ProductID,ReturnDate,QuantityReturned,Reason,Resellable,CustomerName")] ReturnsRefund returnsRefund)
        {
            if (ModelState.IsValid)
            {
                db.ReturnsRefunds.Add(returnsRefund);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", returnsRefund.ProductID);
            ViewBag.TransactionID = new SelectList(db.SalesTransactions, "TransactionID", "ReceiptInfo", returnsRefund.TransactionID);
            return View(returnsRefund);
        }

        // GET: ReturnsRefunds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsRefund returnsRefund = db.ReturnsRefunds.Find(id);
            if (returnsRefund == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", returnsRefund.ProductID);
            ViewBag.TransactionID = new SelectList(db.SalesTransactions, "TransactionID", "ReceiptInfo", returnsRefund.TransactionID);
            return View(returnsRefund);
        }

        // POST: ReturnsRefunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReturnID,TransactionID,ProductID,ReturnDate,QuantityReturned,Reason,Resellable,CustomerName")] ReturnsRefund returnsRefund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnsRefund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", returnsRefund.ProductID);
            ViewBag.TransactionID = new SelectList(db.SalesTransactions, "TransactionID", "ReceiptInfo", returnsRefund.TransactionID);
            return View(returnsRefund);
        }

        // GET: ReturnsRefunds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsRefund returnsRefund = db.ReturnsRefunds.Find(id);
            if (returnsRefund == null)
            {
                return HttpNotFound();
            }
            return View(returnsRefund);
        }

        // POST: ReturnsRefunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnsRefund returnsRefund = db.ReturnsRefunds.Find(id);
            db.ReturnsRefunds.Remove(returnsRefund);
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
