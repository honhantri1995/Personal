using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ObjectPainter
{
    public interface IShape
    {
        Color BrushColor { get; set; }
        int BrushThickness { get; set; }

        void Draw(PaintEventArgs e);
        bool IsCorrectFormat();
    }
}
