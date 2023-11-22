using BlazingShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Books", Url = "books", Icon = "book" },
                new Category { Id = 2, Name = "Electronics", Url = "electronics", Icon = "camera-slr" },
                new Category { Id = 3, Name = "Video Games", Url = "video games", Icon = "aperture" }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {

                    Id = 1,
                    CategoryId = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, HG2G' or tHGttG) Is a comedy science fiction series",
                    Image = "https://upload.wikimedia.org/wikimedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 9.99m,
                    OriginalPrice = 19.99m,
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 3,
                    Title = "Half-Life 2",
                    Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting",
                    Image = "https://half-life.fandom.com/wiki/The_G-Man",
                    Price = 8.19m,
                    OriginalPrice = 29.99m,

                });
        }
    }
}
