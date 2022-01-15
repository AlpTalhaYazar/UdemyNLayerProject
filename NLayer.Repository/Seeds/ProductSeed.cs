using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Pen 1",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Pen 2",
                    Price = 200,
                    Stock = 30,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Pen 3",
                    Price = 600,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Book 1",
                    Price = 250,
                    Stock = 25,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Book 2",
                    Price = 400,
                    Stock = 40,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 3,
                    Name = "Notebook 1",
                    Price = 160,
                    Stock = 26,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Name = "Notebook 2",
                    Price = 350,
                    Stock = 35,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
