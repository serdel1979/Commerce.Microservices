using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);


            var products = new List<Product>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i,
                        Name = $"Product {i}",
                        Description = $"product description {i}",
                        Price = random.Next(100, 2000),
                    }
               );
            }

            entityBuilder.HasData( products );

        }
    }
}
