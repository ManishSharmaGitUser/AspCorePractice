using System.Threading.Tasks;
using AspNetCorePrac.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCorePrac.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel model);

        Task<SignInResult> SignInAsync(SignInModel signInModel);

        Task SignOutAsync();

        Task<IdentityResult> UpdatePassword(PasswordUpdateModel model);

    }
}