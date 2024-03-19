namespace Simple.BTC.Models.Wallet;

public class GetBalances_Result
{
    public Wallet? mine { get; set; }
    public Wallet? watchonly { get; set; }
    public LastBlockInfo? lastprocessedblock { get; set; }

    public class Wallet
    {
        public decimal trusted { get; set; }
        public decimal untrusted_pending { get; set; }
        public decimal immature { get; set; }
    }
}