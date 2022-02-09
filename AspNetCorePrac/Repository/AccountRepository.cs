using AspNetCorePrac.Models;
using AspNetCorePrac.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserService userService;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UserService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<SignInResult> SignInAsync(SignInModel signInModel)
        {
            return await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdatePassword(PasswordUpdateModel model)
        {
            var userId = userService.GetUserId();
            var user = await userManager.FindByIdAsync(userId);
            return await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }

}
