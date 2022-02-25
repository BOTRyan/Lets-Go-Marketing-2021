using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketBuilder
{

    public static Buffer Join(string room = "HOST")
    {
        Buffer packet = Buffer.Alloc(8);

        packet.WriteString("JOIN");
        packet.WriteString(room, 4);
        return packet;
    }

    public static Buffer Ready(string name, int avatar)
    {
        int packetLength = 6 + name.Length;
        Buffer packet = Buffer.Alloc(packetLength);

        packet.WriteString("REDY");
        packet.WriteUInt8((byte)name.Length, 4);
        packet.WriteUInt8((byte)avatar, 5);
        packet.WriteString(name, 6);

        return packet;
    }

    public static Buffer Start()
    {
        Buffer packet = Buffer.Alloc(4);
        packet.WriteString("STRT");
        return packet;
    }

    public static Buffer Spin()
    {
        return null;
    }
}
