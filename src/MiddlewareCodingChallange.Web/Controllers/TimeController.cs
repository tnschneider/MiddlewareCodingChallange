using System;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareCodingChallange.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] bool throw500)
        {
            if (throw500) throw new Exception("oops!!!");

            return Ok(DateTimeOffset.Now.ToString());
        }
    }
}
