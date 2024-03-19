namespace DemoUkraineWins
{
    public partial class Form1 : Form
    {
        public List<City> cities = new List<City>();
        public City CurrentCity;
        public int Mode = 0;
        public ToolTip toolTip1;
        public Form1()
        {
            toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 1;
            toolTip1.UseFading = false;
            toolTip1.ShowAlways = true;
            toolTip1.ForeColor = Color.Black;

            cities.Add(new City("Kyiv", 800, 5000, true, 454, 309, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Kropivnitsky", 600, 2500, true, 524, 439, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Kharkiv", 1000, 2000, true, 684, 359, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Mykolaiv", 1200, 1000, true, 490, 559, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Crimea", 2500, 3500, false, 580, 659, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Donetsk", 1900, 2000, false, 720, 480, this));
            Controls.Add(cities.Last().Button);

            cities.Add(new City("Luhansk", 1700, 1500, false, 780, 420, this));
            Controls.Add(cities.Last().Button);

            cities[0].Connections.Add(cities[1]);
            cities[0].Connections.Add(cities[2]);

            cities[1].Connections.Add(cities[0]);
            cities[1].Connections.Add(cities[2]);
            cities[1].Connections.Add(cities[3]);
            cities[1].Connections.Add(cities[5]);

            cities[2].Connections.Add(cities[0]);
            cities[2].Connections.Add(cities[1]);
            cities[2].Connections.Add(cities[6]);
            cities[2].Connections.Add(cities[5]);

            cities[3].Connections.Add(cities[1]);
            cities[3].Connections.Add(cities[4]);
            cities[3].Connections.Add(cities[5]);

            cities[4].Connections.Add(cities[3]);
            cities[4].Connections.Add(cities[5]);

            cities[5].Connections.Add(cities[1]);
            cities[5].Connections.Add(cities[2]);
            cities[5].Connections.Add(cities[3]);
            cities[5].Connections.Add(cities[4]);
            cities[5].Connections.Add(cities[6]);

            cities[6].Connections.Add(cities[2]);
            cities[6].Connections.Add(cities[5]);

            toolTip1.SetToolTip(cities[0].Button, "»ƒ» Õ¿’");
            toolTip1.SetToolTip(cities[1].Button, "»ƒ» Õ¿’ 2");

            Ai.form1 = this;
            InitializeComponent();
            DrawCitiesSidesColor();
            UpdateToolTip();
        }

        public void UpdateToolTip()
        {
            toolTip1.RemoveAll();
            for (int i = 0; i < cities.Count; i++)
            {
                toolTip1.SetToolTip(cities[i].Button, cities[i].ToString());
            }
        }

        public void Select(City city)
        {
            if (Mode == 0)
            {
                CurrentCity = city;
                DrawSelectColor();
                UpdateInfo();
                UpdateWorkspaceButtons();
                btnDeselect.Visible = true;
            }
            else if (Mode == 1)
            {
                CurrentCity.Attack(city);
                AiTurn();
                CommandsMode();
            }
            else if (Mode == 2)
            {
                CurrentCity.Transport(city);
                AiTurn();
                CommandsMode();
            }
        }

        public void UpdateInfo()
        {
            if (CurrentCity != null)
            {
                lbInfo.Text =
                $"""
                {CurrentCity.Name}
                Free:       {CurrentCity.Side}
                Army:       {CurrentCity.Army}
                Population: {CurrentCity.Population}
                """;
            }
            else
            {
                lbInfo.Text = "City info is here";
            }
        }

        public void UpdateWorkspaceButtons()
        {
            btnAttack.Enabled = false;
            btnMobilize.Enabled = false;
            btnTransport.Enabled = false;
            if (CurrentCity != null && CurrentCity.Side)
            {
                if (CurrentCity.CanAttack()) btnAttack.Enabled = true;
                if (CurrentCity.CanMobilize()) btnMobilize.Enabled = true;
                if (CurrentCity.CanTransport()) btnTransport.Enabled = true;
            }
        }

        public void CaptureText(City city)
        {
            lbCaptured.Text = city.Name;
        }

        public void ResetCaptureText()
        {
            lbCaptured.Text = "";
        }

        public void SetOnlyAvaiblesToAttack()
        {
            foreach (City c in cities)
            {
                c.Button.Enabled = false;
                c.Button.BackColor = Color.White;
                if (CurrentCity.Connections.Contains(c) && !c.Side)
                {
                    c.Button.Enabled = true;
                    c.Button.BackColor = Color.Green;
                }
            }
        }

        public void SetOnlyAvaiblesToTransport()
        {
            foreach (City c in cities)
            {
                c.Button.Enabled = false;
                c.Button.BackColor = Color.White;
                if (CurrentCity.Connections.Contains(c) && c.Side)
                {
                    c.Button.Enabled = true;
                    c.Button.BackColor = Color.Green;
                }
            }
        }

        public void AllAvaible()
        {
            foreach (City c in cities)
            {
                c.Button.Enabled = true;
            }
        }

        public void CommandsMode()
        {
            btnAttack.Visible = true;
            btnMobilize.Visible = true;
            btnTransport.Visible = true;
            btnCancel.Visible = false;
            lbToDo.Visible = false;
            Mode = 0;
            AllAvaible();
            Select(CurrentCity);
        }

        public void AttackMode()
        {
            btnAttack.Visible = false;
            btnMobilize.Visible = false;
            btnTransport.Visible = false;
            btnCancel.Visible = true;
            lbToDo.Visible = true;
            Mode = 1;
            lbToDo.Text = "Select city to attack\nfrom the map";
            SetOnlyAvaiblesToAttack();
            btnDeselect.Visible = false;
        }

        public void TransportMode()
        {
            btnAttack.Visible = false;
            btnMobilize.Visible = false;
            btnTransport.Visible = false;
            btnCancel.Visible = true;
            lbToDo.Visible = true;
            Mode = 2;
            lbToDo.Text = "Select reciever city\nfrom the map";
            SetOnlyAvaiblesToTransport();
            btnDeselect.Visible = false;
        }

        private void btnMobilize_Click(object sender, EventArgs e)
        {
            CurrentCity.Mobilize();
            AiTurn();
            UpdateInfo();
            UpdateWorkspaceButtons();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            AttackMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CommandsMode();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            TransportMode();
        }

        public void DrawSelectColor()
        {
            foreach (City c in cities)
            {
                c.Button.BackColor = Color.White;
                if (!c.Side)
                    c.Button.BackColor = Color.Pink;
                if (CurrentCity.Connections.Contains(c))
                {
                    c.Button.BackColor = Color.Red;
                    if (c.Side)
                        c.Button.BackColor = Color.Green;
                }
            }

            CurrentCity.Button.BackColor = Color.Yellow;
        }

        public void DrawCitiesSidesColor()
        {
            foreach (City c in cities)
            {
                c.Button.BackColor = Color.White;
                if (!c.Side)
                    c.Button.BackColor = Color.Red;
            }
        }

        public void AiTurn()
        {
            Tuple<int, List<City>> move = Ai.GetMove();

            if (move.Item1 == 0)
            {
                move.Item2[0].Mobilize();
                lbNews.Text = $"Russia has mobilized\npeople in {move.Item2[0].Name}";
            }
            else if (move.Item1 == 1)
            {
                move.Item2[0].Attack(move.Item2[1]);
                lbNews.Text = $"Russia has attacked\nfrom {move.Item2[0].Name} to {move.Item2[1].Name}.";
            }
            else if (move.Item1 == 2)
            {
                move.Item2[0].Transport(move.Item2[1]);
                lbNews.Text = $"Russia has transported\nfrom {move.Item2[0].Name} to {move.Item2[1].Name}.";
            }

            DrawSelectColor();
            UpdateToolTip();
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            btnDeselect.Visible = false;
            CurrentCity = null;
            UpdateInfo();
            UpdateWorkspaceButtons();
            DrawCitiesSidesColor();
        }
    }
}
