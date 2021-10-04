using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WatchLog.Services.CollectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        // GET: api/<SessionController>
        [HttpGet]
        public void Get()
        {
            string sessionId = Request.Cookies["WATCHLOG_SESSION"];
            if (string.IsNullOrEmpty(sessionId))
            {
                Response.Cookies.Append("WATCHLOG_SESSION", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Domain = "local.watchlog.com"
                });
            }
        }
    }
}
