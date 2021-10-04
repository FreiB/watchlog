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

namespace WatchLog.Infra.Data.Measurements.Duration
{
    public class DurationPointDataCreator: IPointDataCreator
    {
        public PointData CreatePointData(Collectable collectable)
        {
            DurationMeasurement durationMeasurement =
                JsonConvert.DeserializeObject<DurationMeasurement>(collectable.Message.ToString());
            var point = InfluxHelper.BuildCommonPointDataAttributes(collectable)
                .Field("duration", durationMeasurement.Duration);
            return point;
        }
    }
}
