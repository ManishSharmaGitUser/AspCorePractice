using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePrac.Models;
using AspNetCorePrac.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCorePrac.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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

            ViewBag.Language = new List<SelectListItem>() { 
                  new SelectListItem { Text = "English" ,Value = "1" },
                  new SelectListItem { Text = "Hindi" ,Value = "2" ,Selected=true },
                  new SelectListItem { Text = "Dutch" ,Value = "3" ,Disabled=true }
            };
            ViewBag.IsSuccess =  issuccess;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> NewBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                int res = await _bookRepository.AddNewBook(model);
                if (res > 0)
                {
                    return RedirectToAction(nameof(NewBook), new { issuccess = true });
                }
            }

            else
            {
                ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
                //ViewBag.Language = new List<string>() { "Hindi", "English", "Dutch" };
                ModelState.AddModelError("", "This is my Custom Error");
                ViewBag.IsSuccess = false;
            }

            return View();


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