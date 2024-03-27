using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            LoginButton.Click += LoginTheUserAsync;
        }
        
        private async void LoginTheUserAsync(object sender, RoutedEventArgs e)
        {
            PlayerRepository playerRepo = new PlayerRepository("Data Source=.\\;Initial Catalog=GameData;Integrated Security=True");
            if (await playerRepo.DoesUserExist(UsernameText.Text))
            {
                try
                {
                    Connector.MyClient = new Client();
                    Connector.MyPlayer = await playerRepo.LoadPlayer(UsernameText.Text, PasswordText.Text);
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
                    MessageBox.Show("Error. Wrong password.");
                }
            }
            else
            {
                MessageBox.Show("Error. Wrong login.");
            }
        }
    }
}
