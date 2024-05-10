using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{


    public interface IProductQueryService
    {
        Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDTO> GetAsync(int Id);
    }



    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _Context;

        //esta clase se usa para metodos de solo lectura

        public ProductQueryService(ApplicationDbContext applicationDbContext)
        {
            this._Context = applicationDbContext;
        }


        public async Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _Context.Products
                .Where(x => products == null || products.Contains(x.Id))
                .OrderByDescending(products => products.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDTO>>();

        }

        public async Task<ProductDTO> GetAsync(int Id)
        {
            var product = (await _Context.Products.SingleAsync(x => x.Id == Id)).MapTo<ProductDTO>();
            if (product == null)
            {
                throw new KeyNotFoundException(nameof(product));
            }
            return product;
        }

    }
}
