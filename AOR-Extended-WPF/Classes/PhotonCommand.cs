using System;
using System.Collections.Generic;
using System.IO;
using AOR_Extended_WPF.Classes;

namespace AOR_Extended_WPF.Classes
{
    public class PhotonCommand
    {
        private BinaryReader _payload;
        private readonly object _parent;
        private int _commandType;
        private int _channelId;
        private int _commandFlags;
        private int _commandLength;
        private int _sequenceNumber;
        private int _messageType;
        private Dictionary<string, object> _data;

        public PhotonCommand(object parent, BinaryReader payload)
        {
            _parent = parent;
            _payload = payload;
            _data = new Dictionary<string, object>();

            ParseCommand();
        }

        private void ParseCommandHeader()
        {
            try
            {
                _commandType = _payload.ReadByte();
                _channelId = _payload.ReadByte();
                _commandFlags = _payload.ReadByte();
                _payload.BaseStream.Seek(1, SeekOrigin.Current);
                _commandLength = ReadInt32BigEndian(_payload);
                _sequenceNumber = ReadInt32BigEndian(_payload);
            }
            catch (Exception)
            {
                // Handle or log the exception as necessary
            }
        }

        private void ParseCommand()
        {
            ParseCommandHeader();

            switch (_commandType)
            {
                // Unreliable Command
                case 7:
                    // Remove first 4 bytes to be reliable
                    _payload.BaseStream.Seek(4, SeekOrigin.Current);
                    _payload = new BinaryReader(new MemoryStream(_payload.ReadBytes((int)_payload.BaseStream.Length - 4)));
                    goto case 6; // Fall through to case 6
                // Reliable Command
                case 6:
                    ParseReliableCommand();
                    break;
                // Disconnect
                case 4:
                    // Handle disconnect if necessary
                    break;
            }
        }

        private void ParseReliableCommand()
        {
            // Read message type and remove first 2 bytes of the command
            _payload.BaseStream.Seek(1, SeekOrigin.Current);
            _messageType = _payload.ReadByte();
            _payload = new BinaryReader(new MemoryStream(_payload.ReadBytes((int)_payload.BaseStream.Length - 2)));

            switch (_messageType)
            {
                case 2:
                    _data = Protocol16Deserializer.DeserializeOperationRequest(_payload);
                    Emit("request", _data);
                    break;
                case 3:
                    _data = Protocol16Deserializer.DeserializeOperationResponse(_payload);
                    Emit("response", _data);
                    break;
                case 4:
                    _data = Protocol16Deserializer.DeserializeEventData(_payload);
                    Emit("event", _data);
                    break;
            }
        }

        private void Emit(string eventType, Dictionary<string, object> data)
        {
            // Implement event emitting logic
            // This can be implemented with event handlers or delegates in C#
        }

        private int ReadInt32BigEndian(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
