namespace Simple.BTC.Models;

using System;

public class RpcResult : RpcResult<object> { }
public class RpcResult<T>
{
    public T result { get; set; }
    public Error error { get; set; }
    public string id { get; set; }
}

public class Error
{
    public int code { get; set; }
    public string message { get; set; }
}

public class RPCException : Exception
{
    public Error Error { get; }
    public RPCException(Error e)
        : base($"[{e.code}] {e.message}")
    {
        Error = e;
    }
}
