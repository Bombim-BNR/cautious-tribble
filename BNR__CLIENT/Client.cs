using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BNR_GAMEPLAY;

public class Client
{
    private TcpClient tcpClient;
    private NetworkStream stream;
    private Game _game;

    public async Task ConnectToServer(string hostname, int port, Game game)
    {
        tcpClient = new TcpClient();
        await tcpClient.ConnectAsync("127.0.0.1", port);
        stream = tcpClient.GetStream();

        _game = game;
        
        await StartReceiving();
    }

    private async Task StartReceiving()
    {
        try
        {
            while (true)
            {
                string receivedMessage = await ReceiveMessage();
                string response = await ProcessMessageAsync(receivedMessage);
                await SendMessage(response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private async Task SendMessage(string message)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(message);
        await stream.WriteAsync(buffer, 0, buffer.Length);
    }

    private async Task<string> ReceiveMessage()
    {
        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        return Encoding.ASCII.GetString(buffer, 0, bytesRead);
    }

    private async Task<string> ProcessMessageAsync(string message)
    {
        if (message == "turn")
        {
            string move = await _game.TurnAsync();
            return move;
        }
        else if (message == "next")
        {
            await _game.NextTurn();
            return "+";
        }
        else if (message == "check")
        {
            await _game.Adapter.UpdateMapNYT();
            return "+";
        }
        else if (message == "win")
        {
            await _game.Adapter.YouWin();
            return "+";
        }
        else if (message == "end")
        {
            await _game.Adapter.TheEnd();
            return "+";
        }
        else
        {
            await _game.GetMove(message+"|"+_game.Players.IndexOf(_game.Adapter.MyPlayer));
            return "+";
        }
    }
}
