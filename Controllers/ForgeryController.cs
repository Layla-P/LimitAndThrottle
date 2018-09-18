using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace LimitAndThrottle.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ForgeryController : ControllerBase
    {

        public ForgeryController(IAntiforgery antiforgery)
        {
           // We can send the request token as a JavaScript-readable cookie 
            var tokens = antiforgery.GetAndStoreTokens(HttpContext);
            Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
