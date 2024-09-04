using FureaApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FureaApp.Data
{
    public class DatabaseContext : DbContext
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
	}
}

