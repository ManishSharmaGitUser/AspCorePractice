using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePrac.Models;
using AspNetCorePrac.Repository;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.IsSuccess = issuccess;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> NewBook(BookModel model)
        {
           int res =await  _bookRepository.AddNewBook(model);
            if (res > 0)
            {
                return RedirectToAction(nameof(NewBook) ,new { issuccess =true });
            }
            return View();
        }
    }
}