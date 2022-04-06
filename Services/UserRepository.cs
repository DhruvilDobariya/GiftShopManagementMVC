using GiftShopManagement.Data;
using GiftShopManagement.Insterfaces;
using GiftShopManagement.Models;
using GiftShopManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GiftShopManagement.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GiftShopContext _giftShopContext;

        public string Message { get; set; }

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GiftShopContext giftShopContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _giftShopContext = giftShopContext;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUp signUpModel)
        {
            try
            {
                var newUser = new ApplicationUser()
                {
                    FirstName = signUpModel.FirstName,
                    LastName = signUpModel.LastName,
                    Email = signUpModel.Email,
                    PhoneNumber = signUpModel.MobileNo,
                    Address = signUpModel.Address,
                    UserName = signUpModel.UserName,
                    CreatedDate = DateTime.Now
                };
                var result = await _userManager.CreateAsync(newUser, signUpModel.Password);
                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(newUser.UserName);
                    if (signUpModel.UserRole == 1)
                    {
                        return await _userManager.AddToRoleAsync(currentUser, "Admin");
                    }
                    else if (signUpModel.UserRole == 2)
                    {
                        return await _userManager.AddToRoleAsync(currentUser, "Normal User");
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<SignInResult> SignInUserAsync(Login logInModel)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(logInModel.UserName, logInModel.Password, logInModel.RememberMe, false);
                return result;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task SignOutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
