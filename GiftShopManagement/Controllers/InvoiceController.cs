using GiftShopManagement.Models;
using GiftShopManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ICRUDRepository<Invoice> _crudRepository;
        public InvoiceController(ICRUDRepository<Invoice> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _crudRepository.GetAllAsync());
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0)
            {
                return NotFound("Invoice not found!");
            }
            Invoice invoice = await _crudRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                TempData["Error"] = _crudRepository.Message;
                return NotFound("Invoice not found!");
            }
            return View(invoice);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Invoice invoice)
        //{
        //    invoice.ModificationDate = DateTime.Now;
        //    invoice.CreationDate = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        bool flag = await _crudRepository.InsertAsync(invoice);
        //        if (flag)
        //        {
        //            ModelState.Clear();
        //            TempData["Success"] = "invoice added successfully.";
        //            return View();
        //        }
        //    }
        //    TempData["Error"] = _crudRepository.Message;
        //    return View(invoice);
        //}

        //public async Task<IActionResult> Update(int Id)
        //{
        //    if (Id == 0)
        //    {
        //        return NotFound("invoice Not Found.");
        //    }
        //    var invoice = await _crudRepository.GetByIdAsync(Id);
        //    if (invoice == null)
        //    {
        //        return NotFound("invoice Not Found");
        //    }
        //    return View(invoice);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(Invoice invoice)
        //{
        //    invoice.ModificationDate = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        bool flag = await _crudRepository.UpdateAsync(invoice);
        //        if (flag)
        //        {
        //            TempData["Success"] = "invoice updated successfully";
        //            return RedirectToAction("Index");
        //        }
        //        TempData["Error"] = _crudRepository.Message;
        //    }
        //    return View(invoice);
        //}

        //public async Task<IActionResult> Delete(int Id)
        //{
        //    if (Id == 0)
        //    {
        //        return NotFound("invoice Not Found.");
        //    }
        //    bool flag = await _crudRepository.DeleteAsync(Id);
        //    if (flag)
        //    {
        //        TempData["Success"] = "invoice deleted successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["Error"] = _crudRepository.Message;
        //    return RedirectToAction("Index");
        //}

    }
}
