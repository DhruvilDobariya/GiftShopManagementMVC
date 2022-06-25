using GiftShopManagement.Models;
using GiftShopManagement.Models.Data;

namespace GiftShopManagement.Repositories.Services
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
                                         CreationDate = Gift.CreationDate,
                                         ModificationDate = Gift.ModificationDate,
                                         Company = Company
                                     };
            return query;
        }
    }
}
