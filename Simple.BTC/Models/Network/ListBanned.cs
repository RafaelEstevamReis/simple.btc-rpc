namespace Simple.BTC.Models.Network;

public class ListBanned_Result
{
    public string address { get; set; }
    public int ban_created { get; set; }
    public int banned_until { get; set; }
    public int ban_duration { get; set; }
    public int time_remaining { get; set; }
}
