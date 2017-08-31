using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // 1st, create dbcontext to access database
        private ApplicationDbContext _context;

        // 2nd Initialise the dbcontext
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // 3rd, disposes the dbcontext here after usage?
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // .ToList is a query listing out the movies we have in database.
        public ViewResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek"},
                new Movie { Id = 2, Name = "Wall-E"}
            };
        }
    }
}
