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

        private Game? CurrentGame;
        public List<City>? AvaibleCities => CurrentGame?.Cities.Where(city => city.Owner.Equals(this)) as List<City>;

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

        public async Task<string> Turn()
        {
            string move = "";
            if(CurrentGame is null) 
            {
                throw new InvalidDataException("Current Game is Empty");
            }
            City city = await CurrentGame.Adapter.GetCurrentCity();
            move += city.Name + "|";
            Commands command = await CurrentGame.Adapter.GetCommand();
            switch (command)
            {
                case Commands.MOBILIZE:
                    move += "mob";
                    break;
                case Commands.ATTACK:
                    City cityVictim = await CurrentGame.Adapter.GetVictimCity();
                    move += "att|";
                    move += cityVictim.Name;
                    break;
                case Commands.TRANSPORT:
                    City cityReciever = await CurrentGame.Adapter.GetRecieverCity();
                    move += "tra|";
                    move += cityReciever.Name;
                    break;
            }
            return move;
        }
    }
}
