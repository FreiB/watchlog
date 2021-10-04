using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Measurements.Duration;

namespace WatchLog.Infra.Data.Measurements.Routing
{
    public class RoutingMeasurement : DurationMeasurement
    {
        public string StartRoute { get; set; }
        public string EndRoute { get; set; }
    }
}
