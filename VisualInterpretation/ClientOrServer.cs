using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class ClientOrServer : Stage
    {
        public void IsClient()
        {
            form.RunClient();
            form.StageLoad(Stages.SIGN_OR_LOG);
        }
        public void IsServer()
        {
            form.StageLoad(Stages.SIGN_OR_LOG);
        }
        public void Build()
        {
            CustomButton Client = new CustomButton(Images.Client, ScreenResolution.Width / 2, ScreenResolution.Height / 2 + 100)
            {
                OnClick = (sender, e) => IsClient()
            };


            CustomButton Server = new CustomButton(Images.Server, ScreenResolution.Width / 2, ScreenResolution.Height / 2 - 100)
            {
                OnClick = (sender, e) => IsServer()
            };

            form.Background = Images.Background;
            form.Buttons.Clear();
            form.Buttons.Add(Client);
            form.Buttons.Add(Server);
        }
    }
}
