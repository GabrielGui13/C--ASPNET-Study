using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var customers = _context.Customers.ToList();

            var viewModel = new IndexCustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
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