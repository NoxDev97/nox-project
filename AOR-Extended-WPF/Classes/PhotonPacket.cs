using System;
using System.Collections.Generic;
using System.IO;

namespace AOR_Extended_WPF.Classes
{
    public class PhotonPacket
    {
        private readonly object _parent;
        private readonly Action<string, Dictionary<string, object>> _emit;
        private BinaryReader _payload;
        private ushort _peerId;
        private byte _flags;
        private byte _commandCount;
        private uint _timestamp;
        private uint _challenge;
        private readonly List<PhotonCommand> _commands;

        public PhotonPacket(object parent, byte[] buffer)
        {
            _parent = parent;
            _emit = (Action<string, Dictionary<string, object>>)((dynamic)parent).Emit;
            _payload = new BinaryReader(new MemoryStream(buffer));
            _commands = new List<PhotonCommand>();

            ParsePacket();
        }

        private void ParsePhotonHeader()
        {
            _peerId = ReadUInt16BigEndian(_payload);
            _flags = _payload.ReadByte();
            _commandCount = _payload.ReadByte();
            _timestamp = ReadUInt32BigEndian(_payload);
            _challenge = ReadUInt32BigEndian(_payload);
        }

        private void ParsePacket()
        {
            ParsePhotonHeader();

            for (int i = 0; i < _commandCount; i++)
            {
                _commands.Add(new PhotonCommand(this, _payload));
            }
        }

        private static ushort ReadUInt16BigEndian(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }

        private static uint ReadUInt32BigEndian(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
