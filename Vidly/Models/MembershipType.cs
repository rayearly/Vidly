using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        // Uses byte as a primary key since there is only a few membership type
        public byte Id { get; set; }

        // Use short because don't need value more than 32000
        public short SignUpFee { get; set; }

        // Uses byte because the largest number need to store is 12 - for 12 months
        public byte DurationInMonths { get; set; }

        // Uses byte because it is in percentage 0% - 100% in range
        public byte DiscountRate { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

    }
}