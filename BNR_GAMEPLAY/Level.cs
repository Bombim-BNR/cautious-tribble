using System;

namespace BNR_GAMEPLAY
{
    public class Level
    {
        
        public int Value
        {
            get
            {

                return ((int)Math.Floor(0.001 * exp)) + 1;
            }
            set
            {
                exp = 1000 * (value - 1);
            }
        }
        public int exp;
        [Obsolete("Only exp value is used. Use either copy or exp constructor ")]
        public Level(int value, int exp)
        {
            //Value = value;
            this.exp = exp;
        }
        public Level(int exp)
        {
            this.exp = exp;
        }
        public Level(Level other)
        {
            exp = other.exp;
        }
        [Obsolete("This function is deprecated. Use += to exp ")]

        public void Up(int exp)
        {
            this.exp += exp;
        }
    }
}
