namespace Simple.BTC.Models.Mining;

public class GetMiningInfo_Result
{
    public long blocks { get; set; }
    public decimal difficulty { get; set; }
    public decimal networkhashps { get; set; }
    public long pooledtx { get; set; }
    public string chain { get; set; }
    public string warnings { get; set; }
}
