namespace Simple.BTC.Models.Utils;

public class EstimateSmartFee_Result
{
    public decimal feerate { get; set; }
    public long blocks { get; set; }
    public string[]? errors { get; set; }
}
