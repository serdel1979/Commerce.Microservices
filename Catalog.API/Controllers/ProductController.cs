using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Service.Common.Collection;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryService productQueryService;

        public ProductController(IProductQueryService productQueryService)
        {
            this.productQueryService = productQueryService;
        }


        [HttpGet]
        public async Task<DataCollection<ProductDTO>> GetAll(int page = 1, int take = 5, string ids = "")
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            return await productQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("Id:int")]
        public async Task<ProductDTO> Get(int Id)
        {
            return await productQueryService.GetAsync(Id);
        }
    }
}
