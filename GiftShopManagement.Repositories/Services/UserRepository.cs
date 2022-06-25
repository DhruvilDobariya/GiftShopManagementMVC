using GiftShopManagement.Models;
using GiftShopManagement.Models.Data;
using GiftShopManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// This Service used to Manage Users
/// </summary>

namespace GiftShopManagement.Repositories.Services
{
    // Inherite IUserRepository
    public class UserRepository : IUserRepository
    {
        #region Private Member

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GiftShopContext _giftShopContext;

        #endregion

        #region Public Proparties

        public string Message { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Inject Dependencies
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="giftShopContext"></param>
        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GiftShopContext giftShopContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _giftShopContext = giftShopContext;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This Method Provides Service of Create User.
        /// </summary>
        /// <param name="signUpModel">It is instance of SignUp Model</param>
        /// <returns>
        /// This Method Returns Result that provide information and logs about User like user create or not
        /// But if exception is generate then returns null
        /// </returns>
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
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// This Method Provides Service of Log in User 
        /// </summary>
        /// <param name="logInModel">This is Instance of Login Model</param>
        /// <returns>
        /// This Method returns result which provide log about login user like "username and password are invalid" or "valid user"
        /// But if exception is generate then returns null
        /// </returns>
        public async Task<SignInResult> SignInUserAsync(Login logInModel)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(logInModel.UserName, logInModel.Password, logInModel.RememberMe, false);
                return result;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// This medthos provides service to sign out user
        /// </summary>
        /// <returns>
        /// Return Nothing
        /// </returns>
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

        #endregion
    }
}
