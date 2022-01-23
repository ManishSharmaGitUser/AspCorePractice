using AspNetCorePrac.Data.Enums;
using AspNetCorePrac.Helper;
using Microsoft.AspNetCore.Http;
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
        //[Required(ErrorMessage ="Please Enter Title")]
        //[StringLength(100 , MinimumLength =5,ErrorMessage ="Title Length Must be 5 to 100")]
        [MyCustomValidation("manish",ErrorMessage ="Field Must Contain name manish")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Author Name")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Please Eneter Description")]
        public string Description { get; set; }

        [Display(Name ="Total Pages")]
        [Required(ErrorMessage ="Please Enter Pages")]
        public int? TotalPages { get; set; }
        [Required(ErrorMessage ="Please choose book Language")]
        public int? LanguageId { get; set; }
        public string Language { get; set; }


        //[Required(ErrorMessage = "Please choose book Languages")]
        //public List<string> MultiLanguage { get; set; }

        //[Required(ErrorMessage = "Please choose book Languages")]
        //public LanguageEnum? LanguageEnm { get; set; }

        [Display(Name ="Choose the cover Photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        //below is for multiple uploading of images
        [Display(Name = "Choose the Photos")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
    }
}
