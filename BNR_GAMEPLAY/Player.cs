using System;
using System.Linq;
using System.Reflection.Emit;

namespace BNR_GAMEPLAY
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Level CurrentLevel { get; set; }

        private Game CurrentGame;
        public List<City> AvaibleCities
        {
            get
            {
                return (List<City>)(CurrentGame.Cities.Where(city => city.Owner.Equals(this)));
            }
        }

        public Player(int id, string name, int score, Level level)
        {
            Id = id;
            Name = name;
            Score = score;
            CurrentLevel = level;
        }

        public void SetGame(Game game)
        {
            CurrentGame = game;
        }

        public void Turn()
        {
            Commands command = CurrentGame.Adapter.GetCommand();
            City city = CurrentGame.Adapter.GetCurrentCity();
            City city2 = CurrentGame.Adapter.GetSecondaryCity();
            switch (command)
            {
                case Commands.ATTACK:
                    city.Attack(city2);
                    break;
                case Commands.MOBILIZE:
                    city.Mobilize();
                    break;
                case Commands.TRANSPORT:
                    city.Transport(city2);
                    break;
            }
        }
    }
}
