using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using WindowsFormsApp15.Properties;

namespace WindowsFormsApp15
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.kullanici_adi != string.Empty)
            {
                check_kontrol = true;
                pictureBox5.Image = Properties.Resources._checked;
                textBox1.Text = Properties.Settings.Default.kullanici_adi;
                textBox2.Text = Properties.Settings.Default.sifre;
                textBox1.TabStop = false;
                textBox2.TabStop = false;
            }
            else
            {
                check_kontrol = false;
            }
            MakeControlRounded(button1, 20);
            MakeControlRounded(textBox1, 20);
            MakeControlRounded(textBox2, 20);
            MakeControlRounded(this, 40);
            MakeControlRounded(panel5, 40);
            MakeControlRounded(panel6, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eposta = textBox1.Text;
            string sifre = textBox2.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(eposta, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.");
                return;
            }

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Şifre boş bırakılamaz.");
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string query = "SELECT id, kullanici_adi FROM kullanıcılar WHERE eposta = @email AND sifre = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", eposta);
                        cmd.Parameters.AddWithValue("@password", sifre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string kullanici_adi = reader.GetString(1);

                                if (check_kontrol == true)
                                {
                                    Properties.Settings.Default.kullanici_adi = textBox1.Text;
                                    Properties.Settings.Default.sifre = textBox2.Text;
                                    Properties.Settings.Default.Save();
                                }

                                if (kullanici_adi != Properties.Settings.Default.son_giris_yapan)
                                {
                                    Properties.Settings.Default.oyun_modu = '\0';
                                }

                                MessageBox.Show($"Hoşgeldin, {kullanici_adi}");
                                Properties.Settings.Default.son_giris_yapan = kullanici_adi;
                                Properties.Settings.Default.id = id;
                                Properties.Settings.Default.Save();

                                Form frm3 = new Form3();
                                frm3.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen bilgileri doğru giriniz.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool check_kontrol;
        private void panel6_Click(object sender, EventArgs e)
        {
            if (check_kontrol == true)
            {
                Properties.Settings.Default.kullanici_adi = string.Empty;
                Properties.Settings.Default.sifre = string.Empty;
                Properties.Settings.Default.Save();
                pictureBox5.Image = Properties.Resources.checkbox;
                check_kontrol = false;
            }
            else if (check_kontrol == false)
            {
                pictureBox5.Image = Properties.Resources._checked;
                check_kontrol = true;
            }
        }

        #region tasarım_bloğu
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
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gold;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gold;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel6_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm9 = new Form9();
            frm9.Show();
            this.Hide();
        }
        #endregion
    }
}
