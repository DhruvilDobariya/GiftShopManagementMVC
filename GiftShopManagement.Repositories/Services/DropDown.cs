using GiftShopManagement.Models;
using GiftShopManagement.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GiftShopManagement.Repositories.Services
{
    public class DropDown : IDropDown
    {
        private readonly GiftShopContext _context;
        public string Message { get; set; }

        public DropDown(GiftShopContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Company()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                var companies = _context.Company.ToList();
                if (companies.Count <= 0)
                {
                    Message = "No company available";
                    return list;
                }
                foreach (Company company in companies)
                {
                    SelectListItem selectListItem = new SelectListItem() { Value = company.CompanyId.ToString(), Text = company.CompanyName };
                    list.Add(selectListItem);
                }
                return list;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return list;
            }
        }

        public IEnumerable<SelectListItem> GiftType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                var giftTypes = _context.GiftType.ToList();
                if (giftTypes.Count <= 0)
                {
                    Message = "No gift type available";
                    return list;
                }
                foreach (GiftType giftType in giftTypes)
                {
                    SelectListItem selectListItem = new SelectListItem() { Value = giftType.GiftTypeID.ToString(), Text = giftType.GiftTypeName };
                    list.Add(selectListItem);
                }
                return list;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return list;
            }
        }
    }
}
