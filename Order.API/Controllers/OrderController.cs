using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }



    }
}
