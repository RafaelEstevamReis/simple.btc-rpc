namespace Simple.BTC.Models.Wallet;

public class GetAddressInfo_Result
{
    public string address { get; set; }
    public string scriptPubKey { get; set; }
    public bool ismine { get; set; }
    public bool solvable { get; set; }
    public string desc { get; set; }
    public string parent_desc { get; set; }
    public bool iswatchonly { get; set; }
    public bool isscript { get; set; }
    public bool iswitness { get; set; }
    public int witness_version { get; set; }
    public string witness_program { get; set; }
    public string pubkey { get; set; }
    public bool ischange { get; set; }
    public int timestamp { get; set; }
    public string hdkeypath { get; set; }
    public string hdseedid { get; set; }
    public string hdmasterfingerprint { get; set; }
    public string[] labels { get; set; }
}
