using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class CustomTextbox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TextBox TextBox;
        public Image? Image { get; set; }

        public CustomTextbox(int CenterX, int CenterY, int length, Form1 form)
        {
            X = CenterX - length / 2;
            Y = CenterY - length / 2 - 50;
            TextBox = new TextBox();
            TextBox.Location = new Point(X, Y);
            TextBox.Width = length;
            TextBox.Font = new Font(FontFamily.GenericSansSerif, 52);
            TextBox.BorderStyle = BorderStyle.None;
            form.Controls.Add(TextBox);
        }

        public void Draw(PaintEventArgs drawer, Form1 form)
        {
            drawer.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 255, 255)),
                X - TextBox.Height / 2, Y, TextBox.Height, TextBox.Height);
            drawer.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 255, 255)),
                X + TextBox.Width - TextBox.Height / 2, Y, TextBox.Height, TextBox.Height);
        }
    }
}
