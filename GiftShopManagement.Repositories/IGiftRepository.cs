using GiftShopManagement.Models;

namespace GiftShopManagement.Repositories
{
    public interface IGiftRepository
    {
        string Message { get; set; }
        IQueryable<Gift> GetAllWithJoin();
    }
}
