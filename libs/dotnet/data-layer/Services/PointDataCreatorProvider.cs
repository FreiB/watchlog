using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Measurements.Duration;
using WatchLog.Infra.Data.Measurements.Http;
using WatchLog.Infra.Data.Measurements.Performance.NavigationTiming;
using WatchLog.Infra.Data.Measurements.Performance.PaintTiming;
using WatchLog.Infra.Data.Measurements.Performance.ResourceTiming;
using WatchLog.Infra.Data.Measurements.Routing;

namespace WatchLog.Infra.Data.Services
{
    public class PointDataCreatorProvider : IPointDataCreatorProvider
    {
        public IPointDataCreator ProvidePointDataCreator(string type)
        {
            switch (type.ToLower())
            {
                case "http":
                    return new HttpPointDataCreator();
                case "wl_angular_routing":
                    return new RoutingPointDataCreator();
                case "boot":
                    return new DurationPointDataCreator();
                case "perf-navigation":
                    return new NavigationTimingPointDataCreator();
                case "perf-resource":
                    return new ResourceTimingPointDataCreator();
                case "perf-paint":
                case "perf-measure":
                    return new PaintTimingPointDataCreator();
            }

            return null;
        }
    }
}
