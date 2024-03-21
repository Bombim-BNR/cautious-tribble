using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;

namespace BNR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize levels for cities and players
            Level cityLevel1 = new Level(1, 0);
            Level cityLevel2 = new Level(1, 0);
            Level cityLevel3 = new Level(1, 0);
            Level playerLevel1 = new Level(1, 0);
            Level playerLevel2 = new Level(1, 0);

            // Create cities
            City city1 = new City(100, 1000, "Kyiv", cityLevel1, 0, new List<City>());
            City city2 = new City(150, 1500, "Kharkiv", cityLevel2, 0, new List<City>());
            City city3 = new City(200, 2000, "Donetsk", cityLevel3, 1, new List<City>());
            // Assuming cities can be connected for demonstration
            city1.Connect(city2);
            city2.Connect(city1);

            // Create players
            Player player1 = new Player(1, "Ukraine", 0, playerLevel1);
            Player player2 = new Player(2, "RF", 0, playerLevel2);

            // Temporarily create the game without setting the adapter
            Game game = new Game(new List<City> { city1, city2, city3 }, new List<Player> { player1, player2 }, null);

            // Now, create the console adapter and set it to the game
            ConsoleInterpretation adapter = new ConsoleInterpretation(game, player1);
            game.Adapter = adapter;

            // Run the game
            Player winner = game.MainLoop();
            if (winner != null)
            {
                Console.WriteLine($"{winner.Name} wins the game!");
            }
            else
            {
                Console.WriteLine("No winner.");
            }
        }
    }
}
