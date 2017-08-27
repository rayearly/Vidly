using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Need dbcontext to access the database
        private ApplicationDbContext _context;

        // Initialize dbcontext here in constructor - ctor tab
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // dbcontext is a disposable object - here is the way
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            // Get Customers in database, but queried in View (here using razor syntax)
            var customers = _context.Customers;

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // Query is immediately executed by singleordefault here.
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}