namespace Simple.BTC.Models.Blockchain;

public class GetChainTips_Result
{
    public long height { get; set; }
    public string hash { get; set; }
    public long branchlen { get; set; }
    public string status { get; set; }
}

