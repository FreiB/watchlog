using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WatchLog.Infra.Data.Measurements.Performance.ResourceTiming
{

    public class ResourceTimingMeasurement
    {
        public string Name { get; set; }
        public string EntryType { get; set; }
        public double StartTime { get; set; }
        public double Duration { get; set; }
        public string InitiatorType { get; set; }
        public string NextHopProtocol { get; set; }
        public double WorkerStart { get; set; }
        public double RedirectStart { get; set; }
        public double RedirectEnd { get; set; }
        public double FetchStart { get; set; }
        public double DomainLookupStart { get; set; }
        public double DomainLookupEnd { get; set; }
        public double ConnectStart { get; set; }
        public double ConnectEnd { get; set; }
        public double SecureConnectionStart { get; set; }
        public double RequestStart { get; set; }
        public double ResponseStart { get; set; }
        public double ResponseEnd { get; set; }
        public int TransferSize { get; set; }
        public int EncodedBodySize { get; set; }
        public int DecodedBodySize { get; set; }
        public List<object> ServerTiming { get; set; }
        public List<object> WorkerTiming { get; set; }
        public string Type { get; set; }
        public int RedirectCount { get; set; }
    }

}
