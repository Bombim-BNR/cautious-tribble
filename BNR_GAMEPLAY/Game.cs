using System;
using System.Net.Security;


namespace BNR_GAMEPLAY
{
    public class Game
    {
        public List<City> Cities {  get; set; }
        public List<Player> Players {  get; set; }
        public int CurrentPlayerIndex;
        public Adapter Adapter;
        public Player CurrentPlayer
        {
            get
            {
                return Players[CurrentPlayerIndex];
            }
        }

        public Player? Winner()
        {
            foreach (Player player in Players)
            {
                int count = Cities.Where(city => city.Owner == player).ToList().Count;
                if (count == Cities.Count)
                {
                    return player;
                }
            }
            return null;
        }


        public Game(List<City> cities, List<Player> players, Adapter Adapter)
        {
            Cities = cities;
            Players = players;
            this.Adapter = Adapter;

            foreach (Player player in Players)
                player.SetGame(this);

            foreach (City city in Cities)
                city.AcceptThePlayer(players);

            CurrentPlayerIndex = 0;
        }

        public void NextTurn()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;

        }

        public City SelectCityWithName(string name)
        {
            return Cities.FirstOrDefault(city => city.Name == name);
        }

        public void GetMove(string move)
        {
            string[] tokens = move.Split("|");
            if (tokens[1] == "0")
            {
                SelectCityWithName(tokens[0]).Mobilize();
            }
            else if (tokens[1] == "1")
            {
                SelectCityWithName(tokens[0]).Attack(SelectCityWithName(tokens[2]));
            }
            else if (tokens[1] == "2")
            {
                SelectCityWithName(tokens[0]).Transport(SelectCityWithName(tokens[2]));
            }
        }

        public void SendMove(string move)
        {

        }

        public Player? MainLoop()
        {
            bool isRunning = true;
            while (isRunning)
            {
                foreach (City city in Cities)
                    city.RandomPopulationGrowth();

                Adapter.UpdateMap();

                string move = CurrentPlayer.Turn();

                if (Winner() != null)
                    isRunning = false;

                NextTurn();
            }
            return Winner();
        }
    }
}
