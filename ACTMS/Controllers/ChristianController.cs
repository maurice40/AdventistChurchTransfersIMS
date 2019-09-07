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
    public class ChristianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Christian/
        public ActionResult Index()
        {
            var christians = db.christians.Include(c => c.Church).Include(c => c.Status);
            return View(christians.ToList());
        }

        // GET: /Christian/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Christian christian = db.christians.Find(id);
            if (christian == null)
            {
                return HttpNotFound();
            }
            return View(christian);
        }

        // GET: /Christian/Create
        public ActionResult Create()
        {
            ViewBag.ChurchId = new SelectList(db.churches, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            return View();
        }

        // POST: /Christian/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Firstname,Lastname,BirthYear,Sex,Father,Mother,MartalStatus,BaptismYear,Photo,Phone,Email,Location,StatusId,ChurchId")] Christian christian)
        {
            if (ModelState.IsValid)
            {
                db.christians.Add(christian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChurchId = new SelectList(db.churches, "Id", "Name", christian.ChurchId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", christian.StatusId);
            return View(christian);
        }

        // GET: /Christian/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Christian christian = db.christians.Find(id);
            if (christian == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChurchId = new SelectList(db.churches, "Id", "Name", christian.ChurchId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", christian.StatusId);
            return View(christian);
        }

        // POST: /Christian/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Firstname,Lastname,BirthYear,Sex,Father,Mother,MartalStatus,BaptismYear,Photo,Phone,Email,Location,StatusId,ChurchId")] Christian christian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(christian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChurchId = new SelectList(db.churches, "Id", "Name", christian.ChurchId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", christian.StatusId);
            return View(christian);
        }

        // GET: /Christian/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Christian christian = db.christians.Find(id);
            if (christian == null)
            {
                return HttpNotFound();
            }
            return View(christian);
        }

        // POST: /Christian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Christian christian = db.christians.Find(id);
            db.christians.Remove(christian);
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
