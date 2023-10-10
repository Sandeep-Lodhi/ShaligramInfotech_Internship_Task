using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice1
{
    public class ValidationsForKrunal:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (message.Contains("Krunal"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Field Must Contains Krunal");
        }
    }
}