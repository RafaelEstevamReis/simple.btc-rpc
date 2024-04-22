namespace Simple.BTC.Models.Utils;

public class ValidateAddress_Result
{
    public bool isvalid { get; set; }
    public string address { get; set; }
    public string scriptPubKey { get; set; }
    public bool isscript { get; set; }
    public bool iswitness { get; set; }
}
