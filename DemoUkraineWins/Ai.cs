using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUkraineWins
{
    static public class Ai
    {
        static public Form1 form1;

        public static Tuple<int, List<City>> GetMove()
        {
            var aiCities = form1.cities.Where(city => !city.Side).ToList();

            foreach (City aiCity in aiCities)
            {
                var targetCities = aiCity.Connections.Where(c => c.Side).ToList();
                targetCities.Sort((c1, c2) => c1.Army.CompareTo(c2.Army));

                foreach (var targetCity in targetCities)
                {
                    if (aiCity.Army >= targetCity.Army * 2)
                    {
                        return new Tuple<int, List<City>>(1, new List<City> { aiCity, targetCity });
                    }
                }
            }

            foreach (City city in aiCities)
            {
                var enemyConnections = city.Connections.Any(c => c.Side);
                if (enemyConnections && city.CanMobilize())
                {
                    return new Tuple<int, List<City>>(0, new List<City> { city });
                }
            }

            return new Tuple<int, List<City>>(-1, new List<City>());
        }
    }
}
