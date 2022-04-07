using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class GiftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
