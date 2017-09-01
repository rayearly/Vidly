using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenres { get; set; }
        public Movie Movie { get; set; }

        // Customize the title of the MovieForm "Edit Movie" if movie exist. & "New Movie" if movie exist.
        public string Title
         {
             get
             {
                 if (Movie != null && Movie.Id != 0)
                     return "Edit Movie";
 
                 return "New Movie";
             }
         }
    
    }
}