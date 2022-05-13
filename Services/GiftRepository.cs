using GiftShopManagement.Data;
using GiftShopManagement.Insterfaces;
using GiftShopManagement.Models;

namespace GiftShopManagement.Services
{
    public class GiftRepository : IGiftRepository
    {
        private readonly GiftShopContext _context;
        public string Message { get; set; }

        public GiftRepository(GiftShopContext context)
        {
            _context = context;
        }

        public IQueryable<Gift> GetAllWithJoin()
        {
            IQueryable<Gift> query = from Gift in _context.Gift
                        join GiftType in _context.GiftType on Gift.GiftTypeId equals GiftType.GiftTypeID
                        join Company in _context.Company on Gift.CompanyId equals Company.CompanyId
                        select new Gift
                        {
                            GiftId = Gift.GiftId,
                            GiftName = Gift.GiftName,
                            PricePerPice = Gift.PricePerPice,
                            Quantity = Gift.Quantity,
                            GiftType = GiftType,
                            Company = Company
                        };
            return query;
        }
    }
}
