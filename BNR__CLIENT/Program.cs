using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BNR_CLIENT
{
    public class Program
    {
        static public async Task Main(string[] args)
        {
            Game game = Maps.Default();

            Client client = new Client();
            
            /*
            Console.Write("Which one you want to be? (1, 2) => ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                ConsoleInterpretation ci = new ConsoleInterpretation(game, game.Players[0]);
                ci.MyGame = game;
                game.Adapter = ci;
                await client.ConnectToServer(ci.MyPlayer.Name, 6969, game);
            }
            else if (choice == "2")
            {
                ConsoleInterpretation ci = new ConsoleInterpretation(game, game.Players[1]);
                ci.MyGame = game;
                game.Adapter = ci;
                await client.ConnectToServer(ci.MyPlayer.Name, 6969, game);
            }
            else
            {
                Console.WriteLine("no stupid idiot go fck yourself :(");
            }
            */
        }
    }
}
