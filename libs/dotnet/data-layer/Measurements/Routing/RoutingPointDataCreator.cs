using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;
using WatchLog.Infra.Data.Utils;

namespace WatchLog.Infra.Data.Measurements.Routing
{
    public class RoutingPointDataCreator: IPointDataCreator
    {
        public PointData CreatePointData(Collectable collectable)
        {
            RoutingMeasurement routingMeasurement =
                JsonConvert.DeserializeObject<RoutingMeasurement>(collectable.Message.ToString());
            var point = InfluxHelper.BuildCommonPointDataAttributes(collectable)
                .Tag("start_route", routingMeasurement.StartRoute)
                .Tag("end_route", routingMeasurement.EndRoute)
                .Field("duration", routingMeasurement.Duration);
            return point;
        }
    }
}
