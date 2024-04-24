namespace Simple.BTC.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public static class PubCovnerter
{
    private static byte[] DoubleSha256(byte[] buffer)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] firstHash = sha256.ComputeHash(buffer);
        return sha256.ComputeHash(firstHash);
    }

    private static byte[] DecodeRaw(byte[] buffer)
    {
        var payload = buffer.Take(buffer.Length - 4).ToArray();
        var checksum = buffer.Skip(buffer.Length - 4).ToArray();
        var newChecksum = DoubleSha256(payload).Take(4);

        if (!checksum.SequenceEqual(newChecksum))
        {
            throw new InvalidOperationException("Invalid checksum");
        }

        return payload;
    }

    private static byte[] Decode(string str)
    {
        var buffer = Base58.Decode(str);
        var payload = DecodeRaw(buffer);
        if (payload == null)
        {
            throw new InvalidOperationException("Invalid checksum");
        }
        return payload;
    }

    private static Dictionary<string, string> prefixes = new Dictionary<string, string>
    {
        {"xpub", "0488b21e"},
        {"ypub", "049d7cb2"},
        {"Ypub", "0295b43f"},
        {"zpub", "04b24746"},
        {"Zpub", "02aa7ed3"},
        {"tpub", "043587cf"},
        {"upub", "044a5262"},
        {"Upub", "024289ef"},
        {"vpub", "045f1cf6"},
        {"Vpub", "02575483"}
    };

    public static string ChangeVersionBytes(string xpub, string targetFormat)
    {
        if (!prefixes.ContainsKey(targetFormat))
        {
            throw new ArgumentException("Invalid target version");
        }

        // Trim whitespace
        xpub = xpub.Trim();

        try
        {
            var data = Decode(xpub);
            var prefixBytes = HexToByteArray(prefixes[targetFormat]);

            for (int i = 0; i < prefixBytes.Length; i++) data[i] = prefixBytes[i];

            return Base58.Encode(data);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid extended public key", ex);
        }
    }
    public static byte[] HexToByteArray(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
}