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
    /// Interaction logic for LogOrSign.xaml
    /// </summary>
    public partial class LogOrSign : Page
    {
        public LogOrSign()
        {
            InitializeComponent();

            LoginButton.Click += ClickedLogin;
            SignUpButton.Click += ClickedSignUp;
        }

        private void ClickedSignUp(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new SignUp());
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Content = new SignUp();
            }
        }

        private void ClickedLogin(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new Login());
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Content = new Login();
            }
        }
    }
}
