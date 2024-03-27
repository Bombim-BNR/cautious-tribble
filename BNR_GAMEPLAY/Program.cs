using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;

namespace BNR
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var json = new ConfigManager("config.json");
/*            json.UpdateOrAdd("Data Source", @".\SQLEXPRESS");
            json.UpdateOrAdd("Initial Catalog", @"GameData");
            json.Save();*/
            PlayerRepository playerRepository = PlayerRepository.LoadFromJson(json);

            // Initialize levels for cities and players
            Level cityLevel1 = new Level(1000);
            Level cityLevel2 = new Level(1000);
            Level cityLevel3 = new Level(1000);
            Level playerLevel1 = new Level(1000);
            Level playerLevel2 = new Level(1000);

            // Create cities
            City city1 = new City(100, 1000, "Kyiv", cityLevel1, 0, new List<City>());
            City city2 = new City(150, 1500, "Kharkiv", cityLevel2, 0, new List<City>());
            City city3 = new City(200, 2000, "Donetsk", cityLevel3, 1, new List<City>());
            // Assuming cities can be connected for demonstration
            city1.Connect(city2);
            city2.Connect(city1);
            //await playerRepository.ClearDB();
            // Create players
            Player player1 = new Player(1, "Ukraine", 0, playerLevel1);
            Player player2 = new Player(2, "RF", 0, playerLevel2);
            await playerRepository.SavePlayer(player1, "anton", "123456");
            var testPlayer = await playerRepository.LoadPlayer("anton", "123456");

            // Temporarily create the game without setting the adapter
            Game game = new Game(new List<City> { city1, city2, city3 }, new List<Player> { player1, player2 }, null);

            // Now, create the console adapter and set it to the game
            ConsoleInterpretation adapter = new ConsoleInterpretation(game, player1);
            game.Adapter = adapter;

            
        }
    }
}
