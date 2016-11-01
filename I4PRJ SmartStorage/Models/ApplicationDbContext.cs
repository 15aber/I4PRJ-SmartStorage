using I4PRJ_SmartStorage.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace I4PRJ_SmartStorage.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}