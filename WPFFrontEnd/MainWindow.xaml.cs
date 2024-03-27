using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ClientButton.Click += ClickedClient;
            ServerButton.Click += ClickedServer;
        }

        private async void ClickedServer(object sender, RoutedEventArgs e)
        {
            Connector.MyServer = new Server();
            await Connector.MyServer.StartServer(Connector.Port, null);
            this.Content = new LogOrSign();
        }

        private void ClickedClient(object sender, RoutedEventArgs e)
        {
            this.Content = new LogOrSign();
        }
    }
}