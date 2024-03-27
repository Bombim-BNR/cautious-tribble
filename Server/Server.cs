using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BNR_GAMEPLAY;
using Newtonsoft.Json;

public class Server
{
    private TcpListener tcpListener;
    private List<TcpClient> clients = new List<TcpClient>();
    private bool gameInProgress = false;
    private Game? _game;
    private List<Player> _players = new List<Player>();

    public async Task StartServer(int port, Game? game)
    {
        _game = game;

        // This will listen on all network interfaces
        tcpListener = new TcpListener(IPAddress.Any, port);

        try
        {
            tcpListener.Start();
            Console.WriteLine("Server started...");
            await AcceptClients();
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"SocketException: {ex.Message}");
            // Handle further, maybe retry with a different port or log the error.
        }
    }


    private async Task AcceptClients()
    {
        while (!gameInProgress)
        {
            TcpClient newClient = await tcpListener.AcceptTcpClientAsync();
            clients.Add(newClient);
            ProcessClient(newClient);
        }
    }

    private async void ProcessClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            await ProcessMessageAsync(client, message);
        }
    }

    private async Task ProcessMessageAsync(TcpClient client, string message)
    {
        if (message.StartsWith("newPlayer:"))
        {
            var playerInfoJson = message.Substring("newPlayer:".Length);
            Player newPlayer = JsonConvert.DeserializeObject<Player>(playerInfoJson);
            _players.Add(newPlayer);

            await NotifyPlayersListUpdated();
        }
    }

    private async Task NotifyPlayersListUpdated()
    {
        var playerList = JsonConvert.SerializeObject(_players);
        foreach (var client in clients)
        {
            await SendMessageAndGetResponse(client, $"playersUpdate:{playerList}");
        }
    }

    public async Task<string> SendMessageAndGetResponse(TcpClient client, string message)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = Encoding.ASCII.GetBytes(message);

        await stream.WriteAsync(buffer, 0, buffer.Length);
        buffer = new byte[1024];

        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

        return response;
    }

    public async Task GameLoopAsync()
    {
        gameInProgress = true;
        bool isRunning = true;
        foreach (TcpClient client1 in clients)
        {
            string updated = await SendMessageAndGetResponse(client1, "check");
        }
        while (isRunning)
        {
            foreach(TcpClient client in clients)
            {
                Console.WriteLine("Stage: turn awaiting");
                string response = await SendMessageAndGetResponse(client, "turn");
                Console.WriteLine("Stage: next send");
                foreach (TcpClient client1 in clients)
                {
                    string updated = await SendMessageAndGetResponse(client1, "next");
                }
                Console.WriteLine($"Stage: update send: {response}");
                foreach (TcpClient client1 in clients)
                {
                    string updated = await SendMessageAndGetResponse(client1, response);
                }
                _game.GetMove(response);
                if (_game.Winner() != null)
                {
                    await EndGame(client);
                    break;
                }
            }
        }
    }

    public async Task EndGame(TcpClient client)
    {
        _ = await SendMessageAndGetResponse(client, "win");
        foreach (var client1 in clients)
        {
            if (!client1.Equals(client))
                _ = await SendMessageAndGetResponse(client1, "end");
        }
        foreach (var client1 in clients)
        {
            client1.Close();
        }
    }
}
