using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            this._ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, Name = "Needle pen", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                            new Product { Id = 2, Name = "Pencil", Price = 40.50m, Stock = 200, CategoryId = _ids[0] },
                            new Product { Id = 3, Name = "Pen", Price = 500m, Stock = 300, CategoryId = _ids[0] },
                            new Product { Id = 4, Name = "Small notebook", Price = 12.50m, Stock = 300, CategoryId = _ids[1] },
                            new Product { Id = 5, Name = "Middle notebook", Price = 12.50m, Stock = 300, CategoryId = _ids[1] },
                            new Product { Id = 6, Name = "Large notebook", Price = 12.50m, Stock = 300, CategoryId = _ids[1] }
                            );
        }
    }
}
