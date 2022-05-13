using Microsoft.AspNetCore.Mvc.Rendering;

namespace GiftShopManagement.Insterfaces
{
    public interface IDropDown
    {
        string Message { get; set; }
        IEnumerable<SelectListItem> GiftType();
        IEnumerable<SelectListItem> Company();
    }
}
