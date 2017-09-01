﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            // passing membershipTypes directly to the view can be done but it will not work later when we implement editing a customer. 
            // Because editing require us to pass customer object to the field.
            // In this situation, we create a ViewModel that encapsulate the data required in the field
            var membershipTypes = _context.MembershipTypes.ToList();

            // set the MembershipTypes viewmodel to the list of membership from membership table
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        //Making sure that it can only be called by HttpPost not HttpGet - Post VS Get (best practices)
        //Put and get rid Breakpoint using F9 and run debug mode with F5, stop debugger SHIFT + F5
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // RedirectToAction(Page, Controller);
            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            /* 
               - Get Customers in database, but queried in View (here using razor syntax)
               - .Include(c => c.MembershipType) is to enable the eager loading. Include the related object.
               - To use, import System.Data.Entity
               - Eager loading - loading Customer object together with its related object MembershipType
            */
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // Query is immediately executed by singleordefault here.
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            // Change the class name by placing the cursor on its name, press F2 and all will change automatically
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}