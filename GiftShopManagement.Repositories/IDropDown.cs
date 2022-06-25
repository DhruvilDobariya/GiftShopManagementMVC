using Microsoft.AspNetCore.Mvc.Rendering;

namespace GiftShopManagement.Repositories
{
    public interface IDropDown
    {
        string Message { get; set; }
        IEnumerable<SelectListItem> GiftType();
        IEnumerable<SelectListItem> Company();
    }
}
