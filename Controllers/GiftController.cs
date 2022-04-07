using GiftShopManagement.Insterfaces;
using GiftShopManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class GiftController : Controller
    {
        private readonly ICRUDRepository<Gift> _crudRepository;

        public GiftController(ICRUDRepository<Gift> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _crudRepository.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gift gift)
        {
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.InsertAsync(gift);
                if (flag)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Gift added successfully.";
                    return View();
                }
            }
            TempData["Error"] = _crudRepository.Message;
            return View(gift);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Gift Not Found.");
            }
            var gift = await _crudRepository.GetByIdAsync(Id);
            if (gift == null)
            {
                return NotFound("Gift Not Found");
            }
            return View(gift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Gift gift)
        {
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.UpdateAsync(gift);
                if (flag)
                {
                    TempData["Success"] = "Gift updated successfully";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = _crudRepository.Message;
            }
            return View(gift);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Gift Not Found.");
            }
            bool flag = await _crudRepository.DeleteAsync(Id);
            if (flag)
            {
                TempData["Success"] = "Gift deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _crudRepository.Message;
            return RedirectToAction("Index");
        }
    }
}
