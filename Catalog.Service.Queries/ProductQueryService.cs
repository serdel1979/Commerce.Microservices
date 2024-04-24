using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public class ProductQueryService
    {
        private readonly ApplicationDbContext _Context;

        //esta clase se usa para metodos de solo lectura

        public ProductQueryService(ApplicationDbContext applicationDbContext)
        {
            this._Context = applicationDbContext;
        }


        public async Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {

        }

    }
}
