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
    public class AttachmentController : Controller
    {
        private AttachmentContext db = new AttachmentContext();
        public AttachmentController()  
        {  
            db.Database.Log = l => Debug.Write(l);  
        } 

        // GET: /Attachment/
        public ActionResult Index()
        {
            return View(db.Attachments.ToList());
        }

        // GET: /Attachment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: /Attachment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Attachment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,AUrl,Status")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attachment);
        }

        // GET: /Attachment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: /Attachment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,AUrl,Status")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attachment);
        }

        // GET: /Attachment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: /Attachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attachment attachment = db.Attachments.Find(id);
            db.Attachments.Remove(attachment);
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
