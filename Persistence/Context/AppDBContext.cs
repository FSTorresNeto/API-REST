using api_rest.Domain.Models;
using api_rest.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Jogos" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfPlatform).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Halo Infinity",
                    QuantityInPackage = 4,
                    UnitOfPlatform = EUnitOfPlatform.Xbox,
                    CategoryId = 100
                },
               
                new Product
                {
                    Id = 101,
                    Name = "Spider-Man",
                    QuantityInPackage = 5,
                    UnitOfPlatform = EUnitOfPlatform.PlayStation,
                    CategoryId = 101,
                },
                
                new Product
                {
                  Id = 102,
                  Name = "Mário Card",
                  QuantityInPackage = 4,
                  UnitOfPlatform = EUnitOfPlatform.Nitendo,
                  CategoryId = 103,
                },

                new Product
                {
                  Id = 103,
                  Name = "The Batlle for Wesnoth",
                  QuantityInPackage = 4,
                  UnitOfPlatform = EUnitOfPlatform.PC,
                  CategoryId = 104,
                }
            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            
            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = 100,
                    Login = "Torres",
                    Password = "123456",
                }
            );
        }
    }
}
