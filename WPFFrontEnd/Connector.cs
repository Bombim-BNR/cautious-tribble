using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFrontEnd
{
    public static class Connector
    {
        public static Client? MyClient;
        public static Server? MyServer;
        public static Player? MyPlayer;
        public static int Port = 4444;
    }
}
