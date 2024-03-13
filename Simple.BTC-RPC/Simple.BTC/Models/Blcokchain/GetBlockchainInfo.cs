namespace Simple.BTC.Models.Blcokchain;

public class GetBlockchainInfo_Result
{
    public string chain { get; set; }
    public int blocks { get; set; }
    public int headers { get; set; }
    public string bestblockhash { get; set; }
    public float difficulty { get; set; }
    public int time { get; set; }
    public int mediantime { get; set; }
    public float verificationprogress { get; set; }
    public bool initialblockdownload { get; set; }
    public string chainwork { get; set; }
    public long size_on_disk { get; set; }
    public bool pruned { get; set; }
    public string warnings { get; set; }
}
