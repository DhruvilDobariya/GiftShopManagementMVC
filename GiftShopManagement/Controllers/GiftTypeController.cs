using GiftShopManagement.Models;
using GiftShopManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    [Authorize]
    public class GiftTypeController : Controller
    {
        private readonly ICRUDRepository<GiftType> _crudRepository;

        public GiftTypeController(ICRUDRepository<GiftType> crudRepository)
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
        public async Task<IActionResult> Create(GiftType giftType)
        {
            giftType.ModificationDate = DateTime.Now;
            giftType.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.InsertAsync(giftType);
                if (flag)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Gift type added successfully.";
                    return View();
                }
            }
            TempData["Error"] = _crudRepository.Message;
            return View(giftType);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Gift type Not Found.");
            }
            var giftType = await _crudRepository.GetByIdAsync(Id);
            if (giftType == null)
            {
                return NotFound("Gift type Not Found");
            }
            return View(giftType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GiftType giftType)
        {
            giftType.ModificationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.UpdateAsync(giftType);
                if (flag)
                {
                    TempData["Success"] = "Gift type updated successfully";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = _crudRepository.Message;
            }
            return View(giftType);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Gift Type Not Found.");
            }
            bool flag = await _crudRepository.DeleteAsync(Id);
            if (flag)
            {
                TempData["Success"] = "Gift type deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _crudRepository.Message;
            return RedirectToAction("Index");
        }
    }
}
