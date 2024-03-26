using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    internal class Lobby : Stage
    {
        public async void StartTheGame()
        {

        }
        public void Build()
        {
            ColoredRectangle BoxPlayers = new ColoredRectangle()
            {
                X = 800, Y = 0,
                Width = ScreenResolution.Width - 800, Height = ScreenResolution.Height,
                SolidBrush = new SolidBrush(Color.FromArgb(255, 168, 86, 75))
            };

            CustomButton Start = new CustomButton(Images.Start, ScreenResolution.Width / 2 - 300, ScreenResolution.Height / 2 + 140)
            {
                OnClick = (sender, e) => StartTheGame()
            };

            CustomButton SelectAnother = new CustomButton(Images.SelectAnother, ScreenResolution.Width / 2 - 300, ScreenResolution.Height / 2 + 260)
            {
                OnClick = (sender, e) => StartTheGame()
            };

            CustomImage Map = new CustomImage(Images.MapIsrael, 0, 0) { Resize = 1.5f, X=0, Y=0};

            form.Buttons.Clear();
            form.Buttons.Add(Start);
            form.Buttons.Add(SelectAnother);
            form.Rectangles.Add(BoxPlayers);
            form.Images.Add(Map);
        }
    }
}
