
using GiftShopManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GiftShopManagement.Repositories
{
    public interface IUserRepository
    {
        string Message { get; set; }

        Task<IdentityResult> CreateUserAsync(SignUp signUpModel);
        Task<SignInResult> SignInUserAsync(Login logInMode);
        Task SignOutAsync();
    }
}
