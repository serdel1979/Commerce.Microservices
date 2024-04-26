using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInStockController : ControllerBase
    {
        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;

        public ProductInStockController(ILogger<ProductInStockController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateComand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }

    }
}
