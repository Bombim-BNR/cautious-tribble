using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class LogIn : Stage
    {
        public void LogInCreatedUser()
        {

        }
        public void Build()
        {
            TextBox name = new TextBox();
            name.Location = new Point(ScreenResolution.Width / 2 - 400, ScreenResolution.Height / 2 - 250);
            name.Size = new Size(800, 200);
            name.Font = new Font(FontFamily.GenericSansSerif, 45);
            name.PlaceholderText = "your name here";

            TextBox password = new TextBox();
            password.Location = new Point(ScreenResolution.Width / 2 - 400, ScreenResolution.Height / 2 - 50);
            password.Size = new Size(800, 200);
            password.Font = new Font(FontFamily.GenericSansSerif, 45);
            password.PlaceholderText = "your password here";
            password.PasswordChar = '*';

            form.Controls.Add(name);
            form.Controls.Add(password);
            List<CustomButton> Buttons = new List<CustomButton>()
            {
                new CustomButton(Images.Login, ScreenResolution.Width/2, ScreenResolution.Height/2+180) {OnClick = (sender, e) => LogInCreatedUser()}
            };
            form.Buttons.Clear();
            form.Buttons = Buttons;
        }
    }
}
