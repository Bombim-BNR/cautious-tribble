using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFFrontEnd
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();

            SignUpButton.Click += SignTheUserAsync;
        }

        private async void SignTheUserAsync(object sender, RoutedEventArgs e)
        {
            PlayerRepository playerRepo = new PlayerRepository("Data Source=.\\;Initial Catalog=GameData;Integrated Security=True");
            if (await playerRepo.DoesUserExist(UsernameText.Text))
            {
                MessageBox.Show("Error. User is already exists.");
            }
            else
            {
                try
                {
                    Random random = new Random();
                    Player player = new Player(random.Next(1000000), "Counrty Null", 0, new Level(1));
                    await playerRepo.SavePlayer(player, UsernameText.Text, PasswordText.Text);
                    player = await playerRepo.LoadPlayer(UsernameText.Text, PasswordText.Text);
                    Connector.MyClient = new Client();
                    Connector.MyPlayer = player;
                    if (this.NavigationService != null)
                    {
                        this.NavigationService.Navigate(new MainMenu());
                    }
                    else
                    {
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.Content = new MainMenu();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Try again.");
                }
            }
        }
    }
}
