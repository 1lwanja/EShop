using BlazingShop.Shared;
using System.Collections.Generic;

namespace BlazingShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get ; set ; } = new List<Product>();    

        public void LoadProducts()
        {
            Products = new List<Product> { 
            
                new Product
                {
                       
                    Id = 1,
                    CategoryId = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, HG2G' or tHGttG) Is a comedy science fiction series",
                    Image = "https://upload.wikimedia.org/wikimedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 9.99m,
                    OriginalPrice =19.99m,
                },
                new Product
                {
                     Id = 2,
                    CategoryId = 3,
                    Title = "Half-Life 2",
                    Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting",
                    Image = "https://half-life.fandom.com/wiki/The_G-Man",
                    Price = 8.19m,
                    OriginalPrice =29.99m,

                }
    };
        }
            
        }
    }

