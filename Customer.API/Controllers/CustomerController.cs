using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using Customer.Service.Queries;
using Customer.Service.Queries.DTOs;
using MediatR;
using Customer.Service.EventHandlers.Commands;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueryService customerQuery;
        private readonly IMediator _mediatr;

        public CustomerController(ICustomerQueryService customerQuery, IMediator mediatr)
        {
            this.customerQuery = customerQuery;
            this._mediatr = mediatr;
        }


        [HttpGet]
        public async Task<DataCollection<ClientDTO>> GetAll(int page = 1, int take = 5, string ids = "")
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            return await customerQuery.GetAllAsync(page, take, products);
        }

        [HttpGet("Id:int")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                return Ok(await customerQuery.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateCommand command)
        {
            //usar libreria mediatr y mediatr...dependencyInjection
            await _mediatr.Publish(command);

            return Ok();
        }



        [HttpPut("Id:int")]
        public async Task<IActionResult> Update(CustomerUpdateCommand command, int Id)
        {
           
            command.Id = Id;
            await _mediatr.Publish(command);

            return Ok();
        }


    }
}
