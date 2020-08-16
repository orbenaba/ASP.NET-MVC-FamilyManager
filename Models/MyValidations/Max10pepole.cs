using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models.MyValidations
{
    //Enforcing the non-functional requirement which says 
    //that at one family there are can be at the most 10 pepole
    public class Max10pepole:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var family =(Family)validationContext.ObjectInstance;
            return family.counter <= MagicNumbers.LimitPepole1Family ?
                        ValidationResult.Success :
                        new ValidationResult("One family can contains at the most 10 pepole.");

        }
    }
}