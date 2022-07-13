using GiftShopManagement.Models;

namespace GiftShopManagement.Repositories
{
    public interface IStockRepository
    {
        string Message { get; set; }
        IQueryable<Stock> GetAllWithJoin(int giftId);
        Task<bool> InsertAsync(Stock stock);
        Task<bool> UpdateAsync(Stock stock);
        Task<bool> DeleteAsync(int stockId, int giftId);
    }
}
