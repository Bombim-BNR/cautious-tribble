using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();

            ExitButton.Click += ExitThisBadGame;
            SettingsButton.Click += NeverGonna;
            PlayButton.Click += ClickedPlay;
        }

        private async void ClickedPlay(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new Lobby());
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Content = new Lobby();
            }
        }

        private void NeverGonna(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NEVER");
            MessageBox.Show("GONNA");
            MessageBox.Show("GIVE");
            MessageBox.Show("YOU");
            MessageBox.Show("UP");
            MessageBox.Show("NEVER");
            MessageBox.Show("GONNA");
            MessageBox.Show("LET");
            MessageBox.Show("YOU");
            MessageBox.Show("DOWN");
        }

        private void ExitThisBadGame(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
