using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInterpretation
{
    public class ColoredRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public SolidBrush? SolidBrush { get; set; }
        
        public void Draw(PaintEventArgs drawer, Form1 form)
        {
            if (SolidBrush != null)
            {
                drawer.Graphics.FillRectangle(SolidBrush, new Rectangle(X, Y, Width, Height));
            }
        }
    }
}
