using System;

namespace BNR_GAMEPLAY
{
    public class Game
    {
        public List<City> Cities {  get; set; }
        public List<Player> Players {  get; set; }
        public int CurrentPlayerIndex;
        public Player CurrentPlayer
        {
            get
            {
                return Players[CurrentPlayerIndex];
            }
        }

        public Game(List<City> cities, List<Player> players)
        {
            Cities = cities;
            Players = players;

            foreach (Player player in Players)
                player.SetGame(this);

            foreach (City city in Cities)
                city.AcceptThePlayer(players);

            CurrentPlayerIndex = 0;
        }
    }
}
