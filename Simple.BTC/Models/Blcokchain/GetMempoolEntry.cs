namespace Simple.BTC.Models.Blcokchain;

public class GetMempoolEntry_Result
{
    public long vsize { get; set; }
    public long weight { get; set; }
    public long time { get; set; }
    public long height { get; set; }
    public long descendantcount { get; set; }
    public long descendantsize { get; set; }
    public long ancestorcount { get; set; }
    public long ancestorsize { get; set; }
    public string wtxid { get; set; }
    public Fees fees { get; set; }
    public string[] depends { get; set; }
    public string[] spentby { get; set; }
    public bool bip125replaceable { get; set; }
    public bool unbroadcast { get; set; }

    public class Fees
    {
        public decimal @base { get; set; }
        public decimal modified { get; set; }
        public decimal ancestor { get; set; }
        public decimal descendant { get; set; }
    }
}