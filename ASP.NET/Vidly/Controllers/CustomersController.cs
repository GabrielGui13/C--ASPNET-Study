using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customerList = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Mary Willians" }
        };
        // GET: Customers
        public ActionResult Index() {
            var viewModel = new IndexCustomerViewModel
            {
                Customers = customerList
            };

            return View(viewModel);
        }
        public ActionResult Details(long id)
        {
            var viewModel = new IndexCustomerViewModel
            {
                Customers = customerList
            };

            if (id > viewModel.Customers.Count) return HttpNotFound();

            return View(viewModel.Customers[(int)id - 1]);
        }
    }
}