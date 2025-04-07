namespace Simple.BTC.Tools;

using Simple.BTC.Models.Blockchain;
using Simple.BTC.Models.RawTransactions;
using System;
using System.Threading.Tasks;

public static class ChainSearch
{
    /// <summary>
    /// Search blocks in blockchain
    /// </summary>
    /// <param name="client">Connected BTC RPC Client</param>
    /// <param name="firstBlock">First block to search</param>
    /// <param name="lastBlock">Last block to search (inclusive)</param>
    /// <param name="search">Callback with Block, return TRUE to stop searching</param>
    public static async Task<GetblockV2_Result?> SearchBlockAsync(this RPC_Client client, int firstBlock, int lastBlock, Func<GetblockV2_Result, bool> search)
    {
        for (int i = firstBlock; i <= lastBlock; i++)
        {
            // meucu
            var bStat = await client.Chain_GetBlockStats(i);
            var block = await client.Chain_GetBlock_Verbosity2(bStat.blockhash);

            if(search(block))
            {
                return block;
            }
        }
        return null;
    }

    /// <summary>
    /// Search transactions in blockchain
    /// </summary>
    /// <param name="client">Connected BTC RPC Client</param>
    /// <param name="firstBlock">First block to search</param>
    /// <param name="lastBlock">Last block to search (inclusive)</param>
    /// <param name="search">Callback with Block and Transaction, return TRUE to stop searching</param>
    /// <param name="progress">Current search block stats</param>
    public static async Task<RawTransacation_Result?> SearchTransactionAsync(this RPC_Client client, int firstBlock, int lastBlock, Func<GetblockV2_Result, RawTransacation_Result, bool> search, Action<GetBlockStats_Result>? progress = null)
    {
        for (int i = firstBlock; i <= lastBlock; i++)
        {
            // meucu
            var bStat = await client.Chain_GetBlockStats(i);
            progress?.Invoke(bStat);

            var block = await client.Chain_GetBlock_Verbosity2(bStat.blockhash);

            foreach(var tr in block.tx)
            {
                if(tr.blockhash == null) tr.blockhash = bStat.blockhash;
                if (search(block, tr))
                {
                    return tr;
                }
            }
        }
        return null;
    }

}
