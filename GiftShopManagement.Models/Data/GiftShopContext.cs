using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShopManagement.Models.Data
{
    public class GiftShopContext : IdentityDbContext<ApplicationUser>
    {
        public GiftShopContext(DbContextOptions<GiftShopContext> options) : base(options)
        {
        }
        public DbSet<GiftType> GiftType { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Gift> Gift { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceWiseGift> InvoiceWiseGift { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Sell> Sell { get; set; }

    }
}
