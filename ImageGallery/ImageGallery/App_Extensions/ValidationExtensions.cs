using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery
{
    public static class ValidationExtensions
    {
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults)
        {
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, new ValidationContext(instance), validationResults, true);
        }
    }
}