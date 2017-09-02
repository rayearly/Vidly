using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Vidly.ViewModels;

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
            var movies = _context.Movies.Include(c => c.MovieGenre).ToList();

            return View(movies);
        }

        // Redirect to New Customer form but pass the Movie Genre to display it in the genre selection
        public ActionResult New()
        {
            var movieGenres = _context.MovieGenres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                MovieGenres = movieGenres
            };

            return View("MovieForm", viewModel);
        }

        // Redirect to Edit page based on id given
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View ("MovieForm", viewModel);
        }

        // Use class to both ADD NEW CUSTOMER & UPDATE CUSTOMER
        // Only use customer class so no membershiptype class passed here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            // Implement Validation - check if valid
            if (!ModelState.IsValid)
            {
                // Create instance for viewmodel to re-display the inputted data by user & redirect them back to Movie form
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    MovieGenres = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            // If new customer
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.StockQuantity = movie.StockQuantity;
            }

            // Implement try catch to check for validation problem
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                // Put breakpoint here to see what is the error in validation
                Console.WriteLine(e);    
            }

            return RedirectToAction("Index", "Movies");
        }

        // Display Movie Details
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        
    }
}
