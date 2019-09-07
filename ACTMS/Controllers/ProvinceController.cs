using ACTMS.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACTMS.ViewModels;

namespace ACTMS.Controllers
{
	public class ProvinceController : Controller
	{
		//
		// GET: /Province/
		private ApplicationDbContext _context;

		public ProvinceController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ViewResult Index()
		{
			var provinces = _context.Provinces.Include( c => c.Division).ToList();
			return View(provinces);
		}
		public ActionResult Details(int id)
		{
			var province = _context.Provinces.SingleOrDefault(c => c.id == id);
			if (province == null)
				return HttpNotFound();

			return View(province);
		}
		public ActionResult New()
		{
			var divisions = _context.Divisions.ToList();
			var viewModel = new ProvinceFormViewModel
			{
				Divisions = divisions
			};

			return View(viewModel);
		}
		[HttpPost]
		public ActionResult Save(Province Province)
		{
			if (Province.id ==0)
			_context.Provinces.Add(Province);
			else
			{
				var provinceInDb = _context.Provinces.Single(c => c.id == Province.id);
				//TryUpdateModel(provinceInDb);
				provinceInDb.Name = Province.Name;
				provinceInDb.DivisionId = Province.DivisionId;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Province");
		  //  return View();
		}
		public ActionResult Edit(int id)
		{
			var province = _context.Provinces.SingleOrDefault(c => c.id == id);
			if (province == null)
				return HttpNotFound();

			var viewModel = new ProvinceFormViewModel()
			{
				Province = province,
				Divisions = _context.Divisions.ToList()

			};
			return View("ProvinceForm", viewModel);
		}
	}
}
