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
    public partial class Form5 : Form
    {
        public Form5()
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
        private void Form5_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.oyun_modu != '\0')
            {
                char ayar_hatırla = Properties.Settings.Default.oyun_modu;
                if (ayar_hatırla == '0')
                {
                    seçim_rengi(panel6, panel5, panel7, label3, label6, label8, label17, label18, label19);
                    ozelmodkapat();
                }
                else if (ayar_hatırla == '1')
                {
                    seçim_rengi(panel5, panel6, panel7, label6, label3, label8, label18, label17, label19);
                    ozelmodkapat();
                }
                else if (ayar_hatırla == '2')
                {
                    seçim_rengi(panel7, panel6, panel5, label8, label6, label3, label19, label17, label18);
                    ozelmodkapat();
                }
                else if (ayar_hatırla == '3')
                {
                    numericUpDown3.Value = Properties.Settings.Default.rows;
                    numericUpDown2.Value = Properties.Settings.Default.cols;
                    numericUpDown1.Value = Properties.Settings.Default.minecount;
                    ozelmodac();
                }
            }
            else
            {
                ozelmodkapat();
            }
            numericUpDown3.ValueChanged += numericUpDown_ValueChanged;
            numericUpDown2.ValueChanged += numericUpDown_ValueChanged;
            numericUpDown1.ValueChanged += numericUpDown_ValueChanged;
            MakeControlRounded(panel4, 40);
            MakeControlRounded(this, 40);
            MakeControlRounded(panel15, 40);
            MakeControlRounded(panel14, 40);
            MakeControlRounded(panel6, 20);
            MakeControlRounded(panel5, 20);
            MakeControlRounded(panel7, 20);
            MakeControlRounded(panel17, 8);
            MakeControlRounded(panel18, 8);
            MakeControlRounded(panel19, 8);
            MakeControlRounded(panel20, 8);
            MakeControlRounded(panel21, 8);
            formu_ortala();
            jokerHakkı_kontrolü();
        }


        private void label10_Click(object sender, EventArgs e)
        {
            if (ozelmod == false)
            {
                ozelmodac();
            }
            else
            {
                ozelmodkapat();
            }
            formu_ortala();
        }

        private void formu_ortala()
        {
            var ekranBoyutu = Screen.PrimaryScreen.WorkingArea;
            int yeniX = (ekranBoyutu.Width - this.Width) / 2;
            int yeniY = (ekranBoyutu.Height - this.Height) / 2;
            this.Location = new Point(yeniX, yeniY);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.oyun_modu = '0';
            Properties.Settings.Default.Save();
            seçim_rengi(panel6, panel5, panel7, label3, label6, label8, label17, label18, label19);
            jokerHakkı_kontrolü();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.oyun_modu = '1';
            Properties.Settings.Default.Save();
            seçim_rengi(panel5, panel6, panel7, label6, label3, label8, label18, label17, label19);
            jokerHakkı_kontrolü();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.oyun_modu = '2';
            Properties.Settings.Default.Save();
            seçim_rengi(panel7, panel6, panel5, label8, label6, label3, label19, label17, label18);
            jokerHakkı_kontrolü();
        }

        private void jokerHakkı_kontrolü()
        {
            if (Properties.Settings.Default.oyun_modu == '0')
            {
                panel17.BackColor = Color.Gold;
                panel20.BackColor = Color.Gold;
                panel18.BackColor = Color.Crimson;
                panel19.BackColor = Color.Crimson;
                panel21.BackColor = Color.Crimson;
            }
            else if (Properties.Settings.Default.oyun_modu == '1')
            {
                panel19.BackColor = Color.Gold;
                panel20.BackColor = Color.Gold;
                panel21.BackColor = Color.Gold;
                panel17.BackColor = Color.Crimson;
                panel18.BackColor = Color.Crimson;
            }
            else if (Properties.Settings.Default.oyun_modu == '2')
            {
                panel19.BackColor = Color.Gold;
                panel20.BackColor = Color.Gold;
                panel21.BackColor = Color.Gold;
                panel17.BackColor = Color.Gold;
                panel18.BackColor = Color.Gold;
            }
            else if (Properties.Settings.Default.oyun_modu == '3')
            {
                panel17.BackColor = Color.Crimson;
                panel20.BackColor = Color.Crimson;
                panel18.BackColor = Color.Crimson;
                panel19.BackColor = Color.Crimson;
                panel21.BackColor = Color.Crimson;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int rows = (int)numericUpDown3.Value;
            int cols = (int)numericUpDown2.Value;
            int mineCount = (int)numericUpDown1.Value;

            int totalCells = rows * cols;

            int minMines = Math.Max(1, (int)(totalCells * 0.1));
            int maxMines = (int)(totalCells * 0.4);

            if (mineCount < minMines)
            {
                numericUpDown1.Value = minMines;
            }
            else if (mineCount > maxMines)
            {
                numericUpDown1.Value = maxMines;
            }
        }
        private async void label14_Click(object sender, EventArgs e)
        {
            if (secili_panel == "panel6")
            {
                ozelmod_secildi(panel6, panel5, panel7, label3, label6, label8, label17, label18, label19);
            }
            else if (secili_panel == "panel5")
            {
                ozelmod_secildi(panel5, panel6, panel7, label6, label3, label8, label18, label17, label19);
            }
            else if (secili_panel == "panel7")
            {
                ozelmod_secildi(panel7, panel6, panel5, label8, label6, label3, label19, label17, label18);
            }
            Properties.Settings.Default.rows = (int)numericUpDown3.Value;
            Properties.Settings.Default.cols = (int)numericUpDown2.Value;
            Properties.Settings.Default.minecount = (int)numericUpDown1.Value;
            Properties.Settings.Default.oyun_modu = '3';
            Properties.Settings.Default.Save();
            jokerHakkı_kontrolü();
            label14.Text = "Ayarlar Kaydedildi.";
            await Task.Delay(2000);
            label14.Text = "Özel Ayarları Kaydet";
        }
        #region tasarım

        string secili_panel;
        private void seçim_rengi(Panel secili_pnl, Panel pnl2, Panel pnl3, Label secili_lbl, Label lbl2, Label lbl3, Label secili_lbl2, Label lbl4, Label lbl5)
        {
            secili_pnl.BackColor = Color.Gold;
            secili_lbl.ForeColor = Color.FromArgb(34, 34, 34);
            secili_lbl2.ForeColor = Color.FromArgb(34, 34, 34);
            lbl2.ForeColor = Color.FromArgb(200, 200, 200);
            lbl3.ForeColor = Color.FromArgb(200, 200, 200);
            lbl4.ForeColor = Color.FromArgb(200, 200, 200);
            lbl5.ForeColor = Color.FromArgb(200, 200, 200);
            pnl2.BackColor = Color.FromArgb(51, 51, 51);
            pnl3.BackColor = Color.FromArgb(51, 51, 51);
            secili_panel = secili_pnl.Name;
        }
        private void ozelmod_secildi(Panel secili_pnl, Panel pnl2, Panel pnl3, Label secili_lbl, Label lbl2, Label lbl3, Label secili_lbl2, Label lbl4, Label lbl5)
        {
            secili_pnl.BackColor = Color.FromArgb(51, 51, 51);
            secili_lbl.ForeColor = Color.FromArgb(200, 200, 200);
            secili_lbl2.ForeColor = Color.FromArgb(200, 200, 200);
            lbl2.ForeColor = Color.FromArgb(200, 200, 200);
            lbl3.ForeColor = Color.FromArgb(200, 200, 200);
            lbl4.ForeColor = Color.FromArgb(200, 200, 200);
            lbl5.ForeColor = Color.FromArgb(200, 200, 200);
            pnl2.BackColor = Color.FromArgb(51, 51, 51);
            pnl3.BackColor = Color.FromArgb(51, 51, 51);
            secili_panel = secili_pnl.Name;
        }
        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            if (secili_panel != "panel6")
            {
                panel6.BackColor = Color.FromArgb(34, 34, 34);
            }
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            if (secili_panel != "panel6")
            {
                panel6.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            panel6_MouseEnter(sender, e);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            panel6_MouseEnter(sender, e);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            panel6_MouseEnter(sender, e);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            if (secili_panel != "panel5")
            {
                panel5.BackColor = Color.FromArgb(34, 34, 34);
            }
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            if (secili_panel != "panel5")
            {
                panel5.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel5_MouseEnter(sender, e);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            panel5_MouseEnter(sender, e);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            panel5_MouseEnter(sender, e);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            if (secili_panel != "panel7")
            {
                panel7.BackColor = Color.FromArgb(34, 34, 34);
            }
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            if (secili_panel != "panel7")
            {
                panel7.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            panel7_MouseEnter(sender, e);
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            panel7_MouseEnter(sender, e);
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            panel7_MouseEnter(sender, e);
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            panel7_MouseEnter(sender, e);
        }

        bool ozelmod;
        void ozelmodac()
        {
            panel4.Size = new Size(491, 409);
            label15.Location = new Point(12, 585);
            panel15.Location = new Point(12, 613);
            this.Size = new Size(515, 775);
            MakeControlRounded(panel4, 40);
            MakeControlRounded(this, 40);
            ozelmod = true;
        }
        void ozelmodkapat()
        {
            panel4.Size = new Size(491, 280);
            label15.Location = new Point(12, 456);
            panel15.Location = new Point(12, 484);
            this.Size = new Size(515, 644);
            MakeControlRounded(panel4, 40);
            MakeControlRounded(this, 40);
            ozelmod = false;
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            panel7_MouseLeave(sender, e);
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            panel7_MouseLeave(sender, e);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            panel7_MouseLeave(sender, e);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            panel7_MouseLeave(sender, e);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            panel6_MouseLeave(sender, e);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            panel6_MouseLeave(sender, e);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            panel6_MouseLeave(sender, e);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            panel5_MouseLeave(sender, e);
        }


        private void label6_MouseLeave(object sender, EventArgs e)
        {
            panel5_MouseLeave(sender, e);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            panel5_MouseLeave(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel5_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel5_Click(sender, e);
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel5_Click(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            panel6_MouseEnter(sender, e);
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            panel6_MouseLeave(sender, e);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            panel5_Click(sender, e);
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            panel5_MouseEnter(sender, e);
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            panel5_MouseLeave(sender, e);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }

        private void label19_MouseEnter(object sender, EventArgs e)
        {
            panel7_MouseEnter(sender, e);
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            panel7_MouseLeave(sender, e);
        }

        private void panel14_MouseEnter(object sender, EventArgs e)
        {
            panel14.BackColor = Color.Gold;
            label14.ForeColor = Color.FromArgb(34, 34, 34);
        }

        private void panel14_MouseLeave(object sender, EventArgs e)
        {
            panel14.BackColor = Color.FromArgb(34, 34, 34);
            label14.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            panel14_MouseEnter(sender, e);
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            panel14_MouseLeave(sender, e);
        }
        #endregion

        private void panel14_Click(object sender, EventArgs e)
        {
            label14_Click(sender, e);
        }
    }
}
