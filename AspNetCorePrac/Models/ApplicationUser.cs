using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Models
{
    public class ApplicationUser : IdentityUser
    {
        //here by using this Application User Class extending AspNetUsers Table columns
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
