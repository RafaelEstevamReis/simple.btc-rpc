namespace Simple.BTC.Models.Blcokchain;

using System;

public class GetChainStates_Result
{
    public int headers { get; set; }
    public Chainstate[] chainstates { get; set; }
}

public class Chainstate
{
    public int blocks { get; set; }
    public string bestblockhash { get; set; }
    public float difficulty { get; set; }
    public float verificationprogress { get; set; }
    public int coins_db_cache_bytes { get; set; }
    public long coins_tip_cache_bytes { get; set; }
    public bool validated { get; set; }
}
