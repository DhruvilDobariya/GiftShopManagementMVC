using GiftShopManagement.Models;
using GiftShopManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace stockShopManagement.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly ICRUDRepository<Stock> _crudRepository;
        private readonly IStockRepository _stockRepository;

        public StockController(ICRUDRepository<Stock> crudRepository, IStockRepository stockRepository)
        {
            _crudRepository = crudRepository;
            _stockRepository = stockRepository;
        }

        public IActionResult Index(int id)
        {
            var stock = _stockRepository.GetAllWithJoin(id);
            return View(stock);
        }

        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stock stock)
        {
            stock.ModificationDate = DateTime.Now;
            stock.CreationDate = DateTime.Now;
            stock.TotalPrice = stock.Quantity * stock.PricePerPice;
            if (ModelState.IsValid)
            {
                bool flag = await _stockRepository.InsertAsync(stock);
                if (flag)
                {
                    ModelState.Clear();
                    TempData["Success"] = "stock added successfully.";
                    return View();
                }
            }
            TempData["Error"] = _stockRepository.Message;
            return View(stock);
        }

        public async Task<IActionResult> Update(int giftId, int Id)
        {
            if (Id == 0)
            {
                return NotFound("stock Not Found.");
            }
            var stock = await _crudRepository.GetByIdAsync(Id);
            if (stock == null)
            {
                return NotFound("stock Not Found");
            }
            return View(stock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Stock stock)
        {
            stock.ModificationDate = DateTime.Now;
            stock.TotalPrice = stock.Quantity * stock.PricePerPice;
            if (ModelState.IsValid)
            {
                bool flag = await _stockRepository.UpdateAsync(stock);
                if (flag)
                {
                    TempData["Success"] = "stock updated successfully";
                    return RedirectToAction("Index", "Stock", new { id = stock.GiftId });
                }
                TempData["Error"] = _stockRepository.Message;
            }
            return View(stock);
        }

        public async Task<IActionResult> Delete(int giftId, int Id)
        {
            if (Id == 0)
            {
                return NotFound("stock Not Found.");
            }
            bool flag = await _stockRepository.DeleteAsync(Id, giftId);
            if (flag)
            {
                TempData["Success"] = "stock deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _stockRepository.Message;
            return RedirectToAction("Index", "Stock", new {id = Id});
        }
    }
}
