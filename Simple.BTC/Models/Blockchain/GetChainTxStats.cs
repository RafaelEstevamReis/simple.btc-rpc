namespace Simple.BTC.Models.Blockchain;

public class GetChainTxStats_Result
{
    public long time { get; set; }
    public long txcount { get; set; }
    public string window_final_block_hash { get; set; }
    public long window_final_block_height { get; set; }
    public long window_block_count { get; set; }
    public long window_tx_count { get; set; }
    public long window_interval { get; set; }
    public decimal txrate { get; set; }
}

