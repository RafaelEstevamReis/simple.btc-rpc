namespace Simple.BTC.Models.Mining;

public class GetMiningInfo_Result
{
    public long blocks { get; set; }
    public string bits { get; set; }
    public decimal difficulty { get; set; }
    public string target { get; set; }
    public decimal networkhashps { get; set; }
    public long pooledtx { get; set; }
    public string chain { get; set; }
    public Next next { get; set; }
    public string[] warnings { get; set; }

    public class Next
    {
        public int height { get; set; }
        public string bits { get; set; }
        public decimal difficulty { get; set; }
        public string target { get; set; }
    }
}
