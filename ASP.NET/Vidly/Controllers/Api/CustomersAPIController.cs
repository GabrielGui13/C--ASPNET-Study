using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Context;

//controller normal
//baixar as dependencias webhost e webapi
//precisa inicializar a config de web api em Global.asax
//um arquivo webapiconfig.cs precisa ser criado em App_Start
//dependencias importantes => System.Net; System.Net.Http; System.Web; System.Web.Http; System.Web.Optimization; System.Web.Routing;

namespace Vidly.Controllers
{
    //works because we created a WebApiConfig.cs in App_start and initialized in Global.asax
    public class CustomersAPIController : ApiController
    {
        private EFContext db;

        public CustomersAPIController()
        {
            db = new EFContext();
        }

        // GET api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) throw new HttpResponseException(HttpStatusCode.NotFound); //HttpStatusCode derives from System.Net;

            return customer;
        }

        // POST api/customers
        [HttpPost] //CustomersController => System.Web.Mvc / Here => System.Web.Http
        public Customer CreateCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer) //id from url and customer from req body
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            db.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customerInDb);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}