using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Data.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="Hindi Language")]
        Hindi=1,
        [Display(Name = "English Language")]
        English,
        [Display(Name = "Dutch Language")]
        Dutch,
        [Display(Name = "Marathi Language")]
        Marathi
    }
}
