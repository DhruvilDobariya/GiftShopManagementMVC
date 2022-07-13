using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShopManagement.Models.Data
{
    public class GiftShopContext : IdentityDbContext<ApplicationUser>
    {
        public GiftShopContext(DbContextOptions<GiftShopContext> options) : base(options)
        {
        }
        public virtual DbSet<GiftType> GiftType { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceWiseGift> InvoiceWiseGift { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

    }
}
