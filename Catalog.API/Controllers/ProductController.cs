using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
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
        private readonly IMediator _mediator;

        public ProductController(IProductQueryService productQueryService,
            IMediator mediator)
        {
            this.productQueryService = productQueryService;
            this._mediator = mediator;
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


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
           //usar librerua mediatr y mediatr...dependencyInjection
           await _mediator.Publish(command);

            return Ok();
        }
    }
}
