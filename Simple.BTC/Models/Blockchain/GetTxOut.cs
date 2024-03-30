namespace Simple.BTC.Models.Blockchain;

public class GetTxOut_Result
{
    public string bestblock { get; set; }
    public long confirmations { get; set; }
    public decimal value { get; set; }
    public Scriptpubkey scriptPubKey { get; set; }
    public bool coinbase { get; set; }

}
