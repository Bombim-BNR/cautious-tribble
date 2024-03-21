using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNR_SERVER
{
    public class Program
    {
        static public void Main(string[] args)
        {
            Server the_server = new Server();
            the_server.Start("127.0.0.1", "6069");
            Console.WriteLine("gogogo");
        }
    }
}
