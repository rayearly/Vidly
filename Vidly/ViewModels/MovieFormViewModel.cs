using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenres { get; set; }

        [Key]
        public int? Id { get; set; }

        // Pure ViewModel - Replace the Movie movie instance right here with properties that is needed
        // Make all needed properties nullable, string is nullable by default. others place ? sign to make it nullable
        // DateAdded is not needed as it is not involved in the form, Genre is also not needed as the one needed is GenreId

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public byte? StockQuantity { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? MovieGenreId { get; set; }

        // Customize the title of the MovieForm "Edit Movie" if movie exist. & "New Movie" if movie exist.
        public string Title
        {
            get
            {
                // Movie is removed, so need to modify title accordingly
                // if id is not zero, title = edit movie, and if yes = new movie
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        // Default constructor creating new movie
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            StockQuantity = movie.StockQuantity;
            MovieGenreId = movie.MovieGenreId;
        }
    
    }
}