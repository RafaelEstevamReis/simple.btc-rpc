using System;

namespace Simple.BTC.Models.Network;

public class GetPeerInfo_Result
{
    public int id { get; set; }
    public string addr { get; set; }
    public string addrbind { get; set; }
    public string addrlocal { get; set; }
    public string network { get; set; }
    public string services { get; set; }
    public string[] servicesnames { get; set; }
    public bool relaytxes { get; set; }
    public long lastsend { get; set; }
    public long lastrecv { get; set; }
    public long last_transaction { get; set; }
    public long last_block { get; set; }
    public long bytessent { get; set; }
    public long bytesrecv { get; set; }
    public long conntime { get; set; }
    public int timeoffset { get; set; }
    public decimal pingtime { get; set; }
    public decimal minping { get; set; }
    public int version { get; set; }
    public string subver { get; set; }
    public bool inbound { get; set; }
    public bool bip152_hb_to { get; set; }
    public bool bip152_hb_from { get; set; }
    public int startingheight { get; set; }
    public int presynced_headers { get; set; }
    public int synced_headers { get; set; }
    public int synced_blocks { get; set; }
    public object[] inflight { get; set; }
    public bool addr_relay_enabled { get; set; }
    public int addr_processed { get; set; }
    public int addr_rate_limited { get; set; }
    public object[] permissions { get; set; }
    public decimal minfeefilter { get; set; }
    public BytesPerMsg bytessent_per_msg { get; set; }
    public BytesPerMsg bytesrecv_per_msg { get; set; }
    public string connection_type { get; set; }
    public string transport_protocol_type { get; set; }
    public string session_id { get; set; }

    public class BytesPerMsg
    {
        public int addrv2 { get; set; }
        public int feefilter { get; set; }
        public int getaddr { get; set; }
        public int getblocktxn { get; set; }
        public int getdata { get; set; }
        public int getheaders { get; set; }
        public int headers { get; set; }
        public int inv { get; set; }
        public int notfound { get; set; }
        public int ping { get; set; }
        public int pong { get; set; }
        public int sendaddrv2 { get; set; }
        public int sendcmpct { get; set; }
        public int sendheaders { get; set; }
        public int tx { get; set; }
        public int verack { get; set; }
        public int version { get; set; }
        public int wtxidrelay { get; set; }
        public int blocktxn { get; set; }
        public int cmpctblock { get; set; }
        public int addr { get; set; }
        public int alert { get; set; }
    }

    public override string ToString()
    {
        string age = FormatAge(conntime);
        string direction = inbound ? "inbound" : "outbound";
        string ping = pingtime > 0 ? $"{pingtime:0.000}s" : "-";
        string sent = $"{bytessent / 1024:0} KB";
        string received = $"{bytesrecv / 1024:0} KB";
        string ua = subver ?? "";

        // Formato alinhado como no Core: #peer | Age | address | direction | type | ping | sent | received | UA
        return $"{id} | {age} | {addr} | {direction} | Up: {sent} Down: {received} / {ping} | {ua}";
    }
    static string FormatAge(long conntime)
    {
        long cnnSec = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds - conntime;
        if (cnnSec < 100) return $"{cnnSec}s";
        else if (cnnSec < 60 * 100) return $"{cnnSec / 60:0}m";
        else if (cnnSec < 3600 * 30) return $"{cnnSec / 3600:0}h";
        else return $"{cnnSec / (24 * 3600):0}d";
    }
}