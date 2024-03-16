namespace Simple.BTC.Models.Blcokchain;

public class GetChainStates_Result
{
    public long headers { get; set; }
    public Chainstate[] chainstates { get; set; }
}

public class Chainstate
{
    public long blocks { get; set; }
    public string bestblockhash { get; set; }
    public decimal difficulty { get; set; }
    public decimal verificationprogress { get; set; }
    public long coins_db_cache_bytes { get; set; }
    public long coins_tip_cache_bytes { get; set; }
    public bool validated { get; set; }
}
