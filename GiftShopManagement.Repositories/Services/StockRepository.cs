using GiftShopManagement.Models;
using GiftShopManagement.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GiftShopManagement.Repositories.Services
{
    public class StockRepository : IStockRepository
    {
        private readonly GiftShopContext _context;
        public string Message { get; set; }

        public StockRepository(GiftShopContext context)
        {
            _context = context;
        }

        public IQueryable<Stock> GetAllWithJoin(int giftId)
        {
            IQueryable<Stock> query = from Stock in _context.Stock
                                      where Stock.GiftId == giftId
                                      join Gift in _context.Gift on Stock.GiftId equals Gift.GiftId
                                      select new Stock
                                      {
                                          StockId = Stock.StockId,
                                          GiftId = Stock.GiftId,
                                          Quantity = Stock.Quantity,
                                          PricePerPice = Stock.PricePerPice,
                                          TotalPrice = Stock.TotalPrice,
                                          StockDeliveryDate = Stock.StockDeliveryDate,
                                          CreationDate = Stock.CreationDate,
                                          ModificationDate = Stock.ModificationDate,
                                          Gift = Gift
                                      };
            return query;
        }
        public async Task<bool> DeleteAsync(int stockId, int giftId)
        {
            try
            {
                var stock = await _context.Stock.FindAsync(stockId);
                if (stock == null)
                {
                    Message = "Not Found";
                    return false;
                }
                if (_context.Remove(stock) != null)
                {
                    Gift gift = await _context.Gift.FindAsync(giftId);
                    gift.Quantity -= stock.Quantity;

                    if (_context.Update(gift) != null)
                    {
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    Message = "This item contain some record, so first you must delete these record, if you want to delete this item.";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }

        public async Task<bool> InsertAsync(Stock stock)
        {
            try
            {
                if (stock == null)
                {
                    Message = "stock is null";
                    return false;
                }
                if (await _context.Stock.AddAsync(stock) != null)
                {
                    Gift gift = await _context.Gift.FindAsync(stock.GiftId);
                    gift.Quantity += stock.Quantity;

                    if (_context.Update(gift) != null)
                    {
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Stock stock)
        {
            try
            {
                if (stock == null)
                {
                    Message = "stock is null";
                    return false;
                }
                Stock oldStock = await _context.Stock.FindAsync(stock.StockId);
                _context.Entry(oldStock).State = EntityState.Detached; //Here we detached oldStock instance So application dosn't ganarate "The instance of entity type cannot be tracked because another instance with the same key value for {'Id'} is already being tracked" exception. 

                if (_context.Update(stock) != null)
                {
                    Gift gift = await _context.Gift.FindAsync(stock.GiftId);
                    gift.Quantity += (stock.Quantity - oldStock.Quantity);
                    if (_context.Update(gift) != null)
                    {
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }
    }
}
