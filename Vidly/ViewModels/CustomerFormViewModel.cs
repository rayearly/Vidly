using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    // ViewModel created to encapsulate all the data required by the field
    public class CustomerFormViewModel
    {
        // Better use IEnumberable to allow loosley coupled code
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}