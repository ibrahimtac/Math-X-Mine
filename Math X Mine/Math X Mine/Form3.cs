using Google.Protobuf.WellKnownTypes;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp15
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.oyun_modu != '\0')
            {
                Form frm4 = new Form4();
                frm4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen ayar seçimi yapınız.", "Yapılandırma Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this, 40);
            MakeControlRounded(panel18, 40);
            MakeControlRounded(button1, 20);
            switch (Properties.Settings.Default.oyun_modu)
            {
                case '0':
                    label4.Visible = true;
                    label5.Text = "Çaylak Çayırları";
                    label4.Text = "(Kolay Seviye | 9x9 - 10 Mayın)";
                    break;
                case '1':
                    label4.Visible = true;
                    label5.Text = "Rüzgarlı Tepeler";
                    label4.Text = "(Normal Seviye | 16x16 - 40 Mayın)";
                    break;
                case '2':
                    label4.Visible = true;
                    label5.Text = "Tehlike Kanyonu";
                    label4.Text = "(Zor Seviye | 16x30 - 99 Mayın)";
                    break;
                case '3':
                    label4.Visible = false;
                    label5.Text = "Özel Ayarlar (" + Properties.Settings.Default.rows + "x" + Properties.Settings.Default.cols +  " - " + Properties.Settings.Default.minecount + " Mayın)";
                    break;
                default:
                    label5.Text = "Ayar yapılandırması bekleniyor..";
                    label4.Visible = false;
                    break;
            }
            label4.Left = label5.Left + label5.Width;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel32_Click(sender, e);
        }

        private void panel20_Click(object sender, EventArgs e)
        {
            Form frm5 = new Form5();
            frm5.Show();
            this.Hide();
        }

        private void panel32_Click(object sender, EventArgs e)
        {
            Form frm8 = new Form8();
            frm8.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel20_Click(sender, e);
        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {
            panel20_Click(sender, e);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void linkLabel4_Click(object sender, EventArgs e)
        {
            panel32_Click(sender, e);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Crimson;
            await Task.Delay(500);
            label5.ForeColor = Color.FromArgb(200,200,200);
        }
    }
}
