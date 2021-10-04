using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Writes;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;
using WatchLog.Infra.Data.Measurements.Performance.ResourceTiming;
using WatchLog.Infra.Data.Utils;

namespace WatchLog.Infra.Data.Measurements.Performance.NavigationTiming
{
    public class NavigationTimingPointDataCreator : ResourceTimingPointDataCreator
    {
        public new PointData CreatePointData(Collectable collectable)
        {
            NavigationTimingMeasurement ntMeasurement =
                    JsonConvert.DeserializeObject<NavigationTimingMeasurement>(collectable.Message.ToString());
            var point = base.CreatePointData(collectable)
              .Field("dom_complete", ntMeasurement.DomComplete)
              .Field("dom_content_loaded_event_start", ntMeasurement.DomContentLoadedEventStart)
              .Field("dom_content_loaded_event_end", ntMeasurement.DomContentLoadedEventEnd)
              .Field("dom_interactive", ntMeasurement.DomInteractive)
              .Field("load_event_start", ntMeasurement.LoadEventStart)
              .Field("load_event_end", ntMeasurement.LoadEventEnd);

            return point;
        }
    }
}
