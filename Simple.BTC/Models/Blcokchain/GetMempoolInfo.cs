namespace Simple.BTC.Models.Blcokchain;

public class GetMempoolInfo_Result
{
    public bool loaded { get; set; }
    public long size { get; set; }
    public long bytes { get; set; }
    public long usage { get; set; }
    public decimal total_fee { get; set; }
    public long maxmempool { get; set; }
    public decimal mempoolminfee { get; set; }
    public decimal minrelaytxfee { get; set; }
    public decimal incrementalrelayfee { get; set; }
    public long unbroadcastcount { get; set; }
    public bool fullrbf { get; set; }
}
