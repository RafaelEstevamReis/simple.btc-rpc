namespace BtcRPC.Tests.Tools;

using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class CSV
{
    public static IEnumerable<string[]> LoadCSV(string path, char separator = ',')
        => File.ReadLines(path).Select(l => l.Split(','));
}
