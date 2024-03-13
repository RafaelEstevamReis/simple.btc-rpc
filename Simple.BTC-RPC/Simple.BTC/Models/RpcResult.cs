﻿namespace Simple.BTC.Models;

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
