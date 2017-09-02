using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    // Class is implemented as Custom Validation for birthdate
    // Derive class from ValidationAttribute defined by System.ComponentModel.DataAnnotations;
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // override isValid with two overloads to access the customer validation
        // Before creating the validtion logic, implement the Min18YearsIfAMember validation to Model
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Give access to the containting class - customer (need to cast the customer)
            var customer = (Customer)validationContext.ObjectInstance;

            // Check selected membership type (0 - no value || 1 - Pay as you go) - validation is success
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            // Check if birthdate is null
            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            // if age >= 18 , return validationresult.success, if not return the string validation message below
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be 18 years old to go on a membership.");
        }
    }
}