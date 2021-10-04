namespace WatchLog.Infra.Data.Measurements.Performance.PaintTiming
{
    public class PaintTimingMeasurement
    {
        public string Name { get; set; }
        public string EntryType { get; set; }
        public double StartTime { get; set; }
        public double Duration { get; set; }
    }
}
