using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePrac.Models;
using AspNetCorePrac.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePrac.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository accountRepository = null;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(SignInModel signInModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepository.SignInAsync(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(signInModel);
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await accountRepository.CreateUserAsync(model);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(model);
            }
            return RedirectToAction("Index","Home");
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(PasswordUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await accountRepository.UpdatePassword(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(model);
        }


    }
}