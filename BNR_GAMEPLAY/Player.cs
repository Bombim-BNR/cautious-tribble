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
            City city = CurrentGame.Adapter.GetCurrentCity();
            Commands command = CurrentGame.Adapter.GetCommand();
            switch (command)
            {
                case Commands.MOBILIZE:
                    city.Mobilize();
                    break;
                case Commands.ATTACK:
                    City cityVictim = CurrentGame.Adapter.GetVictimCity();
                    city.Attack(cityVictim);
                    break;
                case Commands.TRANSPORT:
                    City cityReciever = CurrentGame.Adapter.GetRecieverCity();
                    city.Transport(cityReciever);
                    break;
            }
        }
    }
}
