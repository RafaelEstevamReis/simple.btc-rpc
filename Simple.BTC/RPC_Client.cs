namespace Simple.BTC;

using Simple.API;
using Simple.BTC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class RPC_Client
{
    // https://bitcoincore.org/en/doc/26.0.0/rpc/

    ClientInfo client;
    public RPC_Client(string rpcAddress, string user, string pass)
    {
        client = new ClientInfo(rpcAddress);

        var str = $"{user}:{pass}";
        var b64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(str));
        client.SetAuthorization("Basic " + b64);
    }

    public ClientInfo InternalRestClient => client;

    private async Task<T> rpc_call<T>(string method, params object[]? pars)
        => await rpc_call<T>(client, "simple.btc-rpc", method, pars);
    private static async Task<T> rpc_call<T>(ClientInfo client, string id, string method, params object[]? pars)
    {
        var data = new
        {
            jsonrpc = "1.0",
            id,
            method,
            @params = pars
        };

        if (pars != null && pars.Length == 1 && pars[0] == null) pars = null;

        if (typeof(T) == typeof(RawJson))
        {
            var r = await client.PostAsync<string>("/", data);
            if (!r.IsSuccessStatusCode)
            {
                var err = r.ParseErrorResponseData<RpcResult>();
                throw new RPCException(err.error);
            }
            var rj = new RawJson()
            {
                Value = r.Data,
            };
            return (T)(object)rj;
        }
        else
        {
            var r = await client.PostAsync<RpcResult<T>>("/", data);
            if (!r.IsSuccessStatusCode)
            {
                var err = r.ParseErrorResponseData<RpcResult>();
                throw new RPCException(err.error);
            }
            // Check BTC error
            return r.Data.result;
        }

    }

    public async Task<Models.Blcokchain.Getblock_Result> Chain_GetBlock(string blockId)
    {
        var result = await rpc_call<Models.Blcokchain.Getblock_Result>(method: "getblock", blockId);
        return result;
    }
    public async Task<Models.Blcokchain.GetBlockchainInfo_Result> Chain_GetBlockchainInfo()
    {
        var result = await rpc_call<Models.Blcokchain.GetBlockchainInfo_Result>(method: "getblockchaininfo");
        return result;
    }
    public async Task<int> Chain_GetBlockCount()
    {
        var result = await rpc_call<int>(method: "getblockcount");
        return result;
    }
    public async Task<Models.Blcokchain.GetBlockStats_Result> Chain_GetBlockStats(string blockId)
    {
        var result = await rpc_call<Models.Blcokchain.GetBlockStats_Result>(method: "getblockstats", blockId);
        return result;
    }
    public async Task<Models.Blcokchain.GetBlockStats_Result> Chain_GetBlockStats(int height)
    {
        var result = await rpc_call<Models.Blcokchain.GetBlockStats_Result>(method: "getblockstats", height);
        return result;
    }
    public async Task<Models.Blcokchain.GetChainStates_Result> Chain_GetChainStates()
    {
        var result = await rpc_call<Models.Blcokchain.GetChainStates_Result>(method: "getchainstates");
        return result;
    }
    public async Task<Models.Blcokchain.GetChainTips_Result[]> Chain_GetChainTips()
    {
        var result = await rpc_call<Models.Blcokchain.GetChainTips_Result[]>(method: "getchaintips");
        return result;
    }
    public async Task<Models.Blcokchain.GetChainTxStats_Result> Chain_GetChainTxStats(int nBlocks)
    {
        var result = await rpc_call<Models.Blcokchain.GetChainTxStats_Result>(method: "getchaintxstats", nBlocks);
        return result;
    }
    public async Task<Models.Blcokchain.GetDeploymentInfo_Result> Chain_GetDeploymentInfo()
    {
        var result = await rpc_call<Models.Blcokchain.GetDeploymentInfo_Result>(method: "getdeploymentinfo");
        return result;
    }
    public async Task<decimal> Chain_GetDifficulty()
    {
        var result = await rpc_call<decimal>(method: "getdifficulty");
        return result;
    }
    public async Task<Models.Blcokchain.GetMempoolEntry_Result> Chain_GetMempoolEntry(string txId)
    {
        var result = await rpc_call<Models.Blcokchain.GetMempoolEntry_Result>(method: "getmempoolentry", txId);
        return result;
    }
    public async Task<Models.Blcokchain.GetMempoolInfo_Result> Chain_GetMempoolInfo()
    {
        var result = await rpc_call<Models.Blcokchain.GetMempoolInfo_Result>(method: "getmempoolinfo");
        return result;
    }
    public async Task<Dictionary<string, Models.Blcokchain.GetWarMempool_Result>> Chain_GetRawMempool()
    {
        var result = await rpc_call<Dictionary<string, Models.Blcokchain.GetWarMempool_Result>>(method: "getrawmempool", true);
        return result;
    }
    public async Task<Models.Blcokchain.GetTxOut_Result> Chain_GetTxOut(string txid, int n, bool includeMempool = true)
    {
        var result = await rpc_call<Models.Blcokchain.GetTxOut_Result>(method: "gettxout", txid, n, includeMempool);
        return result;
    }

    public async Task<Models.Control.GetMemoryInfo_Result> Ctrl_GetMemoryInfo()
    {
        var result = await rpc_call<Models.Control.GetMemoryInfo_Result>(method: "getmemoryinfo");
        return result;
    }
    public async Task<Models.Control.GetRpcInfo_Result> Ctrl_GetRpcInfo()
    {
        var result = await rpc_call<Models.Control.GetRpcInfo_Result>(method: "getrpcinfo");
        return result;
    }
    public async Task<Dictionary<string, bool>> Ctrl_Logging()
    {
        var result = await rpc_call<Dictionary<string, bool>>(method: "logging");
        return result;
    }
    public async Task<TimeSpan> Ctrl_Uptime()
    {
        var result = await rpc_call<long>(method: "uptime");
        return TimeSpan.FromSeconds(result);
    }

    public async Task<int> NW_GetConnectionCount()
    {
        var result = await rpc_call<int>(method: "getconnectioncount");
        return result;
    }
    public async Task<Models.Network.GetNetTotals_Result> NW_GetNetTotals()
    {
        var result = await rpc_call<Models.Network.GetNetTotals_Result>(method: "getnettotals");
        return result;
    }
    public async Task<Models.Network.GetNetworkInfo_Result> NW_GetNetworkInfo()
    {
        var result = await rpc_call<Models.Network.GetNetworkInfo_Result>(method: "getnetworkinfo");
        return result;
    }
    public async Task<Models.Network.ListBanned_Result[]> NW_ListBanned()
    {
        var result = await rpc_call<Models.Network.ListBanned_Result[]>(method: "listbanned");
        return result;
    }
    public async Task NW_Ping()
    {
        await rpc_call<string>(method: "ping");
    }

    public async Task<Models.RawTransactions.RawTransacation_Result> TX_GetRawTransaction(string tx)
    {
        var result = await rpc_call<Models.RawTransactions.RawTransacation_Result>(method: "getrawtransaction", tx, 2);
        return result;
    }
    public async Task<Models.Wallet.GetBalances_Result> Wallet_GetBalances()
    {
        var result = await rpc_call<Models.Wallet.GetBalances_Result>(method: "getbalances");
        return result;
    }
    public async Task<Models.Wallet.GetWalletInfo_Result> Wallet_GetWalletInfo()
    {
        var result = await rpc_call<Models.Wallet.GetWalletInfo_Result>(method: "getwalletinfo");
        return result;
    }
    public async Task<Models.Wallet.GetAddressInfo_Result> Wallet_GetAddressInfo(string address)
    {
        var result = await rpc_call<Models.Wallet.GetAddressInfo_Result>(method: "getaddressinfo", address);
        return result;
    }
    public async Task<string> Wallet_GetNewAddress(string? label = null)
    {
        var a = await rpc_call<RawJson>(method: "getnewaddress", label);
        var result = await rpc_call<string>(method: "getnewaddress", label);
        return result;
    }

    internal class RawJson
    {
        public string Value { get; set; } = string.Empty;
    }

}
