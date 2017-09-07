using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

/*
 * You can test the APIs using Tabbed Postman - REST Client extension in chrome. 
 * Make sure that you set the GET/POST/PUT/DELETE to what which function you want to use in the API. 
 * In the field that you want to paste the JSON form of data, make sure you select the raw tab, and select JSON as the data convention you wanted to use.
 * Set the Header = content-type & Value = application/json, so that it can receive data you wanted to create or referring to through the API. 
 */
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            // Delegating / Referencing to the Object
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            // passing the customer variable to the mapped Customer object. 
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        // Use httppost Tag to make sure this is the function used when we want to create new customer
        // Returning the object (Customer) themselves in the API
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            // Check validation is false - throw exception
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Map Dto back to the main object (Customer)
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Add Id to the Dto and return it to the client (As the returning CustomerDto will not have Id since it is not included?)
            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/1
        // Can return both Customer object or Void, both works.
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        { 
            // Check validation is false - throw exception
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Get the customer referenced to in database
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // Check if customer referenced does not exist - throw exception
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            
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
