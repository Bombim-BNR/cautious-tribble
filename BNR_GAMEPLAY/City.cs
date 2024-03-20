﻿using System;

namespace BNR_GAMEPLAY
{
    public class City
    {
        private const int EXP_PER_OCCUPATION = 500;
        private const int EXP_PER_ATTACK = 250;

        public int Army {  get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        private int playerIndexToGive;
        public Level CurrentLevel { get; set; }
        public Player Owner { get; set; }

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

        public void Mobilize()
        {
            Army += Population / 2;
            Population -= Population / 2;
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
            return Population > 1;
        }

        public bool CanAttack(City victim)
        {
            return connectedCities.Contains(victim);
        }

        public bool CanTransport(City reciever)
        {
            return connectedCities.Contains(reciever);
        }


    }
}
