using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this, 40);
            MakeControlRounded(button1, 20);
            MakeControlRounded(textBox1, 20);
            MakeControlRounded(textBox2, 20);
            MakeControlRounded(textBox3, 20);
            MakeControlRounded(panel6, 40);
            MakeControlRounded(panel8, 30);
            MakeControlRounded(panel9, 30);
        }

        char cinsiyet;
        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text;
            string sifre = textBox2.Text;
            string eposta = textBox3.Text;

            DateTime dogumTarihi;
            bool dogumTarihiValid = DateTime.TryParseExact(maskedTextBox1.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dogumTarihi);

            if (!System.Text.RegularExpressions.Regex.IsMatch(eposta, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || string.IsNullOrEmpty(kAdi) || string.IsNullOrEmpty(sifre) || cinsiyet != 'E' && cinsiyet != 'K' || !dogumTarihiValid)
            {
                MessageBox.Show("Lütfen boş veya geçersiz alan bırakmayınız .");
                return;
            }

            string dogumT = dogumTarihi.ToString("yyyy-MM-dd");


            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO kullanıcılar (kullanici_adi, sifre, eposta, dogum_tarihi, cinsiyet) " +
                                   "VALUES (@KullaniciAd, @Sifre, @Eposta, @DogumTarihi, @Cinsiyet)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAd", kAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    cmd.Parameters.AddWithValue("@DogumTarihi", dogumT);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Yeni kullanıcı başarıyla eklendi.");
                        Form frm2 = new Form2();
                        frm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı ekleme başarısız.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Girilen e-posta veya kullanıcı adı zaten bulunuyor. Lütfen başka bilgiler ile tekrar deneyiniz!","Bu bilgiler zaten kayıtlı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Gold;
            panel9.BackColor = Color.FromArgb(51, 51, 51);

            isPanel8Clicked = true;
            isPanel9Clicked = false;
            cinsiyet = 'E';
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Gold;
            panel8.BackColor = Color.FromArgb(51, 51, 51);

            isPanel8Clicked = false;
            isPanel9Clicked = true;
            cinsiyet = 'K';
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

        private void textBox3_Enter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gold;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(200, 200, 200);
        }


        private bool isPanel8Clicked = false;
        private bool isPanel9Clicked = false;

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Gold;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            if (!isPanel8Clicked)
            {
                panel8.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Gold;
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            if (!isPanel9Clicked)
            {
                panel9.BackColor = Color.FromArgb(51, 51, 51);
            }
        }
        #endregion
    }
}
