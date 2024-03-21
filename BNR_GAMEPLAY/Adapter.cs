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
        public abstract Commands GetCommand();
        public abstract City GetCurrentCity();
        public abstract City GetVictimCity();
        public abstract City GetRecieverCity();
        public abstract void UpdateMap();
    }
}
