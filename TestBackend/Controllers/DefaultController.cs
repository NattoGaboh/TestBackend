using Microsoft.AspNetCore.Mvc;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/Default
        [HttpGet]
        public string Get()
        {
            return "Application Running!";
        }
    }
}
