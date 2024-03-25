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
            set
            {
                for(int i = 0; i < Players.Count; i++)
                {
                    if (Players[i] == value)
                    {
                        CurrentPlayerIndex = i;
                        break;
                    }
                }
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

        public async Task NextTurn()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }

        public City? SelectCityWithName(string name)
        {
            if (Cities is null)
            {
                throw new InvalidDataException("Cities is empty");
            }
            return Cities.FirstOrDefault(city => city.Name == name);
        }

        public async Task GetMove(string move)
        {
            string[] tokens = move.Split("|");
            if (SelectCityWithName(tokens[0]) is null)
            {
                throw new InvalidDataException($"There is no city named {tokens[0]}");
            }
            if (SelectCityWithName(tokens[2]) is null)
            {
                throw new InvalidDataException($"There is no city named {tokens[2]}");
            }
#pragma warning disable CS8602, CS8604 // nessesary checks were made higher

            if (tokens[1] == "mob")
            {
                SelectCityWithName(tokens[0]).Mobilize();
            }
            else if (tokens[1] == "att")
            {
                SelectCityWithName(tokens[0]).Attack(SelectCityWithName(tokens[2]));
            }
            else if (tokens[1] == "tra")
            {
                SelectCityWithName(tokens[0]).Transport(SelectCityWithName(tokens[2]));
            }
#pragma warning disable CS8602, CS8604

            await Adapter.UpdateMapNYT();
        }

        public async Task<string> TurnAsync()
        {
            await Adapter.UpdateMap();
            string move = "";

            if (Adapter.MyPlayer.Equals(CurrentPlayer))
            {
                move = await CurrentPlayer.Turn();
            }

            return move;
        }

        /*
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
        */
    }
}
