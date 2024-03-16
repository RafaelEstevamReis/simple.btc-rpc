namespace Simple.BTC.Models.Blcokchain;

public class GetBlockchainInfo_Result
{
    public string chain { get; set; }
    public long blocks { get; set; }
    public long headers { get; set; }
    public string bestblockhash { get; set; }
    public decimal difficulty { get; set; }
    public long time { get; set; }
    public long mediantime { get; set; }
    public float verificationprogress { get; set; }
    public bool initialblockdownload { get; set; }
    public string chainwork { get; set; }
    public long size_on_disk { get; set; }
    public bool pruned { get; set; }
    public string warnings { get; set; }
}
