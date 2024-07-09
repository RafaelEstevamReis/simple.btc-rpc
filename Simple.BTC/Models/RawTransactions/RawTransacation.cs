namespace Simple.BTC.Models.RawTransactions;

public class RawTransacation_Result
{
    public string txid { get; set; }
    public string hash { get; set; }
    public int version { get; set; }
    public int size { get; set; }
    public int vsize { get; set; }
    public int weight { get; set; }
    public long locktime { get; set; }
    public Vin[] vin { get; set; }
    public Vout[] vout { get; set; }
    public string hex { get; set; }
    public string blockhash { get; set; }
    public int confirmations { get; set; }
    public int time { get; set; }
    public int blocktime { get; set; }

    public class Vin
    {
        public string coinbase { get; set; }
        public string[]? txinwitness { get; set; }
        public long sequence { get; set; }
        public string? txid { get; set; }
        public int? vout { get; set; }
        public Scriptsig? scriptSig { get; set; }
    }

    public class Vout
    {
        public decimal value { get; set; }
        public long n { get; set; }
        public Scriptpubkey? scriptPubKey { get; set; }

        public override string ToString() => $"{value} {scriptPubKey?.desc}";
    }
}