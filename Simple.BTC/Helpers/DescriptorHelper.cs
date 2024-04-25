using Simple.BTC.Helpers;
using System.Collections.Generic;
using System.Linq;

// https://github.com/bitcoin/bitcoin/blob/master/test/functional/test_framework/descriptors.py
public class DescriptorHelper
{
    private const string INPUT_CHARSET = "0123456789()[],'/*abcdefgh@:$%{}IJKLMNOPQRSTUVWXYZ&+-.;<=>?!^_|~ijklmnopqrstuvwxyzABCDEFGH`#\"\\ ";
    private const string CHECKSUM_CHARSET = "qpzry9x8gf2tvdw0s3jn54khce6mua7l";
    private static readonly ulong[] GENERATOR = { 0xf5dee51989, 0xa9fdca3312, 0x1bab10e32d, 0x3706b1677a, 0x644d626ffd };

    public static ulong DescsumPolymod(List<int> symbols)
    {
        ulong chk = 1;
        foreach (var value in symbols)
        {
            ulong top = chk >> 35;
            chk = (chk & 0x7ffffffff) << 5 ^ (ulong)value;
            for (int i = 0; i < 5; i++)
            {
                chk ^= (top >> i & 1) != 0 ? GENERATOR[i] : 0;
            }
        }
        return chk;
    }

    public static List<int> DescsumExpand(string s)
    {
        List<int> groups = new List<int>();
        List<int> symbols = new List<int>();
        foreach (char c in s)
        {
            if (!INPUT_CHARSET.Contains(c)) throw new System.Exception("Invalid character");

            int v = INPUT_CHARSET.IndexOf(c);
            symbols.Add(v & 31);
            groups.Add(v >> 5);
            if (groups.Count == 3)
            {
                symbols.Add(groups[0] * 9 + groups[1] * 3 + groups[2]);
                groups.Clear();
            }
        }
        if (groups.Count == 1)
        {
            symbols.Add(groups[0]);
        }
        else if (groups.Count == 2)
        {
            symbols.Add(groups[0] * 3 + groups[1]);
        }
        return symbols;
    }

    public static string DescsumCreate(string s)
    {
        var symbols = DescsumExpand(s).Concat(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }).ToList();
        var checksum = DescsumPolymod(symbols) ^ 1;
        return s + "#" + string.Join("", Enumerable.Range(0, 8).Select(i => CHECKSUM_CHARSET[(int)((checksum >> (5 * (7 - i))) & 31)]));
    }


    public static string ToDescriptor(string pub, string fingerprint, string path, bool includeChecksum)
    {
        if (path.StartsWith("m/")) path = path.Substring(2);

        var xpub = PubCovnerter.ChangeVersionBytes(pub, "xpub");
        var descpt = $"wpkh([{fingerprint}/{path.Replace('\'', 'h')}]{xpub}/0/*)";

        if (includeChecksum)
        {
            descpt = DescsumCreate(descpt);
        }

        return descpt;
    }
}
