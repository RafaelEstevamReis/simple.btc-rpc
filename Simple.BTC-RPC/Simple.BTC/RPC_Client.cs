﻿namespace Simple.BTC;

using Simple.API;
using Simple.BTC.Models;
using Simple.BTC.Models.RawTransactions;
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
            r.EnsureSuccessStatusCode<RpcResult<object>>();
            return (T)(object)r.Data;
        }
        else
        {
            var r = await client.PostAsync<RpcResult<T>>("/", data);
            r.EnsureSuccessStatusCode<RpcResult<object>>();
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

    public async Task<RawTransacation_Result> TX_GetRawTransaction(string tx)
    {
        var result = await rpc_call<RawTransacation_Result>(method: "getrawtransaction", tx, 2);
        return result;
    }

}
