using System;
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
//var block = await client.Chain_GetBlock("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");
//var statsHash = await client.Chain_GetBlockStats("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");
//var tips = await client.Chain_GetChainTips();
//var txStats = await client.Chain_GetChainTxStats(128);
//var deployInfo = await client.Chain_GetDeploymentInfo();
//var diff = await client.Chain_GetDifficulty();
//var mpEntry = await client.Chain_GetMempoolEntry("");
//var mpInfo = await client.Chain_GetMempoolInfo();
//var rmpData = await client.Chain_GetRawMempool();
//await client.Chain_GetTxOut("txId", 1, true);

//var memInfo = await client.Ctrl_GetMemoryInfo();
//var rpcInfo = await client.Ctrl_GetRpcInfo();
//var loggingInfo = await client.Ctrl_Logging();
//var up = await client.Ctrl_Uptime();

//var cnnCount = await client.NW_GetConnectionCount();


//var tx = await client.TX_GetRawTransaction(block.tx[0]);
//var addr = await client.Wallet_GetAddressInfo("1N1mCewkJPzYzxiacd7UrQ8hThtq9FJxH3");


Console.WriteLine("End");