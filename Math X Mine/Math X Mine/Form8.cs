using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this, 40);
            MakeControlRounded(panel25, 40);
            MakeControlRounded(panel2, 40);
            MakeControlRounded(panel4, 40);
            MakeControlRounded(panel6, 40);
            MakeControlRounded(panel7, 40);
            MakeControlRounded(panel8, 40);
            MakeControlRounded(panel10, 40);
            MakeControlRounded(panel11, 40);
            MakeControlRounded(panel12, 40);
            MakeControlRounded(panel13, 40);
            MakeControlRounded(panel14, 40);
            MakeControlRounded(panel15, 40);
        }
        public void MakeControlRounded(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
