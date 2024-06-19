using System;
using System.IO;
using System.Collections.Generic;

namespace AOR_Extended_WPF.Classes
{
    public class PhotonPacketParser
    {
        public event Action<PhotonPacket> PacketReceived;

        public void Handle(byte[] buffer)
        {
            var packet = new PhotonPacket(this, buffer);
            PacketReceived?.Invoke(packet);
        }
    }
}
