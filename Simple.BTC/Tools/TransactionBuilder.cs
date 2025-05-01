namespace Simple.BTC.Tools;

using Simple.BTC.Helpers;
using System;
using System.Text;

public enum OPCODES : byte
{
    OP_RETURN = 0x6a,
}

public class TransactionBuilder
{
    public static string CreateOpReturnTextOutputTransaction(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        if (bytes.Length > 74) throw new InvalidOperationException($"Data must be smaller than 75 bytes. Current Size: {bytes.Length}");

        using var builder = new ByteBuilder();
        builder.Append((byte)OPCODES.OP_RETURN);
        builder.Append((byte)bytes.Length);
        builder.Append(bytes);
        return builder.ToHex();
    }

}
