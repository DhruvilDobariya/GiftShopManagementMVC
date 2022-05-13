using GiftShopManagement.Insterfaces;
using GiftShopManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class GiftController : Controller
    {
        private readonly ICRUDRepository<Gift> _crudRepository;
        private readonly IDropDown _dropDown;
        private readonly IGiftRepository _giftRepository;

        public GiftController(ICRUDRepository<Gift> crudRepository, IDropDown dropDown, IGiftRepository giftRepository)
        {
            _crudRepository = crudRepository;
            _dropDown = dropDown;
            _giftRepository = giftRepository;
        }

        public IActionResult Index()
        {
            return View(_giftRepository.GetAllWithJoin());
        }

        public IActionResult Create()
        {
            ViewBag.GiftTypes = _dropDown.GiftType();
            ViewBag.Companies = _dropDown.Company();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gift gift)
        {
            gift.ModificationDate = DateTime.Now;
            gift.CreationDate = DateTime.Now;
            gift.Quantity = 0;
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
            ViewBag.GiftTypes = _dropDown.GiftType();
            ViewBag.Companies = _dropDown.Company();
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
            ViewBag.GiftTypes = _dropDown.GiftType();
            ViewBag.Companies = _dropDown.Company();
            return View(gift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Gift gift)
        {
            gift.ModificationDate = DateTime.Now;
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
            ViewBag.GiftTypes = _dropDown.GiftType();
            ViewBag.Companies = _dropDown.Company();
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
