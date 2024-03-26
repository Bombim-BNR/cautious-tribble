using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualInterpretation
{
    public class Menu : Stage
    {
        public void Play()
        {
            form.StageLoad(Stages.LOBBY);
        }
        public void Options()
        {
            
        }
        public void Exit()
        {
            form.Close();
        }
        public void Build()
        {
            CustomButton PlayButton = new CustomButton(Images.Play, ScreenResolution.Width / 2, ScreenResolution.Height / 2 - 200)
            {
                OnClick = (sender, e) => Play()
            };

            CustomButton OptionsButton = new CustomButton(Images.Settings, ScreenResolution.Width / 2, ScreenResolution.Height / 2)
            {
                OnClick = (sender, e) => Options()
            };

            CustomButton ExitButton = new CustomButton(Images.Exit, ScreenResolution.Width / 2, ScreenResolution.Height / 2 + 200)
            {
                OnClick = (sender, e) => Exit()
            };

            form.Background = Images.Background;
            form.Buttons.Clear();
            form.Textboxes.Clear();
            form.Controls.Clear();
            form.Buttons.Add(PlayButton);
            form.Buttons.Add(OptionsButton);
            form.Buttons.Add(ExitButton);
        }
    }
}
