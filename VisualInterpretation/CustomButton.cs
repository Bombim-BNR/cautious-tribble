using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualInterpretation
{
    public class CustomButton
    {
        static public bool IfInRect(Point from, Point to, Point point)
        {
            if (from.X <= point.X && point.X <= to.X)
            {
                if (from.Y <= point.Y && point.Y <= to.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public int X { get; set; }
        public int Y { get; set; }
        private float animation;
        public EventHandler OnClick;
        public Image? Image { get; set; }

        public CustomButton(Image image, int CenterX, int CenterY)
        {
            animation = 0;
            Image = image;
            X = CenterX - image.Width / 2;
            Y = CenterY - image.Height / 2;
        }

        public void OnHover(PaintEventArgs drawer, Form1 form)
        {
            drawer.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 255, 255)),
                X - (animation / 2f * ((float)(Image.Width / 2) / Image.Height)),
                Y - (animation / 2f * ((float)Image.Height / (Image.Width / 2))),
                Image.Width + (animation * ((float)Image.Width / 2 / Image.Height)),
                Image.Height + (animation * ((float)Image.Height / (Image.Width / 2))));
            animation += (30 - animation) / 5;
        }

        public void OnClickInvoke(PaintEventArgs drawer, Form1 form)
        {
            form.mouseClickLocation = new Point(-1, -1);
            form.mouseLocation = new Point(-1, -1);
            OnClick.Invoke((object)this, null);
        }

        public void Interract(Point mouse, Point mouseClick, PaintEventArgs drawer, Form1 form)
        {
            drawer.Graphics.DrawImage(Image, 
                X - (animation / 2f * ((float)(Image.Width / 2) / Image.Height)), 
                Y - (animation / 2f * ((float)Image.Height / (Image.Width / 2))), 
                Image.Width + (animation * ((float)Image.Width / 2 / Image.Height)), 
                Image.Height + (animation * ((float)Image.Height / (Image.Width / 2))));
            
            if (IfInRect(new Point(X, Y), new Point(Image.Width+X, Image.Height+Y), mouse))
            {
                OnHover(drawer, form);
            }
            else
            {
                animation += (0 - animation) / 5;
            }
            if (IfInRect(new Point(X, Y), new Point(Image.Width + X, Image.Height + Y), mouseClick))
            {
                OnClickInvoke(drawer, form);
            }
        }
    }
}
