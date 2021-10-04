using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Writes;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;
using WatchLog.Infra.Data.Utils;

namespace WatchLog.Infra.Data.Measurements.Performance.PaintTiming
{
    public class PaintTimingPointDataCreator : IPointDataCreator
    {
        public PointData CreatePointData(Collectable collectable)
        {
            PaintTimingMeasurement ptMeasurement =
                    JsonConvert.DeserializeObject<PaintTimingMeasurement>(collectable.Message.ToString());
            var point = InfluxHelper.BuildCommonPointDataAttributes(collectable)
              .Tag("entry_type", ptMeasurement.EntryType)
              .Tag("name", ptMeasurement.Name)
              .Field("duration", ptMeasurement.Duration)
              .Field("start_time", ptMeasurement.StartTime);
            return point;
        }
    }
}
