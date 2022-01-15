using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature
                {
                    Id = 1,
                    Color = "Red",
                    Height = 15,
                    Width = 10,
                    ProductId = 1
                },
                new ProductFeature
                {
                    Id = 2,
                    Color = "Green",
                    Height = 25,
                    Width = 5,
                    ProductId = 2
                },
                new ProductFeature
                {
                    Id = 3,
                    Color = "Turquoise",
                    Height = 41,
                    Width = 13,
                    ProductId = 3
                },
                new ProductFeature
                {
                    Id = 4,
                    Color = "Gray",
                    Height = 45,
                    Width = 4,
                    ProductId = 4
                },
                new ProductFeature
                {
                    Id = 5,
                    Color = "Cyan",
                    Height = 5,
                    Width = 10,
                    ProductId = 5
                },
                new ProductFeature
                {
                    Id = 6,
                    Color = "Blue",
                    Height = 20,
                    Width = 6,
                    ProductId = 6
                }
            );
        }
    }
}
