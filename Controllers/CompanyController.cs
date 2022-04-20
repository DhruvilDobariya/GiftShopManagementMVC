using GiftShopManagement.Insterfaces;
using GiftShopManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICRUDRepository<Company> _crudRepository;

        public CompanyController(ICRUDRepository<Company> crudRepository)
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
        public async Task<IActionResult> Create(Company company)
        {
            company.ModificationDate = DateTime.Now;
            company.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.InsertAsync(company);
                if (flag)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Company added successfully.";
                    return View();
                }
            }
            TempData["Error"] = _crudRepository.Message;
            return View(company);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Company Not Found.");
            }
            var company = await _crudRepository.GetByIdAsync(Id);
            if (company == null)
            {
                return NotFound("Company Not Found");
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Company company)
        {
            company.ModificationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                bool flag = await _crudRepository.UpdateAsync(company);
                if (flag)
                {
                    TempData["Success"] = "Company updated successfully";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = _crudRepository.Message;
            }
            return View(company);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Company Not Found.");
            }
            bool flag = await _crudRepository.DeleteAsync(Id);
            if (flag)
            {
                TempData["Success"] = "Company deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _crudRepository.Message;
            return RedirectToAction("Index");
        }
    }
}
