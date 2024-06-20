using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using AOR_Extended_WPF.Classes;
using AOR_Extended_WPF.Views;
using PacketDotNet;
using SharpPcap;
using SharpPcap.WinPcap;

namespace AOR_Extended_WPF
{
    public partial class MainWindow : Window
    {
        private ICaptureDevice device;
        private PhotonPacketParser manager;

        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void NavigateToHomePage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Home Page");
            this.Dispatcher.Invoke(() =>
            {
                MainFrame.Navigate(new HomeView());
            });
        }
        private void NavigateToChestPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Chest Page");
            this.Dispatcher.Invoke(() =>
            { 
            MainFrame.Navigate(new ChestsView());
             });
        }

        private void NavigateToResourcesPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Resources Page");
            this.Dispatcher.Invoke(() =>
            {
                MainFrame.Navigate(new ResourcesView());
            });
        }

        private void NavigateToEnemiesPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Enemies Page");
                this.Dispatcher.Invoke(() =>
                {
                    MainFrame.Navigate(new EnemiesView());
                });
        }

        private void NavigateToMapPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Map Page");
                    this.Dispatcher.Invoke(() =>
                    {
                        MainFrame.Navigate(new MapView());
                    });
        }

        private void NavigateToIgnoreListPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Ignore List Page");
                        this.Dispatcher.Invoke(() =>
                        {
                            MainFrame.Navigate(new IgnoreListView());
                        });
        }

        private void NavigateToSettingsPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Navigating to Settings Page");
                            this.Dispatcher.Invoke(() =>
                            {
                                MainFrame.Navigate(new SettingsView());
                            });
        }

        private void NavigateToDrawingPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Opening Drawing Window");
            DrawingView drawingView = new DrawingView();
            drawingView.Show();
        }
        private void InitializeApp()
        {
            manager = new PhotonPacketParser();
            var devices = CaptureDeviceList.Instance;
            if (devices.Count < 1)
            {
                MessageBox.Show("No devices were found on this machine");
                return;
            }
            // Selecionar o primeiro dispositivo
            device = devices[0];
            device.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
            device.Open(DeviceMode.Promiscuous, 1000);
            device.Filter = "udp and (dst port 5056 or src port 5056)";
            device.StartCapture();
        }

        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            try
            {
                var rawPacket = e.Packet;
                var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
                var ipPacket = (IpPacket)packet.Extract(typeof(IpPacket));
                if (ipPacket != null)
                {
                    var udpPacket = (UdpPacket)ipPacket.Extract(typeof(UdpPacket));
                    if (udpPacket != null)
                    {
                        byte[] payload = udpPacket.PayloadData;
                        Console.WriteLine($"Payload length: {payload.Length}");
                        manager.Handle(payload);
                    }
                    else
                    {
                        Console.WriteLine("UDP packet extraction failed");
                    }
                }
                else
                {
                    Console.WriteLine("IP packet extraction failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during packet arrival: {ex.Message}");
            }
        }
    }

    public class PhotonPacketParser
    {
        public event Action<PhotonPacket> PacketReceived;

        public void Handle(byte[] buffer)
        {
            Console.WriteLine($"Handling buffer of length: {buffer.Length}");
            var packet = new PhotonPacket(buffer);
            PacketReceived?.Invoke(packet);
        }
    }

    public class PhotonPacket
    {
        private BinaryReader _payload;
        private ushort _peerId;
        private byte _flags;
        private byte _commandCount;
        private uint _timestamp;
        private uint _challenge;
        private readonly List<PhotonCommand> _commands;

        public PhotonPacket(byte[] buffer)
        {
            _payload = new BinaryReader(new MemoryStream(buffer));
            _commands = new List<PhotonCommand>();
            ParsePacket();
        }

        private void ParsePacket()
        {
            _peerId = ReadUInt16BigEndian(_payload);
            _flags = _payload.ReadByte();
            _commandCount = _payload.ReadByte();
            _timestamp = ReadUInt32BigEndian(_payload);
            _challenge = ReadUInt32BigEndian(_payload);

            for (int i = 0; i < _commandCount; i++)
            {
                _commands.Add(new PhotonCommand(_payload));
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
            if (bytes.Length < 4)
            {
                throw new ArgumentException("A matriz de destino não é grande o suficiente para copiar todos os itens da coleção.");
            }
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
    }

    public class PhotonCommand
    {
        private BinaryReader _payload;
        private int _commandType;
        private Dictionary<string, object> _data;

        public PhotonCommand(BinaryReader payload)
        {
            _payload = payload;
            _data = new Dictionary<string, object>();
            ParseCommand();
        }

        private void ParseCommand()
        {
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 1) return;
            _commandType = _payload.ReadByte();
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 1) return;
            _payload.BaseStream.Seek(1, SeekOrigin.Current);
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 4) return;
            int commandLength = ReadInt32BigEndian(_payload);
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 4) return;
            int sequenceNumber = ReadInt32BigEndian(_payload);

            switch (_commandType)
            {
                case 6:
                    ParseReliableCommand();
                    break;
                case 7:
                    if (_payload.BaseStream.Length - _payload.BaseStream.Position < 4) return;
                    _payload.BaseStream.Seek(4, SeekOrigin.Current);
                    _payload = new BinaryReader(new MemoryStream(_payload.ReadBytes((int)_payload.BaseStream.Length - 4)));
                    ParseReliableCommand();
                    break;
            }
        }

        private void ParseReliableCommand()
        {
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 1) return;
            _payload.BaseStream.Seek(1, SeekOrigin.Current);
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 1) return;
            int messageType = _payload.ReadByte();
            if (_payload.BaseStream.Length - _payload.BaseStream.Position < 2) return;
            _payload = new BinaryReader(new MemoryStream(_payload.ReadBytes((int)_payload.BaseStream.Length - 2)));

            switch (messageType)
            {
                case 2:
                    _data = Protocol16Deserializer.DeserializeOperationRequest(_payload);
                    break;
                case 3:
                    _data = Protocol16Deserializer.DeserializeOperationResponse(_payload);
                    break;
                case 4:
                    _data = Protocol16Deserializer.DeserializeEventData(_payload);
                    break;
            }
        }

        private static int ReadInt32BigEndian(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(4);
            if (bytes.Length < 4)
            {
                throw new ArgumentException("A matriz de destino não é grande o suficiente para copiar todos os itens da coleção.");
            }
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
