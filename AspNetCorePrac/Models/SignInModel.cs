using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

    }
}
