using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please Enter Email Address")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter A Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please Retype your Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password Do not matched")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
