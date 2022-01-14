using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Title")]
        [StringLength(100 , MinimumLength =5,ErrorMessage ="Title Length Must be 5 to 100")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Author Name")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Please Eneter Description")]
        public string Description { get; set; }

        [Display(Name ="Total Pages")]
        [Required(ErrorMessage ="Please Enter Pages")]
        public int? TotalPages { get; set; }
        [Required(ErrorMessage ="Please choose book Language")]
        public string Language { get; set; }
    }
}
