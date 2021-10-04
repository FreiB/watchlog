using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Measurements.Duration;

namespace WatchLog.Infra.Data.Measurements.Http
{
    public class HttpMeasurement: DurationMeasurement
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public int Status { get; set; }
    }
}
