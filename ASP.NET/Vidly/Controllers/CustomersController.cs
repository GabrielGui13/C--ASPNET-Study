using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Context;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private EFContext _context;

        public CustomersController()
        {
            _context = new EFContext();
        }

        // GET: Customers
        public ActionResult Index() {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //include is necessary to access membershiptype (foreign relationship) attributes, is called eager loading

            return View(customers);
        }
        public ActionResult Details(long id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}