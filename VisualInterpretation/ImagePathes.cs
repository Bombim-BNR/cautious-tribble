using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    static public class ScreenResolution
    {
        static public int Width = 1180;
        static public int Height = 765;
    }
    public enum Stages
    {
        SIGN_OR_LOG = 0,
        SIGN_UP,
        LOG_IN,
    }
    static public class Images
    {
        static public Image Login = Image.FromFile("..\\..\\..\\data\\images\\LOGIN.png");
        static public Image SignUp = Image.FromFile("..\\..\\..\\data\\images\\SIGNUP.png");
        static public Image Background = Image.FromFile("..\\..\\..\\data\\images\\BACKGROUND.png");
    }
}
