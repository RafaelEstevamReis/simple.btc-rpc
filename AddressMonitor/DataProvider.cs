namespace AddressMonitor;

using Simple.BTC;
using Simple.Sqlite;
using System;
using System.Linq;
using System.Threading.Tasks;

public class DataProvider
{
    private ConnectionFactory db;
    private RPC_Client client;

    public DataProvider(ConnectionFactory db, RPC_Client client)
    {
        this.db = db;
        this.client = client;
    }

    public async Task Setup()
    {
        using var cnn = db.GetConnection();
        cnn.CreateTables()
           .Add<DBModels.ConfigKeys>()
           .Add<DBModels.MonitoredTransactions>()
           .Add<DBModels.MonitoredAddress>()
           .Add<DBModels.AddressTransactions>()
           .Add<DBModels.Transactions>()
           .Commit();
    }

    public DBModels.MonitoredAddress[] GetMonitoredAddresses()
    {
        using var cnn = db.GetConnection();
        return cnn.GetAll<DBModels.MonitoredAddress>()
                  .ToArray();
    }
    public DBModels.MonitoredTransactions[] GetMonitoredTxIds()
    {
        using var cnn = db.GetConnection();
        return cnn.GetAll<DBModels.MonitoredTransactions>()
                  .Where(o => o.Entry)
                  .ToArray();
    }
    public void AddMonitoredTxIds(string txId, string memo)
    {
        using var cnn = db.GetConnection();
        cnn.Insert(new DBModels.MonitoredTransactions()
        {
            TxID = txId,
            Description = memo,
            Entry = true,
        });
    }

    public async Task<DBModels.Transactions?> GetTransactionAsync(string txid)
    {
        using var cnn = db.GetConnection();
        var tr = cnn.Get<DBModels.Transactions>(txid);
        if (tr != null) return tr;

        var rawTx = await getRawTr(cnn, txid);
        if (rawTx == null) return null;

        tr = new DBModels.Transactions
        {
            TxID = rawTx.txid,
            BlockHash = rawTx.blockhash,
            DateTimeUTC = DateTime.UnixEpoch.AddSeconds(rawTx.blocktime),
        };
        cnn.Insert(tr, OnConflict.Replace);

        return tr;
    }
    private async Task<Simple.BTC.Models.RawTransactions.RawTransacation_Result?> getRawTr(ISqliteConnection cnn, string txid)
    {
        var rawTx = await client.TX_GetRawTransaction(txid);
        if (rawTx == null) return null;

        // Register all seen address
        var addr = rawTx.vout.Where(o => o.scriptPubKey.address != null)
                             .Select(v => new DBModels.AddressTransactions
                             {
                                 Id = $"{v.n}:{txid}",
                                 Address = v.scriptPubKey.address,
                                 TxId = txid,
                                 Value = v.value
                             });
        cnn.BulkInsert(addr, OnConflict.Ignore);
        return rawTx;
    }

    public async Task<int> UpdateMonitoredTxIdsAsync()
    {
        using var cnn = db.GetConnection();
        var trx = cnn.GetAll<DBModels.MonitoredTransactions>()
                    .Where(o => o.Entry)
                    .ToArray();

        foreach (var tx in trx)
        {
            var rawTx = await getRawTr(cnn, tx.TxID);
            if (rawTx == null) continue;

            var tr = new DBModels.Transactions
            {
                TxID = rawTx.txid,
                BlockHash = rawTx.blockhash,
                DateTimeUTC = DateTime.UnixEpoch.AddSeconds(rawTx.blocktime),
            };
            cnn.Insert(tr, OnConflict.Replace);
        }
        return trx.Length;
    }

    public DBModels.Transactions? OldestTransaction()
    {
        using var cnn = db.GetConnection();
        var trx = cnn.GetAll<DBModels.Transactions>()
                    .OrderBy(o => o.DateTimeUTC)
                    .ToArray();
        return trx.FirstOrDefault();
    }

    public async Task<long> GetCurrentBlockHeightAsync()
    {
        var info = await client.Chain_GetBlockchainInfo();
        return info.blocks;
    }
    public async Task<Simple.BTC.Models.Blockchain.GetblockV2_Result> GetBlockAsync(string blockHash)
    {
        var block = await client.Chain_GetBlock_Verbosity2(blockHash);

        return block;
    }
    public async Task<Simple.BTC.Models.Blockchain.GetblockV2_Result> GetBlockAsync(int height)
    {
        var stats = await client.Chain_GetBlockStats(height);
        return await GetBlockAsync(stats.blockhash);
    }

    public async Task<bool> AddMonitoredAddrAsync(string addr, string memo)
    {
        if (addr.Contains("/")) // derivation path
        {
            var addresses = await client.Utils_DeriveAddresses(addr, 0, 99);
            var mon = addresses.Select(a => new DBModels.MonitoredAddress()
            {
                Address = a,
                Description = memo,
            }).ToArray();

            using var cnn = db.GetConnection();
            cnn.BulkInsert(mon);

            return true;
        }
        else
        {
            var rst = await client.Utils_ValidateAddress(addr);
            if (!rst.isvalid) return false;

            using var cnn = db.GetConnection();
            cnn.Insert(new DBModels.MonitoredAddress()
            {
                Address = addr,
                Description = memo,
            });
            return true;
        }
    }

    public string? GetConfig(string key, string? defValue)
    {
        using var cnn = db.GetConnection();
        var cfg = cnn.Get<DBModels.ConfigKeys>(key);

        if (cfg == null) return defValue;
        return cfg.Value;
    }
    public void SetConfig(string key, string? value)
    {
        using var cnn = db.GetConnection();
        cnn.Insert(new DBModels.ConfigKeys
        {
            Key = key,
            Value = value
        }, OnConflict.Replace);
    }
}
