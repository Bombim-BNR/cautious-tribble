using BNR_GAMEPLAY;
using Newtonsoft.Json;
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
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Page
    {
        public Lobby()
        {
            InitializeComponent();

            Setup();
        }

        public async void Setup()
        {
            try
            {
                Connector.MyClient = new Client();
                await Connector.MyClient.ConnectToServer(Connector.MyPlayer.Name, Connector.Port, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
