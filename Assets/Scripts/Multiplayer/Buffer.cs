using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Buffer
{
    private byte[] _bytes;

    public int Length
    {
        get
        {
            return _bytes.Length;
        }
    }

    public byte[] Bytes
    {
        get
        {
            return _bytes;
        }
    }

    private Buffer(int size = 0)
    {
        if (size < 0) size = 0;
        _bytes = new byte[size];
    }

    public static Buffer Alloc(int size)
    {
        return new Buffer(size);
    }
    public static Buffer From(string txt)
    {
        Buffer b = new Buffer(txt.Length);
        b.WriteString(txt);
        return b;
    }

    public static Buffer From(byte[] items){
        Buffer b = new Buffer(items.Length);
        b.WriteBytes(items);
        return b;
    }

    

    public void Concat(byte[] newdata, int numOf_bytes = -1)
    {
        if (numOf_bytes < 0 || numOf_bytes > newdata.Length) numOf_bytes = newdata.Length;

        byte[] new_bytes = new byte[_bytes.Length + numOf_bytes];

        for (int i = 0;i < new_bytes.Length; i++) {
            if(i < _bytes.Length)
            {
                new_bytes[i] = _bytes[i];
            }
            else
            {
                new_bytes[i] = newdata[i - _bytes.Length];
            }
        }

        _bytes = new_bytes;
    }

    public void Concat (Buffer otherbuffer)
    {
        Concat(otherbuffer._bytes);
    }

    public void Clear()
    {
        _bytes = new byte[0];
    }

    public void Consume(int num_bytes)
    {
        int newLength = _bytes.Length - num_bytes;
        if (newLength >= _bytes.Length) return;

        if(newLength <= 0)
        {
            _bytes = new byte[0];
            return;
        }

        byte[] new_bytes = new byte[newLength];

        for(int i = 0; i < new_bytes.Length; i++)
        {
            new_bytes[i] = _bytes[i + num_bytes];
        }

        _bytes = new_bytes;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("<Buffer ");

        foreach (byte b in _bytes)
        {
            sb.Append("  ");
            sb.Append(b.ToString("x2"));
        }

        sb.Append(">");
        return sb.ToString();
    }

    #region Read Integers

    public byte ReadByte(int offset = 0)
    {
        return ReadUInt8(offset);
    }
    public byte ReadUInt8(int offset = 0)
    {
        if (offset < 0 || offset >= _bytes.Length)
        {
            Debug.LogError("Offest outside of byte array bounds");
            return 0;
        }
        return _bytes[offset];
    }

    public sbyte ReadInt8(int offset = 0)
    {
        return (sbyte)ReadByte(offset);
    }

    public ushort ReadUInt16LE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);

        return (ushort)((b << 8) | a);
    }
    public ushort ReadUInt16BE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);

        return (ushort)((a << 8) | b);
    }
    public short ReadInt16LE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);

        return (short)((b << 8) | a);
    }
    public short ReadInt16BE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);

        return (short)((a << 8) | b);
    }

    public uint ReadUInt32LE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);
        byte c = ReadByte(offset + 2);
        byte d = ReadByte(offset + 3);

        return (uint)((d << 24) | (c << 16) | (b << 8) | a);
    }
    public uint ReadUInt32BE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);
        byte c = ReadByte(offset + 2);
        byte d = ReadByte(offset + 3);

        return (uint)((a << 24) | (b << 16) | (c << 8) | d);
    }
    public int ReadInt32LE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);
        byte c = ReadByte(offset + 2);
        byte d = ReadByte(offset + 3);

        return (int)((d << 24) | (c << 16) | (b << 8) | a);
    }
    public int ReadInt32BE(int offset = 0)
    {
        byte a = ReadByte(offset);
        byte b = ReadByte(offset + 1);
        byte c = ReadByte(offset + 2);
        byte d = ReadByte(offset + 3);

        return (int)((a << 24) | (b << 16) | (c << 8) | d);
    }



    #endregion

    #region Write Integers

    public void WriteByte(byte val, int offset = 0)
    {
        WriteUInt8(val, offset);
    }

    public void WriteUInt8(byte val, int offset = 0)
    {
        if (offset < 0 || offset >= _bytes.Length) return;
        _bytes[offset] = val;
    }

    public void WriteBytes(byte[] vals, int offset = 0)
    {
        for (int i = 0; i < vals.Length; i++)
        {
            WriteByte(vals[i], offset + i);
        }
    }

    public void WriteInt8(sbyte val, int offset = 0)
    {
        WriteByte((byte)val, offset);
    }

    public void WriteUInt16LE(ushort val, int offset = 0)
    {
        WriteByte((byte)val, offset);
        WriteByte((byte)(val >> 8), offset + 1);
    }

    public void WriteUInt16BE(ushort val, int offset = 0)
    {
        WriteByte((byte)(val >> 8), offset);
        WriteByte((byte)val, offset + 1);
    }

    public void WriteInt16LE(short val, int offset = 0)
    {
        WriteByte((byte)val, offset);
        WriteByte((byte)(val >> 8), offset + 1);
    }

    public void WriteInt16BE(short val, int offset = 0)
    {
        WriteByte((byte)(val >> 8), offset);
        WriteByte((byte)val, offset + 1);
    }

    public void WriteUInt32LE(uint val, int offset = 0)
    {
        WriteByte((byte)val, offset);
        WriteByte((byte)(val >> 8), offset + 1);
        WriteByte((byte)(val >> 16), offset + 2);
        WriteByte((byte)(val >> 24), offset + 3);
    }

    public void WriteUInt32BE(uint val, int offset = 0)
    {
        WriteByte((byte)(val >> 24), offset);
        WriteByte((byte)(val >> 16), offset + 1);
        WriteByte((byte)(val >> 8), offset + 2);
        WriteByte((byte)val, offset + 3);
    }
    public void WriteInt32BE(int val, int offset = 0)
    {
        WriteByte((byte)(val >> 24), offset);
        WriteByte((byte)(val >> 16), offset + 1);
        WriteByte((byte)(val >> 8), offset + 2);
        WriteByte((byte)val, offset + 3);
    }

    public void WriteInt32LE(int val, int offset = 0)
    {
        WriteByte((byte)val, offset);
        WriteByte((byte)(val >> 8), offset + 1);
        WriteByte((byte)(val >> 16), offset + 2);
        WriteByte((byte)(val >> 24), offset + 3);
    }

    #endregion

    #region Read Floats
    public float ReadSingleBE(int offset = 0)
    {
        return BitConverter.ToSingle(_bytes, offset);
    }

    public float ReadSingleLE(int offset = 0)
    {
        byte[] temp = new byte[]
        {
            ReadByte(offset + 3),
            ReadByte(offset + 2),
            ReadByte(offset + 1),
            ReadByte(offset + 0)
        };

        return BitConverter.ToSingle(temp, 0);
    }

    public double ReadDoubleBE(int offset = 0)
    {
        return BitConverter.ToDouble(_bytes, offset);
    }

    public double ReadDoubleLE(int offset = 0)
    {
        byte[] temp = new byte[]
        {
            ReadByte(offset + 7),
            ReadByte(offset + 6),
            ReadByte(offset + 5),
            ReadByte(offset + 4),
            ReadByte(offset + 3),
            ReadByte(offset + 2),
            ReadByte(offset + 1),
            ReadByte(offset + 0)
        };

        return BitConverter.ToDouble(temp, 0);
    }
    #endregion

    #region Write Floats
    public void WriteSingleBE(float val, int offset = 0)
    {
        byte[] parts = BitConverter.GetBytes(val);

        WriteBytes(parts, offset);
    }

    public void WriteSingleLE(float val, int offset = 0)
    {
        byte[] parts = BitConverter.GetBytes(val);

        for (int i = 3; i >= 0; i--)
        {
            WriteByte(parts[i], offset + (3 - i));
        }
    }

    public void WriteDoubleBE(double val, int offset = 0)
    {
        byte[] parts = BitConverter.GetBytes(val);

        WriteBytes(parts, offset);
    }

    public void WriteDoubleLE(double val, int offset = 0)
    {
        byte[] parts = BitConverter.GetBytes(val);

        for (int i = 7; i >= 0; i--)
        {
            WriteByte(parts[i], offset + (7 - i));
        }
    }
    #endregion

    #region Read Strings

    public string ReadString(int offset = 0, int length = 0) {

        if (length <= 0) length = _bytes.Length;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            if (i + offset >= _bytes.Length) break;
            sb.Append((char)ReadByte(offset + i));
        }
        return sb.ToString();
    }

    #endregion

    #region Write Strings

    public void WriteString(string str, int offset = 0)
    {
        char[] chars = str.ToCharArray();
        for(int i = 0; i < chars.Length; i++)
        {
            if (offset + i >= _bytes.Length) break;
            char c = chars[i];
            WriteByte((byte)c, offset + i);
        }
    }

    #endregion

    #region Read Bools

    public bool ReadBool(int offset = 0)
    {
        return (ReadByte(offset) > 0);
    }

    public bool[] ReadBitField(int offset = 0)
    {
        bool[] res = new bool[8];
        byte b = ReadByte(offset);
        for (int i = 0; i < 8; i++)
        {
            res[i] = (b & 1 << i) > 0;
        }

        return res;
    }

    #endregion

    #region Write Bools

    public void WriteBool(bool val, int offset = 0)
    {
        byte b = (byte)(val ? 1 : 0);

        WriteByte(b, offset); 
    }

    public void WriteBitField(bool[] bits, int offset = 0)
    {
        if (bits.Length < 8) return;
        byte val = 0;

        for (int i = 0; i < 8; i++)
        {
            if (bits[i]) val |= (byte)(1 << i);
        }

        WriteByte(val, offset);
    }

    #endregion


}
