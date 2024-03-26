using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class SignUp : Stage
    {
        CustomTextbox name;
        CustomTextbox password;
        public async void SignInNewUser()
        {
            try
            {
                Random random = new Random();

                PlayerRepository playerRepository = new PlayerRepository(@"Data Source=DESKTOPART;Initial Catalog=GameData;Integrated Security=True");

                Player player = new Player(random.Next(100000000), "", 0, new Level(1));

                if (await playerRepository.DoesUserExist(name.TextBox.Text))
                {
                    throw new Exception("User exists. Change login.");
                }
                else
                {
                    await playerRepository.SavePlayer(player, name.TextBox.Text, password.TextBox.Text);
                    form.player = await playerRepository.LoadPlayer(name.TextBox.Text, password.TextBox.Text);
                    form.StageLoad(Stages.MAIN_MENU);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured. Try again.");
            }
        }
        public void Build()
        {
            name = new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height-250, 800, form);

            password = new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height - 50, 800, form);
            password.TextBox.PasswordChar = '*';

            CustomButton SignUp = new CustomButton(Images.SignUp, ScreenResolution.Width/2, ScreenResolution.Height/2+180)
            {
                OnClick = (sender, e) => SignInNewUser()
            };

            form.Buttons.Clear();
            form.Buttons.Add(SignUp);
            form.Textboxes.Add(name);
            form.Textboxes.Add(password);
        }
    }
}
