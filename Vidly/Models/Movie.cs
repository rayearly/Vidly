using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display (Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display (Name = "Number in Stock")]
        public byte StockQuantity { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        // Get rid of the required attribute here so that it is not a MUST during the ADD/UPDATE data
        public MovieGenre MovieGenre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte MovieGenreId { get; set; }

    }
}