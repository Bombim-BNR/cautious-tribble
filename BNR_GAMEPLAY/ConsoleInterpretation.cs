using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNR_GAMEPLAY
{
    public class ConsoleInterpretation : Adapter
    {
        private List<string> commands = new List<string>(){ "Attack", "Mobilize", "Transport" };
        public City? CurrentCity;
        public ConsoleInterpretation(Game game, Player player) : base(game, player)
        {
            
        }

        public int GetOption(List<string> options)
        {
            int index = 0;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" -> " + options[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(options[i]);
                    }
                }

                var k = Console.ReadKey();

                if (k.KeyChar == 'w' && index > 0)
                    index--;
                else if (k.KeyChar == 's' && index < options.Count - 1)
                    index++;
                else if (k.KeyChar == 'd')
                    return index;
            }
        }

        public override Commands GetCommand()
        {
            int choice = GetOption(commands);
            switch(choice)
            {
                case 0:
                    return Commands.ATTACK;
                case 1:
                    return Commands.MOBILIZE;
                case 2:
                    return Commands.TRANSPORT;
            }
            return Commands.MOBILIZE;
        }

        public override City GetCurrentCity()
        {
            CurrentCity = null;
            List<string> list = MyGame.Cities
            .Where(city => city.Owner.Equals(MyPlayer))
            .Select(city => city.ToString())
            .ToList();

            int choice = GetOption(list);
            CurrentCity = MyGame.Cities[choice];
            return MyGame.Cities[choice];
        }

        public override City GetVictimCity()
        {
            List<string> list = MyGame.Cities
            .Where(city => !city.Owner.Equals(MyPlayer))
            .Select(city => city.ToString())
            .ToList();

            int choice = GetOption(list);
            return MyGame.Cities[choice];
        }

        public override City GetRecieverCity()
        {
            List<string> list = MyGame.Cities
            .Where(city => (city.Owner.Equals(MyPlayer) && !city.Owner.Equals(CurrentCity)))
            .Select(city => city.ToString())
            .ToList();

            int choice = GetOption(list);
            return MyGame.Cities[choice];
        }

        public override void UpdateMap()
        {
            Console.Clear();

            int index = 1;
            foreach (City city in MyGame.Cities)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                if (city.Owner.Equals(MyPlayer))
                    Console.ForegroundColor = ConsoleColor.Green;
                
                Console.WriteLine($"{index}. {city.ToString()}");
                index++;
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\n{MyGame.CurrentPlayer.Name}'s Turn!");
            Console.ReadKey();
        }
    }
}
