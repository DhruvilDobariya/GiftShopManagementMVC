using GiftShopManagement.Models;

namespace GiftShopManagement.Insterfaces
{
    public interface IGiftRepository
    {
        string Message { get; set; }
        IQueryable<Gift> GetAllWithJoin();
    }
}
