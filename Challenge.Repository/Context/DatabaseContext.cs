using Microsoft.EntityFrameworkCore;
using Challenge.Repository.Entities;

namespace Challenge.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        #region Entities

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Entities.Action> Actions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileAction> ProfileActions { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
        }
    }
}
