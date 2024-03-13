namespace Simple.BTC.Models.RawTransactions;

using System;
using System.Collections.Generic;
using System.Text;

public class RawTransacation_Result
{
    public string txid { get; set; }
    public string hash { get; set; }
    public int version { get; set; }
    public int size { get; set; }
    public int vsize { get; set; }
    public int weight { get; set; }
    public int locktime { get; set; }
    public Vin[] vin { get; set; }
    public Vout[] vout { get; set; }
    public string hex { get; set; }
    public string blockhash { get; set; }
    public int confirmations { get; set; }
    public int time { get; set; }
    public int blocktime { get; set; }

    public class Vin
    {
        public string coinbase { get; set; }
        public long sequence { get; set; }
    }

    public class Vout
    {
        public float value { get; set; }
        public int n { get; set; }
        public Scriptpubkey scriptPubKey { get; set; }
    }

    public class Scriptpubkey
    {
        public string asm { get; set; }
        public string desc { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
    }
}