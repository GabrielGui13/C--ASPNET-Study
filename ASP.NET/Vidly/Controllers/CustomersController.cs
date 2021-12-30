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
        private EFContext db;

        public CustomersController()
        {
            db = new EFContext();
        }

        // GET: Customers
        public ActionResult Index() {
            var customers = db.Customers.Include(c => c.MembershipType).ToList(); //include is necessary to access membershiptype (foreign relationship) attributes, is called eager loading

            return View(customers);
        }
        public ActionResult Details(long id)
        {
            var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = db.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //default values
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost] //can only be called with post
        [ValidateAntiForgeryToken] //used to prevent request data hack attack called CSRF attack, needs Html.AntiForgeryToken inside the form
        public ActionResult Save(Customer customer) //bind the model to request data
        {
            if (!ModelState.IsValid) //validation based on data annotations in model
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer, //populate the form with values included in request data
                    MembershipTypes = db.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel); //basically the same as edit controller, but it's not full
            }

            if (customer.Id == 0) //it means it's creating a new one (id is not selected in form)
                db.Customers.Add(customer);
            else
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                
                //could use a library called AutoMapper to ease
                // Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}