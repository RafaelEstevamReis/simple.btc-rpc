﻿namespace Simple.BTC.Models.Utils;

public class GetDescriptorInfo_Result
{
    public string descriptor { get; set; }
    public string checksum { get; set; }
    public bool isrange { get; set; }
    public bool issolvable { get; set; }
    public bool hasprivatekeys { get; set; }
}
