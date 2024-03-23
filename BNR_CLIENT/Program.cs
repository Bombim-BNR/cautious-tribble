﻿using BNR_GAMEPLAY;
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
            Level cityLevel1 = new Level(1, 0);
            Level cityLevel2 = new Level(1, 0);
            Level cityLevel3 = new Level(1, 0);
            Level playerLevel1 = new Level(1, 0);
            Level playerLevel2 = new Level(1, 0);
            
            City city1 = new City(100, 1000, "Kyiv", cityLevel1, 0, new List<City>());
            City city2 = new City(150, 1500, "Kharkiv", cityLevel2, 0, new List<City>());
            City city3 = new City(200, 2000, "Donetsk", cityLevel3, 1, new List<City>());

            Player player1 = new Player(1, "Ukraine", 0, playerLevel1);
            Player player2 = new Player(2, "UNR", 0, playerLevel2);

            city1.Connect(city2);
            city2.Connect(city1);

            Game game = new Game(new List<City> { city1, city2, city3 }, new List<Player> { player1, player2 }, null);

            Client client = new Client();
            Console.Write("Which one you want to be? (1, 2) => ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                ConsoleInterpretation ci = new ConsoleInterpretation(game, player1);
                ci.MyGame = game;
                await client.ConnectToServer(ci.MyPlayer.Name, 1234, game);
            }
            else if (choice == "2")
            {
                ConsoleInterpretation ci = new ConsoleInterpretation(game, player2);
                ci.MyGame = game;
                await client.ConnectToServer(ci.MyPlayer.Name, 1234, game);
            }
            else
            {
                Console.WriteLine("no stupid idiot go fck yourself :(");
            }
        }
    }
}
