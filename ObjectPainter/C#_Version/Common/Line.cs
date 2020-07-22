using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ObjectPainter
{
    public class Line : IShape
    {
        // from interface
        public Color BrushColor { get; set; }
        public int BrushThickness { get; set; }

        public Point StartPoint;    // TODO why cannot getter and setter
        public Point EndPoint;

        public Line()
        {
            //BrushColor = Color.FromName(Constants.DEFAULT_BRUSH_COLOR);
            //BrushThickness = 1;

            StartPoint = new Point();
            EndPoint = new Point();
        }

        public void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(BrushColor, BrushThickness);
            e.Graphics.DrawLine(pen, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
        }

        public bool IsCorrectFormat()   // TODO: fix design
        {
            if (StartPoint.X <= 0 || StartPoint.Y <= 0
                || EndPoint.X <= 0 || EndPoint.Y <= 0)
            {
                MessageBox.Show(Constants.WRONG_COORDINATE_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }
            else if (BrushThickness <= 0)
            {
                MessageBox.Show(Constants.WRONG_BRUSH_THICKNESS_MESSAGE, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK);
                return false;
            }

            // TODO check if string is not a number
            // https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number

            return true;
        }
    }
}
