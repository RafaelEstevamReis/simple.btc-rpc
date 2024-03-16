namespace Simple.BTC.Models.Blcokchain;

public class GetChainTips_Result
{
    public int height { get; set; }
    public string hash { get; set; }
    public int branchlen { get; set; }
    public string status { get; set; }
}

