using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet("print")]
        public IActionResult Print()
        {
            return Ok("DateTime：" + DateTime.Now + "--Port：5002");
        }
    }
}
