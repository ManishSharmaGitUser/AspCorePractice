using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePrac.Models;
using AspNetCorePrac.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCorePrac.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository,LanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> GetAllbooks()
        {
           var data =await _bookRepository.GetAllBooks();
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewBook(bool issuccess =false)
        {
            // BookModel bookModel = new BookModel {Language="English" };
            //ViewBag.Language = new List<string>() { "Hindi", "English" ,"Dutch" };


            //BookModel bookModel = new BookModel { Id = 1 }; to select this on view on loading and pass this model to View from here
            //ViewBag.Language = new SelectList(GetLanguage(),"Id","Text");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem() { Text = x.Text,Value=x.Id.ToString() }).ToList();

            //ViewBag.Language = new List<SelectListItem>() { 
            //      new SelectListItem { Text = "English" ,Value = "1" },
            //      new SelectListItem { Text = "Hindi" ,Value = "2" ,Selected=true },
            //      new SelectListItem { Text = "Dutch" ,Value = "3" ,Disabled=true }
            //};


            //var group1 = new SelectListGroup() { Name = "grp1" };
            //var group2 = new SelectListGroup() { Name = "grp2" ,Disabled=true };
            //var group3 = new SelectListGroup() { Name = "grp3" };

            // ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "English" ,Value = "1",Selected=true ,Group =group1 },
            //    new SelectListItem { Text = "Hinglish" ,Value = "11" ,Group =group1 },
            //    new SelectListItem { Text = "Hindi" ,Value = "2"  ,Group =group2 },
            //    new SelectListItem { Text = "Dutch" ,Value = "3" ,Disabled=true,Group =group3 }
            //};

            var data = _languageRepository.GetLanguage();
            ViewBag.Language = new SelectList(data,"Id","Text");


            ViewBag.IsSuccess =  issuccess;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> NewBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CoverPhoto!=null)
                {
                    string folder = "books/cover/";
                    model.CoverImageUrl =  await UploadImage(folder,model.CoverPhoto);
                }

                if (model.GalleryFiles!=null)
                {
                    string folder = "books/Gallery/";
                    model.Gallery = new List<GalleryModel>();
                    foreach (var image in model.GalleryFiles)
                    {
                        var gallery = new GalleryModel {  Name = image.FileName,Url = await UploadImage(folder, image) };


                        model.Gallery.Add(gallery);
                    }
                }

                int res = await _bookRepository.AddNewBook(model);
                if (res > 0)
                {
                    return RedirectToAction(nameof(NewBook), new { issuccess = true });
                }
            }

            else
            {
                var query = from state in ModelState.Values
                            from error in state.Errors
                            select error.ErrorMessage;
                var errors = query.ToArray();

                //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
                //ViewBag.Language = new List<string>() { "Hindi", "English", "Dutch" };

                ViewBag.Language = new SelectList(_languageRepository.GetLanguage(), "Id", "Text");
                ModelState.AddModelError("", "This is my Custom Error");
                ViewBag.IsSuccess = false;
            }

            return View();


        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverfulpath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverfulpath, FileMode.Create));

            return "/" + folderPath;
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>() { 
                  new LanguageModel{  Id=1 ,Text="Hindi"},
                  new LanguageModel{  Id=2 ,Text="English"},
                  new LanguageModel{  Id=3 ,Text="Dutch"},
                  new LanguageModel{  Id=4 ,Text="Marathi"}
            };
        }
    }
}