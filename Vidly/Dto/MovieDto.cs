using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class MovieDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public byte StockQuantity { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }
    }
}