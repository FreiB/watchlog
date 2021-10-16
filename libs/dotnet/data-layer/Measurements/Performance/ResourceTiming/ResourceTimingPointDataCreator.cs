using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InfluxDB.Client.Writes;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;
using WatchLog.Infra.Data.Utils;

namespace WatchLog.Infra.Data.Measurements.Performance.ResourceTiming
{
    public class ResourceTimingPointDataCreator : IPointDataCreator
    {
        public PointData CreatePointData(Collectable collectable)
        {
            Regex noQueryPattern = new Regex("([^?]+).*");
            ResourceTimingMeasurement rtMeasurement =
                JsonConvert.DeserializeObject<ResourceTimingMeasurement>(collectable.Message.ToString());
            var point = InfluxHelper.BuildCommonPointDataAttributes(collectable)
                .Field("connect_end", rtMeasurement.ConnectEnd)
                .Field("connect_start", rtMeasurement.ConnectStart)
                .Field("decoded_body_size", rtMeasurement.DecodedBodySize)
                .Field("domain_lookup_end", rtMeasurement.DomainLookupEnd)
                .Field("domain_lookup_start", rtMeasurement.DomainLookupStart)
                .Field("duration", rtMeasurement.Duration)
                .Field("encoded_body_size", rtMeasurement.EncodedBodySize)
                .Tag("entry_type", rtMeasurement.EntryType)
                .Field("fetch_start", rtMeasurement.FetchStart)
                .Tag("initiator_type", rtMeasurement.InitiatorType)
                .Tag("name", noQueryPattern.Replace(rtMeasurement.Name, "$1"))
                .Tag("next_hop_protocol", rtMeasurement.NextHopProtocol)
                .Field("redirect_end", rtMeasurement.RedirectEnd)
                .Field("redirect_start", rtMeasurement.RedirectStart)
                .Field("response_end", rtMeasurement.ResponseEnd)
                .Field("response_start", rtMeasurement.ResponseStart)
                .Field("secure_connection_start", rtMeasurement.SecureConnectionStart)
                .Field("start_time", rtMeasurement.StartTime)
                .Field("transfer_size", rtMeasurement.TransferSize)
                .Field("worker_start", rtMeasurement.WorkerStart);
            return point;
        }
    }
}
