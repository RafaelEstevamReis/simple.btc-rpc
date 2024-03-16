namespace Simple.BTC.Models.Blcokchain;

public class GetChainTips_Result
{
    public long height { get; set; }
    public string hash { get; set; }
    public long branchlen { get; set; }
    public string status { get; set; }
}

