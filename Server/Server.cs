using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Server
{
    private TcpListener tcpListener;
    private List<TcpClient> clients = new List<TcpClient>();
    private bool gameInProgress = false;
    private Game _game;

    public async Task StartServer(int port, Game game)
    {
        _game = game;

        tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        tcpListener.Start();

        AcceptClients();
        Console.WriteLine("Server started...");
    }

    private async void AcceptClients()
    {
        while (!gameInProgress)
        {
            TcpClient newClient = await tcpListener.AcceptTcpClientAsync();
            clients.Add(newClient);
            Console.WriteLine("New client connected.");
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
