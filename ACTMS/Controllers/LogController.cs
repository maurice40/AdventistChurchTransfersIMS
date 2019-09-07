using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACTMS.Models;
using System.Diagnostics;

namespace ACTMS.Controllers
{
    public class LogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public LogController()  
        {  
            db.Database.Log = l => Debug.Write(l);  
        } 

        // GET: /Log/
        public ActionResult Index()
        {
            return View(db.Logs.ToList());
        }

        // GET: /Log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // GET: /Log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TimeHappened,Action,level")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                db.Logs.Add(logs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logs);
        }

        // GET: /Log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // POST: /Log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TimeHappened,Action,level")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logs);
        }

        // GET: /Log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // POST: /Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logs logs = db.Logs.Find(id);
            db.Logs.Remove(logs);
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
