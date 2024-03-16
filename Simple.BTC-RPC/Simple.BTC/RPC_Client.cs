namespace Simple.BTC;

using Simple.API;
using Simple.BTC.Models;
using System;
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

        if (typeof(T) == typeof(string))
        {
            var r = await client.PostAsync<string>("/", data);
            if (!r.IsSuccessStatusCode)
            {
                var err = r.ParseErrorResponseData<RpcResult>();
                throw new RPCException(err.error);
            }
            return (T)(object)r.Data;
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
        var result = await rpc_call< Models.Blcokchain.GetChainTxStats_Result> (method: "getchaintxstats", nBlocks);
        return result;
    }

    public async Task<Models.RawTransactions.RawTransacation_Result> TX_GetRawTransaction(string tx)
    {
        var result = await rpc_call<Models.RawTransactions.RawTransacation_Result>(method: "getrawtransaction", tx, 2);
        return result;
    }

    public async Task<Models.Wallet.GetAddressInfo_Result> Wallet_GetAddressInfo(string address)
    {
        var result = await rpc_call<Models.Wallet.GetAddressInfo_Result>(method: "getaddressinfo", address);
        return result;
    }

}
