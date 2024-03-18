namespace Simple.BTC.Models.Control;

public class GetRpcInfo_Result
{
    public Active_Commands[] active_commands { get; set; }
    public string logpath { get; set; }

    public class Active_Commands
    {
        public string method { get; set; }
        public long duration { get; set; }
    }
}