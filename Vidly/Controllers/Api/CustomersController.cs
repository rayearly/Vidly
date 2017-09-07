using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/customers
        // Use httppost Tag to make sure this is the function used when we want to create new customer
        // Returning the object (Customer) themselves in the API
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            // Check validation is false - throw exception
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT /api/customers/1
        // Can return both Customer object or Void, both works.
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        { 
            // Check validation is false - throw exception
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Get the customer referenced to in database
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // Check if customer referenced does not exist - throw exception
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Else update in database - can use AutoMapper in the future if there is a lot of attribute
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // Get the customer referenced to in database
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // Check if customer referenced does not exist - throw exception
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Else Delete the referenced customer
            _context.Customers.Remove(customerInDb);

            // Persist changes
            _context.SaveChanges();
        }
    }
}
