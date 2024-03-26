using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class SignUp : Stage
    {
        public void SignInNewUser()
        {

        }
        public void Build()
        {
            form.Textboxes.Add(new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height-250, 800, form));

            form.Textboxes.Add(new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height - 50, 800, form));
            
            List<CustomButton> Buttons = new List<CustomButton>()
            {
                new CustomButton(Images.SignUp, ScreenResolution.Width/2, ScreenResolution.Height/2+180) {OnClick = (sender, e) => SignInNewUser()}
            };
            form.Buttons.Clear();
            form.Buttons = Buttons;
        }
    }
}
