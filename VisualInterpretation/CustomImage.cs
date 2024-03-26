using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class CustomImage
    {
        public int X { get; set; }
        public int Y { get; set; }
        public float Resize {  get; set; }
        public Image? Image { get; set; }

        public CustomImage(Image image, int CenterX, int CenterY)
        {
            Image = image;
            //X = (int)Math.Round(CenterX - (image.Width * Resize) / 2);
            //Y = (int)Math.Round(CenterY - (image.Width * Resize) / 2);
        }

        public void Draw(PaintEventArgs drawer, Form1 form)
        {
            drawer.Graphics.DrawImage(Image,
                X,
                Y,
                Image.Width * Resize,
                Image.Height * Resize);
        }
    }
}
