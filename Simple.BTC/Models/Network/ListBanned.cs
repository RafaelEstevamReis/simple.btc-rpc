using System;

namespace Simple.BTC.Models.Network;


public enum SetBanCommand
{
    /// <summary>
    /// Ban the Address
    /// </summary>
    add,
    /// <summary>
    /// Remove from Banned List
    /// </summary>
    remove,
}
public class ListBanned_Result
{
    public string address { get; set; }
    public int ban_created { get; set; }
    public int banned_until { get; set; }
    public int ban_duration { get; set; }
    public int time_remaining { get; set; }

    public override string ToString()
    {
        var dtBan = DateTime.UnixEpoch.AddSeconds(ban_created);
        string remaining =
            time_remaining < 4000 ? $"{time_remaining}s"
            : time_remaining < 5 * 24 * 3600 ? $"{time_remaining / 3600:0}h"
            : $"{time_remaining / (24 * 3600):0}d";
        return $"[{dtBan:yyyy-MM-dd HH:mm}] {address} - {remaining}";
    }
}
