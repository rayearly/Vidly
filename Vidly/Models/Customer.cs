using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        // Navigation Property - Customer to MembershipType
        public MembershipType MembershipType { get; set; }

        // Foreign Key for MembershipType table - EF recognized this (MembershipType and MembershipTypeId) convention and treat it as FK
        public byte MembershipTypeId { get; set; }
    }
}