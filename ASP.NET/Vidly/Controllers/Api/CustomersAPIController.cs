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
using Vidly.Dtos;
using Vidly.ViewModels;
using Vidly.Context;
using AutoMapper;
using System.Data.Entity;

//controller normal
//baixar as dependencias webhost e webapi
//um arquivo webapiconfig.cs precisa ser criado em App_Start
//precisa inicializar a config de web api em Global.asax
//dependencias importantes => System.Net; System.Net.Http; System.Web; System.Web.Http; System.Web.Optimization; System.Web.Routing;
//usar IHttpActionResult para retornar o json pois tem como usar o codigo http e inserir headers

//automapper
// baixar a dependencia automapper -version:4.1.0
//criar o arquivo mappingprofile no app_start e criar os mapeamentos
//inicializar o profile no Global.asax
//apos isso pode usar normal

namespace Vidly.Controllers
{
    //works because we created a WebApiConfig.cs in App_start and initialized in Global.asax
    public class CustomersAPIController : ApiController //works like an api because inherit ApiController
    {
        private EFContext db;

        public CustomersAPIController()
        {
            db = new EFContext();
        }

        // GET api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return db.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound); //HttpStatusCode derives from System.Net;
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST api/customers
        [HttpPost] //CustomersController => System.Web.Mvc / Here => System.Web.Http
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) //id from url and customer from req body
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

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