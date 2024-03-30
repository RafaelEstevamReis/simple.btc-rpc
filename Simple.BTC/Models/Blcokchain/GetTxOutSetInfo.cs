namespace Simple.BTC.Models.Blcokchain;

public class GetTxOutSetInfo_Result
{
    public long Height { get; set; }
    public string BestBlock { get; set; }
    public long TxOuts { get; set; }
    public long BogoSize { get; set; }
    public string HashSerialized3 { get; set; }
    public string MuHash { get; set; }
    public long? Transactions { get; set; }
    public long? DiskSize { get; set; }
    public decimal TotalAmount { get; set; }
    public long? TotalUnspendableAmount { get; set; }
    public BlockInfoModel BlockInfo { get; set; }


    public class BlockInfoModel
    {
        public long PrevoutSpent { get; set; }
        public long Coinbase { get; set; }
        public long NewOutputsExCoinbase { get; set; }
        public long Unspendable { get; set; }
        public UnspendablesDetails Unspendables { get; set; }
    }

    public class UnspendablesDetails
    {
        public long GenesisBlock { get; set; }
        public long Bip30 { get; set; }
        public long Scripts { get; set; }
        public long UnclaimedRewards { get; set; }
    }
}