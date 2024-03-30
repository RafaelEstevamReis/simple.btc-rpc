namespace Simple.BTC.Models.Blockchain;

public class GetDeploymentInfo_Result
{
    public string hash { get; set; }
    public long height { get; set; }
    public Deployments deployments { get; set; }


    public class Deployments
    {
        public Bip34 bip34 { get; set; }
        public Bip66 bip66 { get; set; }
        public Bip65 bip65 { get; set; }
        public Csv csv { get; set; }
        public Segwit segwit { get; set; }
        public Taproot taproot { get; set; }
    }

    public class Bip34
    {
        public string type { get; set; }
        public bool active { get; set; }
        public long height { get; set; }
    }

    public class Bip66
    {
        public string type { get; set; }
        public bool active { get; set; }
        public long height { get; set; }
    }

    public class Bip65
    {
        public string type { get; set; }
        public bool active { get; set; }
        public long height { get; set; }
    }

    public class Csv
    {
        public string type { get; set; }
        public bool active { get; set; }
        public long height { get; set; }
    }

    public class Segwit
    {
        public string type { get; set; }
        public bool active { get; set; }
        public long height { get; set; }
    }

    public class Taproot
    {
        public string type { get; set; }
        public long height { get; set; }
        public bool active { get; set; }
        public Bip9 bip9 { get; set; }
    }

    public class Bip9
    {
        public long start_time { get; set; }
        public long timeout { get; set; }
        public long min_activation_height { get; set; }
        public string status { get; set; }
        public long since { get; set; }
        public string status_next { get; set; }
    }
}