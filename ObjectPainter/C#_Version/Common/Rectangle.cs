using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ObjectPainter
{
    public class Rectangle : IShape
    {
        // from interface
        public Color BackgroudColor { get; set; }
        public Color BrushColor { get; set; }
        public int BrushThickness { get; set; }

        public Point StartPoint;
        public int Height { get; set; }
        public int Width { get; set; }

        public Rectangle()
        {
            //BackgroudColor = Color.FromName(Constants.DEFAULT_BACKGROUD_COLOR);
            //BrushColor = Color.FromName(Constants.DEFAULT_BRUSH_COLOR);
            //BrushThickness = 1;
        }

        public void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(BrushColor, BrushThickness);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(StartPoint.X, StartPoint.Y, Width, Height);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.FillRectangle(new SolidBrush(BackgroudColor), rect);
        }

        public bool IsCorrectFormat()
        {
            if (StartPoint.X <= 0 || StartPoint.Y <= 0)
            {
                MessageBox.Show(Constants.WRONG_COORDINATE_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }
            else if (Width <= 0)
            {
                MessageBox.Show(Constants.WRONG_WIDTH_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }
            else if (Height <= 0)
            {
                MessageBox.Show(Constants.WRONG_HEIGHT_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }
            else if (BrushThickness <= 0)
            {
                MessageBox.Show(Constants.WRONG_BRUSH_THICKNESS_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}