﻿using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
