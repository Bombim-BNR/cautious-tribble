using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BNR_CLIENT
{
    public class Client
    {
        private TcpClient _tcpClient;
        private StreamReader _reader;
        private StreamWriter _writer;

        public async Task Start(string ip, int port)
        {
            _tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(ip, port);
            Console.WriteLine("Connected to server.");

            var stream = _tcpClient.GetStream();
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            ListenForServerMessages();
        }

        private void ProcessServerMessage(string message)
        {
            // Update local game state based on the message
            Console.WriteLine("Game Update: " + message);
        }

        public void SendAction(string action)
        {
            _writer.WriteLine(action);
        }

        public void SendMove(string move)
        {
            if (_tcpClient.Connected)
            {
                _writer.WriteLine(move);
            }
        }

        private async void ListenForServerMessages()
        {
            while (_tcpClient.Connected)
            {
                var message = await _reader.ReadLineAsync();
                if (message != null)
                {
                    // Update local game state
                    Console.WriteLine("Game Update: " + message);
                }
            }
        }

    }

}
