using GiftShopManagement.Models.ViewModels;
using GiftShopManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SignUp user)
        {
            var result = await _userRepository.CreateUserAsync(user);
            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(user);
            }
            ModelState.Clear();
            ViewBag.Msg = "User Created";
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.SignInUserAsync(loginModel);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View(loginModel);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View(loginModel);
                }
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }*/

        public async Task<IActionResult> Logout()
        {
            await _userRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
