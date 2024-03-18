namespace Simple.BTC.Models.Control;

public class GetMemoryInfo_Result
{
    public Locked locked { get; set; }

    public class Locked
    {
        public int used { get; set; }
        public int free { get; set; }
        public int total { get; set; }
        public int locked { get; set; }
        public int chunks_used { get; set; }
        public int chunks_free { get; set; }
    }
}