using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BNR_GAMEPLAY;

namespace BNR_SERVER
{
    public class Server
    {
        private TcpListener _tcpListener;
        private List<TcpClient> _clients = new List<TcpClient>();
        private Dictionary<TcpClient, Player> _clientPlayers = new Dictionary<TcpClient, Player>();
        private Game _game; // Assuming a single game for simplicity

        public Server(string ip, int port)
        {
            _tcpListener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public async Task Start()
        {
            _tcpListener.Start();
            Console.WriteLine("Server started.");
            while (true)
            {
                var client = await _tcpListener.AcceptTcpClientAsync();
                _clients.Add(client);
                HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                var stream = client.GetStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                while (client.Connected)
                {
                    var message = await reader.ReadLineAsync(); // Adjust based on your protocol
                    if (message != null)
                    {
                        ProcessMessage(client, message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
                _clients.Remove(client);
                _clientPlayers.Remove(client);
            }
        }

        private void ProcessMessage(TcpClient client, string message)
        {
            // Process the incoming message. This is where you'll update the game state and then broadcast the changes.
            BroadcastGameState();
        }

        private void BroadcastGameState()
        {
            var gameState = "GameState"; // Serialize your game state here
            foreach (var c in _clients)
            {
                var writer = new StreamWriter(c.GetStream(), Encoding.UTF8) { AutoFlush = true };
                writer.WriteLine(gameState);
            }
        }

        private void ProcessPlayerMove(string playerId, string move)
        {
            // Update game state based on the move
            var updatedGameState = "Some logic to update and serialize game state";

            BroadcastMessage(updatedGameState);
        }

        private void BroadcastMessage(string message)
        {
            foreach (var client in _clients)
            {
                var writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };
                writer.WriteLine(message);
            }
        }
    }

}
