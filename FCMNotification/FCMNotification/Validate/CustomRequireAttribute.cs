using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FCMNotification.Validate
{
    public class CustomRequireAttribute : ValidationAttribute
    {
        string otherPropertyName;
        public CustomRequireAttribute(string otherPropertyName, string errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        public string[] PropertyNames { get; private set; }
        public int MinLength { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success; 
            //try
            //{
            //    // Using reflection we can get a reference to the other date property, in this example the project start date
            //    var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);                
            //    // Let's check that otherProperty is of type DateTime as we expect it to be
            //    if (otherPropertyInfo.GetValue(validationContext) as string == "1")
            //    {
            //        DateTime toValidate = (DateTime)value;
            //        DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);                    
            //        // if the end date is lower than the start date, than the validationResult will be set to false and return
            //        // a properly formatted error message
            //        if (value.ToString() == string.Empty)
            //        {
            //            //string message = FormatErrorMessage(validationContext.DisplayName);
            //            //validationResult = new ValidationResult(message);
            //            validationResult = new ValidationResult(ErrorMessageString);
            //        }
            //    }
            //    else
            //    {
            //        validationResult = new ValidationResult("An error occurred while validating the property. OtherProperty is not of type DateTime");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Do stuff, i.e. log the exception
            //    // Let it go through the upper levels, something bad happened
            //    throw ex;
            //}

            return validationResult;
        }
    }

    public class CustomEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please Enter a Valid Email.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}