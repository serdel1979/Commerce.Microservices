using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using Customer.Service.Queries;
using Customer.Service.Queries.DTOs;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueryService customerQuery;

        public CustomerController(ICustomerQueryService customerQuery)
        {
            this.customerQuery = customerQuery;
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



    }
}
