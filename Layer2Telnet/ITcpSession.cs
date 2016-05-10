using System;
namespace Layer2Net
{
    public interface ITcpSession
    {
        void Close();
        uint HashCode { get; }
        bool IsOpen { get; }
        string Name { get; }
        ushort LocalPort { get; }
        void Open();
        void ProcessTCP(PcapDotNet.Packets.IpV4.IpV4Datagram packet);
        void SendPacket(byte[] data);
    }
}
