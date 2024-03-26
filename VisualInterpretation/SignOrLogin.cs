﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class SignOrLogin : Stage
    {
        public void OpenSignUp()
        {
            form.StageLoad(Stages.SIGN_UP);
        }
        public void OpenLogIn()
        {
            form.StageLoad(Stages.LOG_IN);
        }
        public void Build()
        {
            List<CustomButton> ObjectsToAdd = new List<CustomButton>()
            {
                new CustomButton(Images.SignUp, ScreenResolution.Width/2, ScreenResolution.Height/2+100) {OnClick = (sender, e) => OpenSignUp()},
                new CustomButton(Images.Login, ScreenResolution.Width/2, ScreenResolution.Height/2-100) {OnClick = (sender, e) => OpenLogIn()}
            };
            form.Background = Images.Background;
            form.Buttons.Clear();
            form.Buttons = ObjectsToAdd;
        }
    }
}