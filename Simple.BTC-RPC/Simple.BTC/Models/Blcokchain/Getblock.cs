namespace Simple.BTC.Models.Blcokchain;

public class Getblock_Result
{
    public string hash { get; set; }
    public long confirmations { get; set; }
    public long height { get; set; }
    public long version { get; set; }
    public string versionHex { get; set; }
    public string merkleroot { get; set; }
    public long time { get; set; }
    public long mediantime { get; set; }
    public long nonce { get; set; }
    public string bits { get; set; }
    public long difficulty { get; set; }
    public string chainwork { get; set; }
    public long nTx { get; set; }
    public string previousblockhash { get; set; }
    public string nextblockhash { get; set; }
    public long strippedsize { get; set; }
    public long size { get; set; }
    public long weight { get; set; }
    public string[] tx { get; set; }
}

