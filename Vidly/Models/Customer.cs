using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // Data Annotation to Override Convention
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        // Navigation Property - Customer to MembershipType
        public MembershipType MembershipType { get; set; }

        // Foreign Key for MembershipType table - EF recognized this (MembershipType and MembershipTypeId) convention and treat it as FK
        public byte MembershipTypeId { get; set; }

        // Nullable DateTime is using ?
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}