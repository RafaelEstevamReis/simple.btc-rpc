namespace Simple.BTC.Models.Wallet;

public class GetWalletInfo_Result
{
    public string walletname { get; set; }
    public int walletversion { get; set; }
    public string format { get; set; }
    public decimal balance { get; set; }
    public decimal unconfirmed_balance { get; set; }
    public decimal immature_balance { get; set; }
    public int txcount { get; set; }
    public long keypoololdest { get; set; }
    public int keypoolsize { get; set; }
    public int? keypoolsize_hd_internal { get; set; }
    public long unlocked_until { get; set; }
    public decimal paytxfee { get; set; }
    public string hdseedid { get; set; }
    public bool private_keys_enabled { get; set; }
    public bool avoid_reuse { get; set; }
    public object scanning { get; set; }
    public bool descriptors { get; set; }
    public bool external_signer { get; set; }
    public bool blank { get; set; }
    public LastBlockInfo lastprocessedblock { get; set; }

    //public class ScanningDetails
    //{
    //    public int duration { get; set; }
    //    public double progress { get; set; }
    //}
}
