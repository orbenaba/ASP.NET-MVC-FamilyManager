using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models.MyValidations
{
    public class Min18Yearsold:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.Name == "Parent")
            {
                var parent = (Parent)validationContext.ObjectInstance;
                if (parent.BirthDate!=null)
                {
                    var birthdate = parent.BirthDate.Value;
                    var currentdate = DateTime.Now;
                    return currentdate.Year - birthdate.Year > 18 ||
                        (currentdate.Year - birthdate.Year == 18 && currentdate.Month > birthdate.Month) ||
                        (currentdate.Year - birthdate.Year == 18 &&
                        currentdate.Month == birthdate.Month && currentdate.Day >= birthdate.Day) ?
                        ValidationResult.Success :
                        new ValidationResult("You should be at least 18 YO in order to be a parent");
                }
                else
                {
                    return new ValidationResult("Birthdate field is required.");
                }
            }
            return ValidationResult.Success;
        }                                              
    }                                        
}                                                                               