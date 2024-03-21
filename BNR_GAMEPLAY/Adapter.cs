using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNR_GAMEPLAY
{
    public abstract class Adapter
    {
        public Game MyGame { get; set; }
        public Player MyPlayer { get; set; }
        public Adapter(Game game, Player player)
        {
            MyGame = game;
            MyPlayer = player;
        }
        public abstract Task<Commands> GetCommand();
        public abstract Task<City> GetCurrentCity();
        public abstract Task<City> GetVictimCity();
        public abstract Task<City> GetRecieverCity();
        public abstract Task UpdateMap();
        public abstract Task UpdateMapNYT();
        public abstract Task YouWin();
        public abstract Task TheEnd();
    }
}
