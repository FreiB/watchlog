using InfluxDB.Client.Writes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Domain;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;
using WatchLog.Infra.Data.Utils;

namespace WatchLog.Infra.Data.Measurements.Http
{
    public class HttpPointDataCreator : IPointDataCreator
    {
        public PointData CreatePointData(Collectable collectable)
        {
            HttpMeasurement httpMeasurement =
                JsonConvert.DeserializeObject<HttpMeasurement>(collectable.Message.ToString());
            var point = InfluxHelper.BuildCommonPointDataAttributes(collectable)
                .Tag("url", httpMeasurement.Url)
                .Tag("method", httpMeasurement.Method)
                .Tag("status", httpMeasurement.Status.ToString())
                .Field("duration", httpMeasurement.Duration);
            return point;
        }
    }
}
