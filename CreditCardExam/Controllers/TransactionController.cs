using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CreditCardExam.Models;

namespace CreditCardExam.Controllers
{
    public class TransactionController : Controller
    {
        private CreditCardDbContext db = new CreditCardDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            return View(Repository.getTransactions());
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCTrans cCTrans = db.transactions.Find(id);
            if (cCTrans == null)
            {
                return HttpNotFound();
            }
            return View(cCTrans);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,transDate,transDesc,transAmount,CustomerId")] CCTrans cCTrans)
        {
            if (ModelState.IsValid)
            {
                db.transactions.Add(cCTrans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cCTrans);
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCTrans cCTrans = db.transactions.Find(id);
            if (cCTrans == null)
            {
                return HttpNotFound();
            }
            return View(cCTrans);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,transDate,transDesc,transAmount,CustomerId")] CCTrans cCTrans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cCTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cCTrans);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCTrans cCTrans = db.transactions.Find(id);
            if (cCTrans == null)
            {
                return HttpNotFound();
            }
            return View(cCTrans);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CCTrans cCTrans = db.transactions.Find(id);
            db.transactions.Remove(cCTrans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditTransaction(int Id, string transDesc)
        {
            Repository.updateTransDesc(Id, transDesc);
            return RedirectToAction("Everything", "Customer",new { Id = Id });
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
