# simple.btc-rpc

[![.NET](https://github.com/RafaelEstevamReis/simple.btc-rpc/actions/workflows/dotnet.yml/badge.svg)](https://github.com/RafaelEstevamReis/simple.btc-rpc)
[![NuGet](https://img.shields.io/nuget/v/Simple.BTC)](https://www.nuget.org/packages/Simple.BTC)


A simple C# BTC Core RPC Rest API implementation

Bitcoin Core API Docs: https://bitcoincore.org/en/doc/26.0.0/rpc/

Some required configuration:
~~~
server=1
rpcbind=0.0.0.0 ## binding IP
rpcallowip=<your_network_range>
rpcport=8332
rpcauth=<username>:<hashed_password>
txindex=1
~~~

* I used [this jlopp site](https://jlopp.github.io/bitcoin-core-rpc-auth-generator/) site to generate the user row
* Avoid binding 0.0.0.0, it will allow ANY ip, must also configure the allowed network range
* txindex: Allow to use RawTransaction calls, allocate more space 5~10%
