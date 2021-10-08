using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UAParser;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Utils;
using WatchLog.Services.CollectService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WatchLog.Services.CollectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectController : ControllerBase
    {
        private IDataService _dataService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CollectController(IDataService dataService, IHttpContextAccessor httpContextAccessor)
        {
            _dataService = dataService;
            _httpContextAccessor = httpContextAccessor;
        }

        // POST api/<CollectController>
        [HttpPost]
        public void Post([FromBody] CollectModel collectPayload)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(Request.Headers["User-Agent"].ToString());
            foreach (var collectable in collectPayload.Collection)
            {
                //collectable.ClientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                //collectable.SessionId = Request.Cookies["WATCHLOG_SESSION"];
                collectable.DeviceFamily = clientInfo.Device.Family ?? string.Empty;
                collectable.UserAgentFamily = clientInfo.UA.Family ?? string.Empty;
                collectable.UserAgentVersion = UAHelper.BuildVersionString(clientInfo.UA.Major, clientInfo.UA.Minor, clientInfo.UA.Patch);
                collectable.OperatingSystemFamily = clientInfo.OS.Family ?? string.Empty;
                collectable.OperatingSystemVersion = UAHelper.BuildVersionString(clientInfo.OS.Major, clientInfo.OS.Minor, clientInfo.OS.Patch);
            }

            _dataService.InsertDataCollection(collectPayload.Collection);
        }
    }
}
