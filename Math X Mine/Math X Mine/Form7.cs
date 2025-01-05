using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp15
{
    public partial class Form7 : Form
    {
        Form frm3 = new Form3();
        TimeSpan remainingTime;
        public double puan_hafıza;
        public bool sınır_asildi_mi;
        public int zaman;
        public Form7()
        {
            InitializeComponent();
        }

        private Form4 form4;

        public Form7(Form4 existingForm4)
        {
            InitializeComponent();
            form4 = existingForm4;
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

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Crimson;
            label6.ForeColor = Color.FromArgb(200, 200, 200);
            label6.BackColor = Color.Crimson;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.FromArgb(34, 34, 34);
            label6.ForeColor = Color.Crimson;
            label6.BackColor = Color.FromArgb(34, 34, 34);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel8_MouseEnter(sender,e);
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            MakeControlRounded(button1,20);
            MakeControlRounded(button2, 20);
            MakeControlRounded(button3, 20);
            MakeControlRounded(button4, 20);
            MakeControlRounded(panel8, 40);
            MakeControlRounded(this, 40);
            if (Properties.Settings.Default.oyun_modu == '0')
            {
                soru_sayisi = 5;
                remainingTime = new TimeSpan(0, 1, 0);
            }
            else if (Properties.Settings.Default.oyun_modu == '1')
            {
                soru_sayisi = 5;
                remainingTime = new TimeSpan(0, 1, 30);
            }
            else if (Properties.Settings.Default.oyun_modu == '2')
            {
                soru_sayisi = 5;
                remainingTime = new TimeSpan(0, 2, 0);
            }
            soruları_al(true, soru_sayisi);
            kacinci_soru++;
            label3.Text = kacinci_soru + "/" + soru_sayisi;
            soruları_al(false, 0);
            label5.Text = remainingTime.ToString(@"mm\:ss");
            timer1.Start();
        }

        List<int> randomIds = new List<int>();
        int soru_sayisi;
        int kacinci_soru = 0;
        int dogruCevapIndex;
        private void soruları_al(bool listeye_ekle, int soru_sayisi)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string query = "SELECT id FROM matematiksorulari WHERE oyun_modu = '" + Properties.Settings.Default.oyun_modu + "' ORDER BY RAND() LIMIT " + soru_sayisi + ";";
                    if (listeye_ekle == true)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    randomIds.Add(reader.GetInt32("id"));
                                }
                            }
                        }
                    }
                    else
                    {
                        int secondId = randomIds[kacinci_soru - 1];

                        query = "SELECT soru, dogru_cevap, yanlis_cevap1, yanlis_cevap2, yanlis_cevap3 " +
                                "FROM MatematikSorulari WHERE id = @id;";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", secondId);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string soru = reader.GetString("soru");
                                    string dogruCevap = reader.GetString("dogru_cevap");
                                    string yanlisCevap1 = reader.GetString("yanlis_cevap1");
                                    string yanlisCevap2 = reader.GetString("yanlis_cevap2");
                                    string yanlisCevap3 = reader.GetString("yanlis_cevap3");


                                    List<string> cevaplar = new List<string>
                                    {
                                                    dogruCevap,
                                                    yanlisCevap1,
                                                    yanlisCevap2,
                                                    yanlisCevap3
                                    };

                                    Random random = new Random();
                                    for (int i = cevaplar.Count - 1; i > 0; i--)
                                    {
                                        int j = random.Next(i + 1);
                                        string temp = cevaplar[i];
                                        cevaplar[i] = cevaplar[j];
                                        cevaplar[j] = temp;
                                    }

                                    richTextBox1.Text = soru;
                                    button1.Text = "A-) " + cevaplar[0];
                                    button2.Text = "B-) " + cevaplar[1];
                                    button3.Text = "C-) " + cevaplar[2];
                                    button4.Text = "D-) " + cevaplar[3];

                                    dogruCevapIndex = cevaplar.IndexOf(dogruCevap);

                                }
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

        private void label6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (sınır_asildi_mi)
            {
                double toplam_puan;
                toplam_puan = puan_hafıza - (zaman * 0.1);
                if (toplam_puan > 0)
                {
                    puan_kayit.puan_kaydet(toplam_puan);
                    MessageBox.Show("Pes etmek de taktik, ama bu taktikte kazanan yok, oyun sona erdi!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Oyunun Sonu: Pes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    puan_kayit.puan_kaydet(puan_hafıza);
                    MessageBox.Show("Pes etmek de taktik, ama bu taktikte kazanan yok, oyun sona erdi!\n\nPuan: " + puan_hafıza, "Oyunun Sonu: Pes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pes etmek de taktik, ama bu taktikte kazanan yok, oyun sona erdi!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Oyunun Sonu: Pes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frm3.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dogruCevapIndex == 0)
            {
                if (kacinci_soru != soru_sayisi)
                {
                    MessageBox.Show("Tebrikler, cevabınız doğru!", "Soruyu Çözdün, Yola Devam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kacinci_soru++;
                    label3.Text = kacinci_soru + "/" + soru_sayisi;
                    soruları_al(false, 0);
                    return;
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Vay be! Matematikte seni geçemedik, mayınlar da geçemeyecek!\n\nOyuna geri dönüyorsun..", "Hesap Tam, Zafer Tam!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    form4.Show();
                    form4.Timer1.Start();
                }
            }
            else
            {
                timer1.Stop();
                if (sınır_asildi_mi)
                {
                    double toplam_puan;
                    toplam_puan = puan_hafıza - (zaman * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(puan_hafıza);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + puan_hafıza, "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frm3.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dogruCevapIndex == 1)
            {
                if (kacinci_soru != soru_sayisi)
                {
                    MessageBox.Show("Tebrikler, cevabınız doğru!", "Soruyu Çözdün, Yola Devam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kacinci_soru++;
                    label3.Text = kacinci_soru + "/" + soru_sayisi;
                    soruları_al(false, 0);
                    return;
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Vay be! Matematikte seni geçemedik, mayınlar da geçemeyecek!\n\nOyuna geri dönüyorsun..", "Hesap Tam, Zafer Tam!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    form4.Show();
                    form4.Timer1.Start();
                }
            }
            else
            {
                timer1.Stop();
                if (sınır_asildi_mi)
                {
                    double toplam_puan;
                    toplam_puan = puan_hafıza - (zaman * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(puan_hafıza);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + puan_hafıza, "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frm3.Show();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dogruCevapIndex == 2)
            {
                if (kacinci_soru != soru_sayisi)
                {
                    MessageBox.Show("Tebrikler, cevabınız doğru!", "Soruyu Çözdün, Yola Devam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kacinci_soru++;
                    label3.Text = kacinci_soru + "/" + soru_sayisi;
                    soruları_al(false, 0);
                    return;
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Vay be! Matematikte seni geçemedik, mayınlar da geçemeyecek!\n\nOyuna geri dönüyorsun..", "Hesap Tam, Zafer Tam!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    form4.Show();
                    form4.Timer1.Start();
                }
            }
            else
            {
                timer1.Stop();
                if (sınır_asildi_mi)
                {
                    double toplam_puan;
                    toplam_puan = puan_hafıza - (zaman * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(puan_hafıza);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + puan_hafıza, "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frm3.Show();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dogruCevapIndex == 3)
            {
                if (kacinci_soru != soru_sayisi)
                {
                    MessageBox.Show("Tebrikler, cevabınız doğru!", "Soruyu Çözdün, Yola Devam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kacinci_soru++;
                    label3.Text = kacinci_soru + "/" + soru_sayisi;
                    soruları_al(false, 0);
                    return;
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Vay be! Matematikte seni geçemedik, mayınlar da geçemeyecek!\n\nOyuna geri dönüyorsun..", "Hesap Tam, Zafer Tam!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    form4.Show();
                    form4.Timer1.Start();
                }
            }
            else
            {
                timer1.Stop();
                if (sınır_asildi_mi)
                {
                    double toplam_puan;
                    toplam_puan = puan_hafıza - (zaman * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(puan_hafıza);
                        MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: " + puan_hafıza, "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eyvah! Mayını geçtin, ama bu soru seni yakaladı!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Soru patladı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frm3.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            if (remainingTime.TotalSeconds <= 0)
            {
                timer1.Stop();
                if (sınır_asildi_mi)
                {
                    double toplam_puan;
                    toplam_puan = puan_hafıza - (zaman * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Zamanı geçtin! Bu seferki yarış biraz erken bitti!\n\nPuan: " + toplam_puan + "\nHam Puan: " + puan_hafıza + " || Süre cezası: " + (zaman * 0.1), "Vakit Tükendi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(puan_hafıza);
                        MessageBox.Show("Zamanı geçtin! Bu seferki yarış biraz erken bitti!\n\nPuan: " + puan_hafıza, "Vakit Tükendi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Zamanı geçtin! Bu seferki yarış biraz erken bitti!\n\nPuan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Vakit Tükendi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frm3.Show();
                this.Close();
            }
            else
            {
                if (remainingTime.TotalSeconds <= 30)
                {
                    label5.ForeColor = Color.Crimson;
                }
                label5.Text = remainingTime.ToString(@"mm\:ss");
            }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            label6_Click(sender,e);
        }
    }
}