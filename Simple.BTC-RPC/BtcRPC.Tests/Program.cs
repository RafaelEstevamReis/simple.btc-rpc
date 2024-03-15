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
//var statsHash = await client.Chain_GetBlockStats("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");

//var block = await client.Chain_GetBlock("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09");
//var tx = await client.TX_GetRawTransaction(block.tx[0]);
//var addr = await client.Wallet_GetAddressInfo("1N1mCewkJPzYzxiacd7UrQ8hThtq9FJxH3");


Console.WriteLine("End");