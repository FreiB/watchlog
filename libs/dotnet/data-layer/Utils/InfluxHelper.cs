using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using WatchLog.Infra.Data.Entities;

namespace WatchLog.Infra.Data.Utils
{
    public class InfluxHelper
    {
        public static PointData BuildCommonPointDataAttributes(Collectable collectable)
        {
            var point = PointData
                .Measurement(collectable.Type)
                .Timestamp(collectable.TimeStamp, WritePrecision.Ms)
                .Tag("route", collectable.Route)
                //.Tag("client_ip", collectable.ClientIpAddress)
                //.Tag("session_id", collectable.SessionId)
                .Tag("device_family", collectable.DeviceFamily)
                .Tag("user_agent_family", collectable.UserAgentFamily)
                .Tag("user_agent_version", collectable.UserAgentVersion)
                .Tag("os_family", collectable.OperatingSystemFamily)
                .Tag("os_version", collectable.OperatingSystemVersion);
            return point;
        }
    }
}
