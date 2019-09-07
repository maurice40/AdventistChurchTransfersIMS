using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACTMS.Models;

namespace ACTMS.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Transfer/
        public ActionResult Index()
        {
            var transfers = db.Transfers.Include(t => t.Christian).Include(t => t.Churrch).Include(t => t.TransferReason);
            return View(transfers.ToList());
        }

        // GET: /Transfer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // GET: /Transfer/Create
        public ActionResult Create()
        {
            ViewBag.ChristianId = new SelectList(db.christians, "Id", "Firstname");
            ViewBag.ChurrchId = new SelectList(db.Churrches, "Id", "Name");
            ViewBag.TransferReasonId = new SelectList(db.TransferReasons, "Id", "Name");
            return View();
        }

        // POST: /Transfer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Comment,Added_at,Status,TransferReasonId,ChristianId,ChurrchId")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                db.Transfers.Add(transfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChristianId = new SelectList(db.christians, "Id", "Firstname", transfer.ChristianId);
            ViewBag.ChurrchId = new SelectList(db.Churrches, "Id", "Name", transfer.ChurrchId);
            ViewBag.TransferReasonId = new SelectList(db.TransferReasons, "Id", "Name", transfer.TransferReasonId);
            return View(transfer);
        }

        // GET: /Transfer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChristianId = new SelectList(db.christians, "Id", "Firstname", transfer.ChristianId);
            ViewBag.ChurrchId = new SelectList(db.Churrches, "Id", "Name", transfer.ChurrchId);
            ViewBag.TransferReasonId = new SelectList(db.TransferReasons, "Id", "Name", transfer.TransferReasonId);
            return View(transfer);
        }

        // POST: /Transfer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Comment,Added_at,Status,TransferReasonId,ChristianId,ChurrchId")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChristianId = new SelectList(db.christians, "Id", "Firstname", transfer.ChristianId);
            ViewBag.ChurrchId = new SelectList(db.Churrches, "Id", "Name", transfer.ChurrchId);
            ViewBag.TransferReasonId = new SelectList(db.TransferReasons, "Id", "Name", transfer.TransferReasonId);
            return View(transfer);
        }

        // GET: /Transfer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // POST: /Transfer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfer transfer = db.Transfers.Find(id);
            db.Transfers.Remove(transfer);
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
