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
        CLIENT_OR_SERVER,
        MAIN_MENU,
        LOBBY
    }
    static public class Images
    {
        static public Image Login = Image.FromFile("..\\..\\..\\data\\images\\LOGIN.png");
        static public Image SignUp = Image.FromFile("..\\..\\..\\data\\images\\SIGNUP.png");
        static public Image Background = Image.FromFile("..\\..\\..\\data\\images\\BACKGROUND.png");
        static public Image Client = Image.FromFile("..\\..\\..\\data\\images\\CLIENT.png");
        static public Image Server = Image.FromFile("..\\..\\..\\data\\images\\SERVER.png");
        static public Image Play = Image.FromFile("..\\..\\..\\data\\images\\PLAY.png");
        static public Image Settings = Image.FromFile("..\\..\\..\\data\\images\\SETTINGS.png");
        static public Image Exit = Image.FromFile("..\\..\\..\\data\\images\\EXIT.png");
        static public Image Start = Image.FromFile("..\\..\\..\\data\\images\\START.png");
        static public Image SelectAnother = Image.FromFile("..\\..\\..\\data\\images\\SELECTANOTHER.png");
        static public Image MapIsrael = Image.FromFile("..\\..\\..\\data\\images\\MapIsrael.png");
    }
}
