﻿using System;
using System.Linq;

Console.WriteLine("Hello, World!");

var client = new Simple.BTC.RPC_Client("http://127.0.0.1:8332", "test", "test");

/*
 Require Config:
    server=1
    rpcbind=0.0.0.0
    rpcallowip=<your_network_range>
    rpcport=8332
    rpcauth=<username>:<hashed_password> ## https://jlopp.github.io/bitcoin-core-rpc-auth-generator/
    txindex=1
*/

//var info = await client.Chain_GetBlockchainInfo();
//var cnt = await client.Chain_GetBlockCount();
//var state = await client.Chain_GetChainStates();
//var statsHeight = await client.Chain_GetBlockStats(834718);
//var block834718 = await client.Chain_GetBlock(statsHeight.blockhash);
//var blockTx = await client.TX_GetRawTransaction(block834718.tx[0]);

//var block = await client.Chain_GetBlock("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");
//var statsHash = await client.Chain_GetBlockStats("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");
//var tips = await client.Chain_GetChainTips();
//var best = await client.Chain_GetBestBlockHash();
//var at1000 = await client.Chain_GetBlockHash(1000);
//var txStats = await client.Chain_GetChainTxStats(128);
//var deployInfo = await client.Chain_GetDeploymentInfo();
//var diff = await client.Chain_GetDifficulty();
//var mpEntry = await client.Chain_GetMempoolEntry("");
//var mpInfo = await client.Chain_GetMempoolInfo();
//var rmpData = await client.Chain_GetRawMempool();
//var txOut = await client.Chain_GetTxOut("txid", 0, true);

//var txOutSetInfo = await client.Chain_GetTxOutSetInfo(800_000);
//var txOutSetInfo = await client.Chain_GetTxOutSetInfo("00000000000000000002a7c4c1e48d76c5a37902165a270156b7a8d72728a054");

//var miningInfo = await client.Mining_GetMiningInfo();
//var rate = await client.Mining_GetHashRate_ExaHashes();

//var memInfo = await client.Ctrl_GetMemoryInfo();
//var rpcInfo = await client.Ctrl_GetRpcInfo();
//var loggingInfo = await client.Ctrl_Logging();
//var up = await client.Ctrl_Uptime();

//var cnnCount = await client.NW_GetConnectionCount();
//var netTotals = await client.NW_GetNetTotals();
//var nwInfo await client.NW_GetNetworkInfo();
//var banned = await client.NW_ListBanned();
//await client.NW_Ping();

//var fee = await client.Utils_EstimateSmartFee(5);
//var addresses = await client.Utils_DeriveAddresses("wpkh([d34db33f/84h/0h/0h]xpub6DJ2dNUysrn5Vt36jH2KLBT2i1auw1tTSSomg8PhqNiUtx8QX2SvC9nrHu81fT41fvDUnhMjEzQgXnQjKEu3oaqMSzhSrHMxyyoEAmUHQbY/0/*)#cjjspncu", 0, 2);
//var descInfo = await client.Utils_GetDescriptorInfo("wpkh([d34db33f/84h/0h/0h]xpub6DJ2dNUysrn5Vt36jH2KLBT2i1auw1tTSSomg8PhqNiUtx8QX2SvC9nrHu81fT41fvDUnhMjEzQgXnQjKEu3oaqMSzhSrHMxyyoEAmUHQbY/0/*)#cjjspncu");
//var validationResult = await client.Utils_ValidateAddress("1N1mCewkJPzYzxiacd7UrQ8hThtq9FJxH3"); // Invalid bc1q09vm5lfy0j5reeulh4x5752q25uqqvz34hufdl

//var tx = await client.TX_GetRawTransaction(block.tx[0]);
//var addr = await client.Wallet_GetAddressInfo("1N1mCewkJPzYzxiacd7UrQ8hThtq9FJxH3");
//var bal = await client.Wallet_GetBalances();
//var walletInfo = await client.Wallet_GetWalletInfo();
//var addr = await client.Wallet_GetNewAddress();


// TOOLS:

// Transaction Search
// // By Address
// //var foundTr = await Simple.BTC.Tools.ChainSearch.SearchTransactionAsync(client, firstBlock: 878777, lastBlock: 888888,
// //search: (block, tr) =>
// //{
// //    string searchForAddrContaining = "gZW2D"; // Coinbase Address
// //    var allAddresses = tr.vout.Select(o => o.scriptPubKey?.address ?? "").ToArray();
// //
// //    return allAddresses.Any(addr => addr.Contains(searchForAddrContaining));
// //},
// //progress: b =>
// //{
// //    Console.WriteLine($"{b.DateTime:yyyy-MM-dd HH:mm} Searching Block {b.height} Hash: {b.blockhash}...");
// //});

// // By Value
// //var foundTr = await Simple.BTC.Tools.ChainSearch.SearchTransactionAsync(client, firstBlock: 878777, lastBlock: 888888,
// //search: (block, tr) =>
// //{
// //    long searchForValueSats = 123456;
// //
// //    return tr.vout.Any(vo => vo.value == (searchForValueSats / 100_000_000M));
// //},
// //progress: b =>
// //{
// //    Console.WriteLine($"{b.DateTime:yyyy-MM-dd HH:mm} Searching Block {b.height} Hash: {b.blockhash}...");
// //});

//if (foundTr != null) Console.WriteLine($"FOUND: {foundTr.txid} Hash: {foundTr.blockhash}...");

; Console.WriteLine("End");