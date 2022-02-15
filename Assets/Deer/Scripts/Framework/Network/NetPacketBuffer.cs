﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-09-05 11-17-12  
//修改作者 : 杜鑫 
//修改时间 : 2021-09-05 11-17-12  
//版 本 : 0.1 
// ===============================================
using System.IO;
using System.Text;
using System;
using LuaInterface;
using GameFramework;

public class NetPacketBuffer
{
    MemoryStream stream = null;
    BinaryWriter writer = null;
    BinaryReader reader = null;
    public NetPacketBuffer(byte[] data = null)
    {
        if (data != null)
        {
            stream = new MemoryStream(data);
            reader = new BinaryReader(stream);
        }
        else
        {
            stream = new MemoryStream();
            writer = new BinaryWriter(stream);
        }
    }
    public void Close()
    {
        writer?.Close();
        reader?.Close();
        stream?.Close();
        writer = null;
        reader = null;
        stream = null;
    }
    public void WriteStream(Stream memory) 
    {
        stream = (MemoryStream)memory;
        reader = new BinaryReader(stream);
    }

    public void WriteByte(byte v)
    {
        writer.Write(v);
    }

    public void WriteInt(int v)
    {
        writer.Write((int)v);
    }

    public void WriteShort(ushort v)
    {
        writer.Write((ushort)v);
    }

    public void WriteLong(long v)
    {
        writer.Write((long)v);
    }

    public void WriteFloat(float v)
    {
        byte[] temp = BitConverter.GetBytes(v);
        Array.Reverse(temp);
        writer.Write(BitConverter.ToSingle(temp, 0));
    }

    public void WriteDouble(double v)
    {
        byte[] temp = BitConverter.GetBytes(v);
        Array.Reverse(temp);
        writer.Write(BitConverter.ToDouble(temp, 0));
    }

    public void WriteString(string v)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(v);
        writer.Write(bytes);
    }

    public void WriteBytes(byte[] v)
    {
        writer.Write(v);
    }

    public byte ReadByte()
    {
        return reader.ReadByte();
    }

    public int ReadInt()
    {
        return (int)reader.ReadInt32();
    }

    public ushort ReadShort()
    {
        return (ushort)reader.ReadInt16();
    }

    public long ReadLong()
    {
        return (long)reader.ReadInt64();
    }

    public float ReadFloat()
    {
        byte[] temp = BitConverter.GetBytes(reader.ReadSingle());
        Array.Reverse(temp);
        return BitConverter.ToSingle(temp, 0);
    }

    public double ReadDouble()
    {
        byte[] temp = BitConverter.GetBytes(reader.ReadDouble());
        Array.Reverse(temp);
        return BitConverter.ToDouble(temp, 0);
    }

    public string ReadString()
    {
        int len = (int)(stream.Length - stream.Position);
        byte[] buffer = new byte[len];
        buffer = reader.ReadBytes(len);
        return Encoding.UTF8.GetString(buffer);
    }

    public byte[] ReadBytes()
    {
        int len = (int)(stream.Length - stream.Position);
        return reader.ReadBytes(len);
    }

    public byte[] ToBytes()
    {
        writer.Flush();
        return stream.ToArray();
    }

    public MemoryStream ToMemory()
    {
        writer.Flush();
        return stream;
    }

    public void Flush()
    {
        writer.Flush();
    }

    public LuaByteBuffer ReadBuffer()
    {
        byte[] bytes = ReadBytes();
        return new LuaByteBuffer(bytes);
    }
}
