using Simple.Sqlite;
using System;
using System.IO;

Console.WriteLine("Connecting to Node");
var client = new Simple.BTC.RPC_Client("http://192.168.1.1:8332", "test", "test");
await client.NW_Ping();

Console.WriteLine("Opening Database");
var pwd = ReadPassword(">> Password: ");
if (string.IsNullOrEmpty(pwd))
{
    Console.WriteLine("END");
    return;
}

string dbFile = "data_enc.db";
string bkpFile = "data_enc.bak.db";
var fiDB = new FileInfo(dbFile);
var fiBak = new FileInfo(bkpFile);

if (fiDB.Exists)
{
    if(fiBak.Exists)
    {
        var ageDiff = fiDB.LastWriteTime - fiBak.LastWriteTime;
        var minDiff = Math.Abs(ageDiff.TotalMinutes);

        if(minDiff > 5)
        {
            fiBak.Delete();
            fiDB.CopyTo(fiBak.FullName);
        }
    }
    else
    {
        fiDB.CopyTo(fiBak.FullName);
    }
}

var db = ConnectionFactory.FromFile(dbFile, pwd);
Console.WriteLine("Cleaning some data");
pwd = null;
GC.Collect();

Console.WriteLine("Initializing");
var data = new AddressMonitor.DataProvider(db, client);
await data.Setup();

var mon = new AddressMonitor.Monitor(data);
await mon.Run();

static string ReadPassword(string prompt)
{
    // Discard
    while (Console.KeyAvailable) Console.ReadKey(true);

    Console.Write(prompt);
    string password = "";
    ConsoleKeyInfo info = Console.ReadKey(true);
    while (info.Key != ConsoleKey.Enter)
    {
        if (info.Key == ConsoleKey.Backspace)
        {
            if (password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        }
        else
        {
            password += info.KeyChar;
            Console.Write("*");
        }
        info = Console.ReadKey(true);
    }
    Console.WriteLine("");
    return password;
}
