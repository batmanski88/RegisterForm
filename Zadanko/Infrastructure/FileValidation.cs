using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadanko.Infrastructure
{
    public class FileValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                byte[] File = (byte[])value;
                int maxFileSize = 2;

                if(File.Length <= maxFileSize * 1048576)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Rozmiar pliku jest za duży");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " jest wymagane");
            }
        }
    }
}