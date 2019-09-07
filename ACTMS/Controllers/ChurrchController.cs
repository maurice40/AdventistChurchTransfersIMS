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
    public class ChurrchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Churrch/
        public ActionResult Index()
        {
            var churrches = db.Churrches.Include(c => c.Province);
            return View(churrches.ToList());
        }

        // GET: /Churrch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Churrch churrch = db.Churrches.Find(id);
            if (churrch == null)
            {
                return HttpNotFound();
            }
            return View(churrch);
        }

        // GET: /Churrch/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Provinces, "id", "Name");
            return View();
        }

        // POST: /Churrch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Location,Contact,ProvinceId")] Churrch churrch)
        {
            if (ModelState.IsValid)
            {
                db.Churrches.Add(churrch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Provinces, "id", "Name", churrch.ProvinceId);
            return View(churrch);
        }

        // GET: /Churrch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Churrch churrch = db.Churrches.Find(id);
            if (churrch == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "id", "Name", churrch.ProvinceId);
            return View(churrch);
        }

        // POST: /Churrch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Location,Contact,ProvinceId")] Churrch churrch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(churrch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "id", "Name", churrch.ProvinceId);
            return View(churrch);
        }

        // GET: /Churrch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Churrch churrch = db.Churrches.Find(id);
            if (churrch == null)
            {
                return HttpNotFound();
            }
            return View(churrch);
        }

        // POST: /Churrch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Churrch churrch = db.Churrches.Find(id);
            db.Churrches.Remove(churrch);
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
