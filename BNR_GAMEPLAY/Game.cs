using System;


namespace BNR_GAMEPLAY
{
    public class Game
    {
        // CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();  // Реализация на потом (to do)
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
                int count = ((List<City>)(Cities.Where(city => city.Owner == player))).Count;
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

        public Player? MainLoop()
        {
            bool isRunning = true;
            while (isRunning)
            { 
                CurrentPlayer.Turn();
                if (Winner() != null)
                    isRunning = false;

                NextTurn();
            }
            return Winner();
        }
    }
}
