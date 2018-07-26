using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueServer
{
    public partial class QueueServerWithDesign : Form
    {
        Color maincolor = Color.FromArgb(143, 180, 239);
        Color secondarycolor = Color.FromArgb(255, 255, 255);
        public QueueServerWithDesign()
        {
            InitializeComponent();
            string sr = DateTime.Now.ToString("h:mm tt yyyy-MM-dd");
            tableLayoutPanel1.BackColor = maincolor;
            DateLabel.Text = sr;
        }

        /*private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            
            
            var brush = new SolidBrush(myrgbColor);
            if (e.Row == 0 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            if (e.Row == 2 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }*/

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var brush = new SolidBrush(secondarycolor);
            if (e.Row == 0 && e.Column == 1)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            if (e.Row == 0 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
}
