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
    public class NavigationTimingMeasurement : ResourceTimingMeasurement
    {
        public double UnloadEventStart { get; set; }
        public double UnloadEventEnd { get; set; }
        public double DomInteractive { get; set; }
        public double DomContentLoadedEventStart { get; set; }
        public double DomContentLoadedEventEnd { get; set; }
        public double DomComplete { get; set; }
        public double LoadEventStart { get; set; }
        public double LoadEventEnd { get; set; }
    }
}
