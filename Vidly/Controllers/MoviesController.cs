using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};

            // Assign data to viewdata
            ViewData["Movie"] = movie;

            // Assign data to viewbag
            ViewBag.RandomMovie = movie;

            return View();
        }

        // Activate the Attribute Routing in RouteConfig and define the routing with the constraint (min, max, minlength, maxlength, int, float, guid, range) here.
        // Google ASP.NET MVC Attribute Route Constraint for details.
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}