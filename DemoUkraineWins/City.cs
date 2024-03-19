using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUkraineWins
{
    public class City
    {
        public string Name {  get; set; }
        public int Army { get; set; }
        public int Population { get; set; }
        public bool Side { get; set; }
        public Button Button { get; set; }
        public List<City> Connections = new List<City>();

        //commennnt
        
        public bool CanAttack()
        {
            foreach (City c in Connections)
                if (!c.Side)
                    return true;
            return false;
        }
        public bool CanMobilize()
        {
            return Population > 1;
        }
        public bool CanTransport()
        {
            foreach (City c in Connections)
                if (c.Side)
                    return true;
            return false;
        }

        public void Mobilize()
        {
            Army += Population / 2;
            Population -= Population / 2;
        }
        public void Attack(City city)
        {
            int force = Army / 2;
            city.Army -= force;
            this.Army -= force;
            if (city.Army <= 0)
            {
                city.Army = Math.Abs(city.Army);
                city.Side = Side;
            }
        }
        public void Transport(City city)
        {
            int army = Army / 2;
            this.Army -= army;
            city.Army += army;
        }

        public City(string name, int army, int population, bool side, int x, int y, Form1 form)
        {
            Name = name;
            Army = army;
            Population = population;
            Side = side;
            Button = new Button();
            Button.Location = new Point(x, y);
            Button.Size = new Size(51, 51);
            Button.BackColor = Color.White;
            Button.Click += (sender, e) => form.Select(this);
            Button.MouseEnter += (sender, e) => form.CaptureText(this);
            Button.MouseLeave += (sender, e) => form.ResetCaptureText();
        }

        public override string ToString()
        {
            return $"{Name.ToUpper()}\nARMY: {Army} | POPULATION: {Population}";
        }
    }
}
