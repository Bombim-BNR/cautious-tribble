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

        public string Turn()
        {
            string move = "";
            City city = CurrentGame.Adapter.GetCurrentCity();
            move += city.Name + "|";
            Commands command = CurrentGame.Adapter.GetCommand();
            switch (command)
            {
                case Commands.MOBILIZE:
                    move += "0";
                    break;
                case Commands.ATTACK:
                    City cityVictim = CurrentGame.Adapter.GetVictimCity();
                    move += "1|";
                    move += cityVictim.ToString();
                    break;
                case Commands.TRANSPORT:
                    City cityReciever = CurrentGame.Adapter.GetRecieverCity();
                    move += "2|";
                    move += cityReciever.ToString();
                    break;
            }
            return move;
        }
    }
}
