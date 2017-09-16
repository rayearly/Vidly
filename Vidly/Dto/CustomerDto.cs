using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // Display attribute is not required as it is for the view. This is for the API (data display only)
        public bool IsSubscribedToNewsletter { get; set; }

        // Remove MembershipType as it is a model class, and it create dependency to the model class

        public byte MembershipTypeId { get; set; }

        // Set here because want to display membership type using API - but build new Dto for this object
        public MembershipTypeDto MembershipType { get; set;}

        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}