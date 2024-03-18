namespace Simple.BTC.Models.Network;

public class GetNetTotals_Result
{
    public long totalbytesrecv { get; set; }
    public long totalbytessent { get; set; }
    public long timemillis { get; set; }
    public Uploadtarget uploadtarget { get; set; }

    public class Uploadtarget
    {
        public long timeframe { get; set; }
        public long target { get; set; }
        public bool target_reached { get; set; }
        public bool serve_historical_blocks { get; set; }
        public long bytes_left_in_cycle { get; set; }
        public long time_left_in_cycle { get; set; }
    }
}