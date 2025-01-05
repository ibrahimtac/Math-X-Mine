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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void MakeControlRounded(Control control, int radius)
        {
            // Oval şekil oluşturmak için GraphicsPath
            GraphicsPath path = new GraphicsPath();

            // Oval köşeler için gerekli Arc'leri ekleyin
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90); // Sol üst köşe
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90); // Sağ üst köşe
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90); // Sağ alt köşe
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90); // Sol alt köşe
            path.CloseAllFigures();

            // Kontrolün kenarlarını yuvarlak hale getir
            control.Region = new Region(path);
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this,40);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form giris = new Form2();
            giris.Show();
            this.Close();
        }
    }
}
