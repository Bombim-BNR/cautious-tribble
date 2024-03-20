using System;

namespace BNR_GAMEPLAY
{
    public class Level
    {
        public int Value { get; set; }
        private int exp;

        public Level(int value, int exp)
        {
            Value = value;
            this.exp = exp;
        }

        public void Up(int exp)
        {
            this.exp += exp;
            while (exp > Value * 1000)
            {
                exp -= Value * 1000;
                Value += 1;
            }
        }
    }
}
