using BNR_GAMEPLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class LogIn : Stage
    {
        CustomTextbox name;
        CustomTextbox password;
        public async void LogInCreatedUserAsync()
        {
            try
            {
                PlayerRepository playerRepository = new PlayerRepository(@"Data Source=DESKTOPART;Initial Catalog=GameData;Integrated Security=True");

                Player player = new Player(0, "", 0, new Level(1));

                if (await playerRepository.DoesUserExist(name.TextBox.Text))
                {
                    try
                    {
                        form.player = await playerRepository.LoadPlayer(name.TextBox.Text, password.TextBox.Text);
                        form.StageLoad(Stages.MAIN_MENU);
                    }
                    catch
                    {
                        throw new Exception("Incorrecta da passworde.");
                    }
                }
                else
                {
                    throw new Exception("User does not exists. Change login.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Build()
        {
            name = new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height - 250, 800, form);

            password = new CustomTextbox(ScreenResolution.Width / 2, ScreenResolution.Height - 50, 800, form);
            password.TextBox.PasswordChar = '*';

            CustomButton SignUp = new CustomButton(Images.Login, ScreenResolution.Width / 2, ScreenResolution.Height / 2 + 180)
            {
                OnClick = (sender, e) => LogInCreatedUserAsync()
            };

            form.Buttons.Clear();
            form.Buttons.Add(SignUp);
            form.Textboxes.Add(name);
            form.Textboxes.Add(password);
        }
    }
}
