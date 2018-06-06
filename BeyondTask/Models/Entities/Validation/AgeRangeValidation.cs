using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeyondTask.Models.Entities.Validation
{
    class AgeRangeValidation : ValidationAttribute, IClientModelValidator
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val-custom-AgeRangeValidation",
                    FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
            MergeAttribute(context.Attributes, "data-val-custom-verifyage-validationcallback", "AgeRangeValidation");
        }
        bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //THIS IS FOR SERVER SIDE VALIDATION

            // if value not supplied then no error return
            if (value == null)
            {
                return null;
            }

            int age = 0;
            age = DateTime.Now.Year - Convert.ToDateTime(value).Year;
            if (age >= MinAge && age <= MaxAge)
            {
                return ValidationResult.Success; // Validation success
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                // error 
            }
        } // end method IsValid

    }
}
