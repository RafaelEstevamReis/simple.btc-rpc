namespace AddressMonitor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Monitor
{
    private DataProvider data;
    private bool running;

    public Monitor(DataProvider data)
    {
        this.data = data;
    }

    public async Task Run()
    {
        running = true;

        while (running)
        {
            Console.CursorVisible = false;
            Console.Clear();
            await mainMenu();
        }
    }

    private async Task mainMenu()
    {
        writeAt(2, 1, "[F1] Add TX");
        writeAt(15, 1, "[F2] Add Addr");
        writeAt(35, 1, "[F9] Update");
        writeAt(50, 1, "[ESC] Exit");

        var txs = data.GetMonitoredTxIds();
        for (int i = 0; i < txs.Length; i++)
        {
            writeAt(5, 3 + i * 2, $"[{(char)('A' + i)}] MEMO {txs[i].Description}");
            writeAt(5, 4 + i * 2, $"    TX {txs[i].TxID}");
        }

        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Escape)
        {
            running = false;
            return;
        }
        else if (key.Key == ConsoleKey.F1)
        {
            Console.Clear();
            writeAt(1, 1, "TX ADD ");

            writeAt(3, 2, "TXID: ");
            var tx = Console.ReadLine();
            if (string.IsNullOrEmpty(tx)) return;

            writeAt(3, 3, "Memo: ");
            var memo = Console.ReadLine();
            if (string.IsNullOrEmpty(memo)) return;

            data.AddMonitoredTxIds(tx, memo);
            await menu_DetailTx(tx);
        }
        else if (key.Key == ConsoleKey.F2)
        {
            Console.Clear();
            writeAt(1, 1, "Address ADD ");

            writeAt(3, 2, "ADDR: ");
            var addr = Console.ReadLine();
            if (string.IsNullOrEmpty(addr)) return;

            writeAt(3, 3, "Memo: ");
            var memo = Console.ReadLine();
            if (string.IsNullOrEmpty(memo)) return;

            if (addr[1..4] == "pub" && !addr.Contains("/"))
            {
                writeAt(3, 4, "Path: ");
                var path = Console.ReadLine();

                writeAt(3, 5, "Fingerprint: ");
                var fingerprint = Console.ReadLine();

                var descriptor = DescriptorHelper.ToDescriptor(addr, fingerprint, path, true);
                addr = descriptor;
            }

            await data.AddMonitoredAddrAsync(addr, memo);
        }
        else if (key.Key == ConsoleKey.F9)
        {
            await menu_Update();
        }
        else if (key.KeyChar >= 'a' && key.KeyChar <= 'z')
        {
            var ix = key.KeyChar - 'a';

            if (ix >= txs.Length) return;
            await menu_DetailTx(txs[ix].TxID);
        }
    }

    private async Task menu_DetailTx(string tr)
    {
        Console.Clear();
        var txInfo = await data.GetTransactionAsync(tr);
        txInfo = txInfo;
    }
    private async Task menu_Update()
    {
        Console.Clear();
        Console.WriteLine("Lendo Transactions ...");
        var count = await data.UpdateMonitoredTxIdsAsync();
        Console.WriteLine("> Done " + count);
        Console.WriteLine("");

        var oldestTx = data.OldestTransaction();
        if (oldestTx == null)
        {

        }

        var currentHeight = await data.GetCurrentBlockHeightAsync();
        var firstBlock = await data.GetBlockAsync(oldestTx.BlockHash);
        var firstBlockHeight = firstBlock.height;
        Console.WriteLine($"Scanning from #{firstBlock.height} to #{currentHeight}");

        var cfgLastUpdateBlock = data.GetConfig("UPDATE.LAST_BLOCK", null);
        if (cfgLastUpdateBlock != null)
        {
            if (long.TryParse(cfgLastUpdateBlock, out long h))
            {
                Console.WriteLine($"Resuming from #{h}");
                firstBlockHeight = h;
            }
        }

        var monAddr = data.GetMonitoredAddresses();
        var hshAddr = new HashSet<string>(monAddr.Select(o => o.Address));

        for (long i = firstBlockHeight + 1; i < currentHeight; i++)
        {
            Console.WriteLine($"Reading Block #{i}");
            if (Console.KeyAvailable)
            {
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine($"BREAK");
                    break;
                }
            }

            try
            {
                var block = await data.GetBlockAsync((int)i);

                foreach (var tx in block.tx)
                {
                    bool hasVOutAddr = tx.vout.Any(vo => hshAddr.Contains(vo?.scriptPubKey?.address ?? ""));
                    if (!hasVOutAddr) continue;

                    var add = monAddr.Where(o => tx.vout.Any(t => t?.scriptPubKey?.address == o.Address)).ToArray();
                    await data.GetTransactionAsync(tx.txid);

                    Console.WriteLine("TX " + tx.txid);
                }
                data.SetConfig("UPDATE.LAST_BLOCK", i.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERR] " + ex.ToString());
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Done");
        Console.ReadKey();
    }


    private static void writeAt(int x, int y, string content)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(content);
    }
}
