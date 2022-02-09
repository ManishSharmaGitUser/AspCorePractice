﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Models
{
    public class PasswordUpdateModel
    {
        [Required,DataType(DataType.Password),Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("NewPassword",ErrorMessage ="confirm new password does not match")]
        public string ConfirmNewPassword { get; set; }

    }
}
