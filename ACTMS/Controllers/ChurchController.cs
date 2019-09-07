using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ACTMS.Models;
using ACTMS.ViewModels;

namespace ACTMS.Controllers
{
    public class ChurchController : Controller
    {
       

        private ApplicationDbContext _context;

        public ChurchController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var provinces = _context.Provinces.ToList();
            var ViewModel = new NewChurchViewModel
            {
                Provinces = provinces
            };
            return View("ChurchForm", ViewModel);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Church church)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewChurchViewModel
                {
                    Church = church,
                    //MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("ChurchForm", viewModel);
            }
            if (church.Id == 0)
                _context.churches.Add(church);
            else
            {

                var churchInDb = _context.churches.Single(c => c.Id == church.Id);
                churchInDb.Name = church.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Church");
            //  return View();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var church = _context.churches.Include(c => c.Province).SingleOrDefault(c => c.Id == id);

            if (church == null)
                return HttpNotFound();

            return View(church);
        }

        public ActionResult Edit(int id)
        {
            var church = _context.churches.SingleOrDefault(c => c.Id == id);

            if (church == null)
                return HttpNotFound();

            var viewModel = new NewChurchViewModel
            {
                Church = church,
                //MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("ChurchForm", viewModel);
        }
    }


}