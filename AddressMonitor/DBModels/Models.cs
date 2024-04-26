namespace AddressMonitor.DBModels;

using Simple.DatabaseWrapper.Attributes;
using System;

public class MonitoredTransactions
{
    [PrimaryKey]
    public string TxID { get; set; }
    public string Description { get; set; }
    public bool Entry { get; set; }
}
public class MonitoredAddress
{
    [PrimaryKey]
    public string Address { get; set; }
    public string Description { get; set; }
}
public class Transactions
{
    [PrimaryKey]
    public string TxID { get; set; }
    [Index("ixTransactions_Block")]
    public string BlockHash { get; set; }
    public DateTime DateTimeUTC { get; set; }

}
public class AddressTransactions
{
    [PrimaryKey]
    public string Id { get; set; }
    [Index("ixAddressTransactions_TxId")]
    public string TxId { get; set; }
    [Index("ixAddressTransactions_Address")]
    public string Address { get; set; }
    public decimal Value { get; set; }
}
public class ConfigKeys
{
    [PrimaryKey]
    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
}