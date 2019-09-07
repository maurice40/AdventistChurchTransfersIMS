using ACTMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACTMS.Controllers
{
    public class StatusController : Controller
    {
        //
        // GET: /Status/
        private ApplicationDbContext _context;

        public StatusController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var statuses = _context.Statuses.ToList();
            return View(statuses);
        }
        public ActionResult Details(int id)
        {
            var status = _context.Statuses.SingleOrDefault(c => c.Id == id);
            if (status == null)
                return HttpNotFound();

            return View(status);
        }


        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
            return RedirectToAction("Index", "Status");
          //  return View();
        }
    }
}