using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Helper
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public string Text { get; set; }

        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string bookname = value.ToString();
                if (bookname.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Value is empty");
        }
    }
}
