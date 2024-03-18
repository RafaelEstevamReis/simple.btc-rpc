namespace Simple.BTC.Models.Network;

public class GetNetworkInfo_Result
{
    public int version { get; set; }
    public string subversion { get; set; }
    public int protocolversion { get; set; }
    public string localservices { get; set; }
    public string[] localservicesnames { get; set; }
    public bool localrelay { get; set; }
    public long timeoffset { get; set; }
    public bool networkactive { get; set; }
    public long connections { get; set; }
    public long connections_in { get; set; }
    public long connections_out { get; set; }
    public Network[] networks { get; set; }
    public decimal relayfee { get; set; }
    public decimal incrementalfee { get; set; }
    public object[] localaddresses { get; set; }
    public string warnings { get; set; }

    public class Network
    {
        public string name { get; set; }
        public bool limited { get; set; }
        public bool reachable { get; set; }
        public string proxy { get; set; }
        public bool proxy_randomize_credentials { get; set; }
    }
}