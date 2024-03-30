namespace Simple.BTC.Models.Blockchain;

public class GetBlockStats_Result
{
    public long avgfee { get; set; }
    public long avgfeerate { get; set; }
    public long avgtxsize { get; set; }
    public string blockhash { get; set; }
    public long[] feerate_percentiles { get; set; }
    public long height { get; set; }
    public long ins { get; set; }
    public long maxfee { get; set; }
    public long maxfeerate { get; set; }
    public long maxtxsize { get; set; }
    public long medianfee { get; set; }
    public long mediantime { get; set; }
    public long mediantxsize { get; set; }
    public long minfee { get; set; }
    public long minfeerate { get; set; }
    public long mintxsize { get; set; }
    public long outs { get; set; }
    public long subsidy { get; set; }
    public long swtotal_size { get; set; }
    public long swtotal_weight { get; set; }
    public long swtxs { get; set; }
    public long time { get; set; }
    public long total_out { get; set; }
    public long total_size { get; set; }
    public long total_weight { get; set; }
    public long totalfee { get; set; }
    public long txs { get; set; }
    public long utxo_increase { get; set; }
    public long utxo_size_inc { get; set; }
    public long utxo_increase_actual { get; set; }
    public long utxo_size_inc_actual { get; set; }
}
