namespace Simple.BTC.Models.Blcokchain;

public class GetChainTxStats_Result
{
    public int time { get; set; }
    public int txcount { get; set; }
    public string window_final_block_hash { get; set; }
    public int window_final_block_height { get; set; }
    public int window_block_count { get; set; }
    public int window_tx_count { get; set; }
    public int window_interval { get; set; }
    public float txrate { get; set; }
}

