namespace Simple.BTC.Helpers;

using System;
using System.Buffers;

public class ByteBuilder : IDisposable
{
    private byte[] _buffer;
    private int _position;
    private const int DefaultCapacity = 128;
    private const string hex = "0123456789abcdef";

    public int Length => _position;

    public ByteBuilder(int initialCapacity = DefaultCapacity)
    {
        _buffer = ArrayPool<byte>.Shared.Rent(initialCapacity);
        _position = 0;
    }

    public ByteBuilder Append(byte value)
    {
        EnsureCapacity(_position + 1);
        _buffer[_position++] = value;
        return this;
    }

    public ByteBuilder Append(byte[] value)
    {
        if (value == null || value.Length == 0)
            return this;

        EnsureCapacity(_position + value.Length);
        value.CopyTo(_buffer.AsSpan(_position));
        _position += value.Length;
        return this;
    }

    public ByteBuilder Append(byte[] value, int startIndex, int length)
    {
        if (value == null || length == 0)
            return this;
        if (startIndex < 0 || length < 0 || startIndex + length > value.Length)
            throw new ArgumentOutOfRangeException();

        EnsureCapacity(_position + length);
        value.AsSpan(startIndex, length).CopyTo(_buffer.AsSpan(_position));
        _position += length;
        return this;
    }

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity <= _buffer.Length)
            return;

        // Calcula novo tamanho (dobra o atual ou usa o mínimo necessário)
        int newCapacity = Math.Max(_buffer.Length * 2, requiredCapacity);
        byte[] newBuffer = ArrayPool<byte>.Shared.Rent(newCapacity);

        // Copia dados existentes para o novo buffer
        _buffer.AsSpan(0, _position).CopyTo(newBuffer.AsSpan());
        ArrayPool<byte>.Shared.Return(_buffer); // Devolve o buffer antigo
        _buffer = newBuffer;
    }

    public byte[] ToArray()
    {
        byte[] result = new byte[_position];
        _buffer.AsSpan(0, _position).CopyTo(result.AsSpan());
        return result;
    }
    public string ToHex()
    {
        char[] hex = new char[_position * 2];
        for (int i = 0; i < _position; i++)
        {
            hex[i * 2] = ByteBuilder.hex[_buffer[i] >> 4];
            hex[i * 2 + 1] = ByteBuilder.hex[_buffer[i] & 0x0F];
        }
        return new string(hex);
    }


    public void Clear()
    {
        _position = 0;
    }

    public void Dispose()
    {
        if (_buffer != null)
        {
            ArrayPool<byte>.Shared.Return(_buffer);
            _buffer = null;
            _position = 0;
        }
    }
}