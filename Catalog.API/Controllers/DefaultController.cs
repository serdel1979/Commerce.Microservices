using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
       

        public DefaultController()
        {
           
        }

        [HttpGet]
        public string Get()
        {
            return "Running...";
        }
    }
}
