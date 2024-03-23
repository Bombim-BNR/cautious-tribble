using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNR_GAMEPLAY;

namespace BNR_SERVER
{
    public class Program
    {
        static public async Task Main(string[] args)
        {
            Server the_server = new Server();
            the_server.StartServer(6969, Maps.Default());
            Console.ReadKey();
            await the_server.GameLoopAsync();
        }
    }
}
