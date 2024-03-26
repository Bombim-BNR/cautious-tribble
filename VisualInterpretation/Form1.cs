using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using BNR_CLIENT;
using BNR_GAMEPLAY;

namespace VisualInterpretation
{
    public partial class Form1 : Form
    {
        public List<CustomButton> Buttons = new List<CustomButton>();
        public List<CustomTextbox> Textboxes = new List<CustomTextbox>();
        public List<ColoredRectangle> Rectangles = new List<ColoredRectangle>();
        public Point mouseLocation;
        public Point mouseClickLocation;
        public System.Drawing.Image? Background;
        private bool? type;
        private Client? client;
        public Player? player;

        public void RunClient()
        {
            type = true;
            client = new Client();
        }

        public void StageLoad(Stages id)
        {
            switch (id)
            {
                case Stages.SIGN_OR_LOG:
                    SignOrLogin stage = new SignOrLogin();
                    stage.form = this;
                    stage.Build();
                    break;
                case Stages.SIGN_UP:
                    SignUp stage2 = new SignUp();
                    stage2.form = this;
                    stage2.Build();
                    break;
                case Stages.LOG_IN:
                    LogIn stage3 = new LogIn();
                    stage3.form = this;
                    stage3.Build();
                    break;
                case Stages.CLIENT_OR_SERVER:
                    ClientOrServer stage4 = new ClientOrServer();
                    stage4.form = this;
                    stage4.Build();
                    break;
                case Stages.MAIN_MENU:
                    Menu stage5 = new Menu();
                    stage5.form = this;
                    stage5.Build();
                    break;
                case Stages.LOBBY:
                    Lobby stage6 = new Lobby();
                    stage6.form = this;
                    stage6.Build();
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();

            StageLoad(Stages.CLIENT_OR_SERVER);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void DrawImage(Graphics Drawer, System.Drawing.Image image, int x, int y, float scale)
        {
            try
            {
                Drawer?.DrawImage(image, x, y, image.Width * scale, image.Height * scale);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (Background != null)
                {
                    DrawImage(e.Graphics, Background, 0, 0, 1f);
                }
                foreach (CustomButton button in Buttons)
                {
                    button.Interract(mouseLocation, mouseClickLocation, e, this);
                }
                foreach (CustomTextbox textbox in Textboxes)
                {
                    textbox.Draw(e, this);
                }
                foreach (ColoredRectangle rect in Rectangles)
                {
                    rect.Draw(e, this);
                }
            }
            catch
            {

            }
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseClickLocation = e.Location;
        }
    }
}
