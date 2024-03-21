using System;

namespace BNR_GAMEPLAY
{
    public class City
    {
        private const int EXP_PER_OCCUPATION = 500;
        private const int EXP_PER_ATTACK = 250;
        private const int MOBILIZATION_COUNT = 3;
        private const int MINIMUM_POPULATION_REMAIN = 20;

        public int Army {  get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        private int playerIndexToGive;
        public Level CurrentLevel { get; set; }
        public Player Owner { get; set; }
        private int mobilizationCount = MOBILIZATION_COUNT;
        private List<City> connectedCities;

        public City(int army, int population, string name, Level level, int playerindextogive,List<City> connectedCities) 
        { 
            Army = army;
            Population = population;
            Name = name;
            CurrentLevel = level;
            playerIndexToGive = playerindextogive;
            this.connectedCities = connectedCities;
        }

        public void AcceptThePlayer(List<Player> players)
        {
            Owner = players[playerIndexToGive];
        }

        public void RandomPopulationGrowth()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                Population += random.Next(0, 10 * CurrentLevel.Value);
            }
        }

        public void Mobilize()
        {
            int amount = Population - ((MINIMUM_POPULATION_REMAIN + Population) / 2);
            Army += amount;
            Population -= amount;
        }

        public void Attack(City victim)
        {
            int force = Army / 2;
            Army -= force;
            victim.Army -= force;

            force *= CurrentLevel.Value / victim.CurrentLevel.Value;

            if (victim.Army <= 0)
            {
                victim.Owner = Owner;
                victim.Army = Math.Abs(Army);
                CurrentLevel.Up(CurrentLevel.Value * EXP_PER_OCCUPATION);
            }
            else
            {
                CurrentLevel.Up(CurrentLevel.Value * EXP_PER_ATTACK);
            }
        }

        public void Transport(City reciever)
        {
            int force = Army / 2;
            Army -= force;
            reciever.Army += force;
        }

        public void Connect(City city)
        {
            connectedCities.Add(city);
        }

        public bool CanMobilize()
        {
            return mobilizationCount > 0;
        }

        public bool CanAttack(City victim)
        {
            return connectedCities.Contains(victim);
        }

        public bool CanTransport(City reciever)
        {
            return connectedCities.Contains(reciever);
        }

        public override string ToString()
        {
            return $"{Owner.Name} - {Name} => ARM: {Army} | POP: {Population} | LVL: {CurrentLevel.Value}";
        }
    }
}
