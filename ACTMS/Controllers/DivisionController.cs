using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACTMS.Models;
using ACTMS.ViewModels;

namespace ACTMS.Controllers
{
	public class DivisionController : Controller
	{
	

		private ApplicationDbContext _context;

		public DivisionController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			return View();
		}

		/*[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};

				return View("CustomerForm", viewModel);
			}

			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}
		*/
		public ViewResult Index()
		{
			var divisions = _context.Divisions.ToList();
			//var divisions = GetDivisions();
			return View(divisions);
		}

		public ActionResult Details(int id)
		{
			var division = _context.Divisions.SingleOrDefault(c=> c.Id == id);

			if (division == null)
				return HttpNotFound();

			return View(division);
		}
		public ActionResult Create(Division Division)
		{
			_context.Divisions.Add(Division);
			_context.SaveChanges();
			return RedirectToAction("Index", "Division");
			//  return View();
		}

	/*	public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}
		
		private IEnumerable<Division> GetDivisions()
		{
			return new List<Division>
			{
				new Division {Name ="EAST"},
				new Division {Name ="WEST"},
				new Division {Name ="SOUTH"},
				new Division {Name ="NORTH"},
				new Division {Name ="KIGALI"}

			};

		}
	 */
	}
}