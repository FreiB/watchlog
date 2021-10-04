using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WatchLog.Infra.Data.Entities
{
    public class Collectable
    {
        public string ClientIpAddress { get; set; }
        public string DeviceFamily { get; set; }
        public string UserAgentFamily { get; set; }
        public string UserAgentVersion { get; set; }
        public string OperatingSystemFamily { get; set; }
        public string OperatingSystemVersion { get; set; }
        public string SessionId { get; set; }
        public long TimeStamp { get; set; }
        public string Route { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
    }
}
