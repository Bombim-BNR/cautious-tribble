using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VisualInterpretation
{
    public partial class Form1 : Form
    {
        public List<CustomButton> Buttons = new List<CustomButton>();
        public List<CustomTextbox> Textboxes = new List<CustomTextbox>();
        public Point mouseLocation;
        public Point mouseClickLocation;
        public System.Drawing.Image? Background;

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
            }
        }

        public Form1()
        {
            InitializeComponent();

            StageLoad(Stages.SIGN_OR_LOG);
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
