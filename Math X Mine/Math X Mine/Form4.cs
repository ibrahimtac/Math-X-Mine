using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form4 : Form
    {
        private int rows;
        private int cols;
        private int mineCount;
        private Button[,] buttons;
        private int[,] field;
        private bool isGameOver = false;
        private bool isFirstClick = true;
        private int elapsedTime = 0;
        private int score;
        private int dogruKoyulanBayrakSayisi;
        public Timer Timer1
        {
            get { return timer1; }
        }
        public Form4()
        {
            InitializeComponent();
            ayar_kontrol();
            InitializeForm();
            jokerHakkı_kontrol();
        }
        int kullanilan_joker;
        int eldeEdilen_Joker;
        private void jokerHakkı_kontrol()
        {
            if (Properties.Settings.Default.oyun_modu == '0')
            {
                if (kullanilan_joker == 0)
                {
                    if (dogruKoyulanBayrakSayisi < 4)
                    {
                        if (eldeEdilen_Joker == 0)
                        {
                            label7.Text = "1. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 1)
                        {
                            label7.Text = "1. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources._2_kati_puan;
                            label3.Text = "Joker Hakkı: İki Katı Bonus!";
                            label4.Text = "Açılan her hücre başına iki katı \r\npuan kazan!";
                        }
                    }
                }
                else if(kullanilan_joker == 1)
                {
                    if (dogruKoyulanBayrakSayisi < 8)
                    {
                        if (eldeEdilen_Joker == 1)
                        {
                            label7.Text = "2. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker  != 2)
                        {
                            label7.Text = "2. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.zamani_geri_al;
                            label3.Text = "Joker Hakkı: Zamanı Geri Al!";
                            label4.Text = "Sayaçta geçen zamanı düşür ve \r\ndaha fazla oynamaya hak kazan!";
                        }
                    }
                }
                else if (kullanilan_joker == 2)
                {
                    label7.Text = "Joker hakları kullanıldı ✔";
                    this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                }
            }
            else if (Properties.Settings.Default.oyun_modu == '1')
            {
                if (kullanilan_joker == 0)
                {
                    if (dogruKoyulanBayrakSayisi < 10)
                    {
                        if (eldeEdilen_Joker == 0)
                        {
                            label7.Text = "1. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 1)
                        {
                            label7.Text = "1. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.x_isini;
                            label3.Text = "Joker Hakkı: X Işınını Aktif Et!";
                            label4.Text = "X ışınını aktif et ve üç saniyeliğine üç \r\nadet mayının yerini gör!";
                        }
                    }
                }
                else if (kullanilan_joker == 1)
                {
                    if (dogruKoyulanBayrakSayisi < 20)
                    {
                        if (eldeEdilen_Joker == 1)
                        {
                            label7.Text = "2. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 2)
                        {
                            label7.Text = "2. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.zamani_geri_al;
                            label3.Text = "Joker Hakkı: Zamanı Geri Al!";
                            label4.Text = "Sayaçta geçen zamanı düşür ve \r\ndaha fazla oynamaya hak kazan!";
                        }
                    }
                }
                else if (kullanilan_joker == 2)
                {
                    if (dogruKoyulanBayrakSayisi < 30)
                    {
                        if (eldeEdilen_Joker == 2)
                        {
                            label7.Text = "3. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        
                        if (eldeEdilen_Joker != 3)
                        {
                            label7.Text = "3. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.odul;
                            label3.Text = "Joker Hakkı: Sürpriz Puanlar!";
                            label4.Text = "Bir dakika boyunca açılacak hücrelerden \r\ngizli puanlar çıkar!";
                        }
                    }

                }
                else if (kullanilan_joker == 3)
                {
                    label7.Text = "Joker hakları kullanıldı ✔";
                    this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                }


            }
            else if (Properties.Settings.Default.oyun_modu == '2')
            {

                if (kullanilan_joker == 0)
                {
                    if (dogruKoyulanBayrakSayisi < 15)
                    {
                        if (eldeEdilen_Joker == 0)
                        {
                            label7.Text = "1. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 1)
                        {
                            label7.Text = "1. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.odul;
                            label3.Text = "Joker Hakkı: Sürpriz Puanlar!";
                            label4.Text = "Bir dakika boyunca açılacak hücrelerden \r\ngizli puanlar çıkar!";
                        }
                    }
                }
                else if (kullanilan_joker == 1)
                {
                    if (dogruKoyulanBayrakSayisi < 30)
                    {
                        if (eldeEdilen_Joker == 1)
                        {
                            label7.Text = "2. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 2)
                        {
                            label7.Text = "2. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.zamani_geri_al;
                            label3.Text = "Joker Hakkı: Zamanı Geri Al!";
                            label4.Text = "Sayaçta geçen zamanı düşür ve \r\ndaha fazla oynamaya hak kazan!";
                        }
                    }
                }
                else if (kullanilan_joker == 2)
                {
                    if (dogruKoyulanBayrakSayisi < 45)
                    {
                        if (eldeEdilen_Joker == 2)
                        {
                            label7.Text = "3. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 3)
                        {
                            label7.Text = "3. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.x_isini;
                            label3.Text = "Joker Hakkı: X Işınını Aktif Et!";
                            label4.Text = "X ışınını aktif et ve üç saniyeliğine üç \r\nadet mayının yerini gör!";
                        }
                    }
                }
                else if (kullanilan_joker == 3)
                {
                    if (dogruKoyulanBayrakSayisi < 60)
                    {
                        if (eldeEdilen_Joker == 3)
                        {
                            label7.Text = "4. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                       if (eldeEdilen_Joker != 4)
                        {
                            label7.Text = "4. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources._2_kati_puan;
                            label3.Text = "Joker Hakkı: İki Katı Bonus!";
                            label4.Text = "Açılan her hücre başına iki katı \r\npuan kazan!";
                        }
                    }
                }
                else if (kullanilan_joker == 4)
                {
                    if (dogruKoyulanBayrakSayisi < 75)
                    {
                        if (eldeEdilen_Joker == 4)
                        {
                            label7.Text = "5. Joker Hakkı için doğru bayrakları dik!";
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                        }
                    }
                    else
                    {
                        if (eldeEdilen_Joker != 5)
                        {
                            label7.Text = "5. Joker Hakkı kullanıma hazır 🎉";
                            eldeEdilen_Joker++;
                            this.Size = new Size(panel3.Width + 24, panel4.Bottom + 20);
                            pictureBox2.Image = Properties.Resources.mayin_korumasi;
                            label3.Text = "Joker Hakkı: Mayın Kalkanı!";
                            label4.Text = "Kalkan aktif edildiğinde üç mayına \r\nkadar koruma sağlar!";
                        }
                    }
                }
                else if (kullanilan_joker == 5)
                {
                    label7.Text = "Joker hakları kullanıldı ✔";
                    this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
                }
            }
            else if (Properties.Settings.Default.oyun_modu == '3')
            {
                label7.Visible = false;
                return;
            }

            label7.Location = new Point(panel3.Width - label7.Width, panel3.Bottom + 11);
            MakeControlRounded(panel4, 40);
            MakeControlRounded(this, 40);
            formu_ortala();
        }

        private void ayar_kontrol()
        {
            switch (Properties.Settings.Default.oyun_modu)
            {
                case '0':
                    rows = 9; cols = 9; mineCount = 10;
                    break;
                case '1':
                    rows = 16; cols = 16; mineCount = 40;
                    break;
                case '2':
                    rows = 16; cols = 30; mineCount = 99;
                    break;
                case '3':
                    rows = Properties.Settings.Default.rows; cols = Properties.Settings.Default.cols; mineCount = Properties.Settings.Default.minecount;
                    break;
            }
            label1.Text = mineCount.ToString();
        }

        private void InitializeForm()
        {
            UpdateFormSize();
            InitializeGame();
            CustomizeAllButtonsInPanel();
        }

        private void UpdateFormSize()
        {
            panel3.Size = new Size(cols * 45, rows * 45);

            panel3.Location = new Point(12, panel2.Bottom + 20);
            label5.Location = new Point(7, panel3.Bottom + 8);
            panel4.Location = new Point(12, label5.Bottom + 10);
            panel2.Size = new Size(panel3.Width, 70);
            panel4.Size = new Size(panel3.Width, 78);

            pictureBox1.Left = (panel3.Width - pictureBox1.Width) / 2;
            pictureBox2.Left = panel3.Left - 10;
            label3.Left = (panel3.Width - label3.Width) / 2;
            label4.Left = label3.Left + 2;
            pictureBox3.Left = (panel3.Width - pictureBox3.Width) - 10;

            this.Size = new Size(panel3.Width + 24, panel4.Bottom - 80);
            formu_ortala();
        }

        private void InitializeGame()
        {
            panel3.Controls.Clear();
            buttons = new Button[rows, cols];
            field = new int[rows, cols];
            isGameOver = false;
            isFirstClick = true;
            elapsedTime = 0;
            timer1.Start();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    buttons[row, col] = new Button
                    {
                        BackColor = Color.FromArgb(34, 34, 34),
                        ForeColor = Color.Gold,
                        Size = new Size(45, 45),
                        FlatStyle = FlatStyle.Flat,
                        TabStop = false,
                        Cursor = Cursors.Hand,
                        Location = new Point(col * 45, row * 45),
                        Font = new Font("Arial", 20, FontStyle.Bold),
                        Tag = new Point(row, col)
                    };
                    buttons[row, col].MouseUp += Button_Click;
                    panel3.Controls.Add(buttons[row, col]);
                }
            }
        }
        private void CustomizeButton(Button button)
        {
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.FromArgb(61, 61, 61);
        }
        private void CustomizeAllButtonsInPanel()
        {
            foreach (Control control in panel3.Controls)
            {
                if (control is Button button)
                {
                    CustomizeButton(button);
                }
            }
        }


        private void PlaceMines(Point firstClick)
        {
            Random random = new Random();
            int minesPlaced = 0;

            while (minesPlaced < mineCount)
            {
                int row = random.Next(rows);
                int col = random.Next(cols);

                if (field[row, col] == -1 || (Math.Abs(row - firstClick.X) <= 1 && Math.Abs(col - firstClick.Y) <= 1))
                    continue;

                field[row, col] = -1;
                minesPlaced++;
            }
        }

        private void CalculateNumbers()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == -1) continue;

                    int mineCount = 0;

                    for (int dr = -1; dr <= 1; dr++)
                    {
                        for (int dc = -1; dc <= 1; dc++)
                        {
                            int nr = row + dr;
                            int nc = col + dc;

                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && field[nr, nc] == -1)
                            {
                                mineCount++;
                            }
                        }
                    }

                    field[row, col] = mineCount;
                }
            }
        }

        private bool x2_bonus = false;
        private bool hakVarmi = true;
        Random rastgele_puan = new Random();
        int toplamSurprizPuan = 0;
        int recursionDepth = 0;
        private async void OpenCell(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || !buttons[row, col].Enabled) return;

            if (buttons[row, col].Text == "🚩") return;

            if (field[row, col] == -1)
            {
                buttons[row, col].BackColor = Color.Crimson;
                buttons[row, col].ForeColor = Color.White;
                buttons[row, col].Text = "💣";

                if (kalkan == true && korunan_mayın_Sayisi < 3)
                {
                    buttons[row, col].BackColor = Color.MidnightBlue;
                    buttons[row, col].Text = "🛡️";
                    buttons[row, col].Enabled = false;
                    label1.Text = (int.Parse(label1.Text) - 1).ToString();
                    korunan_mayın_Sayisi++;
                    if (korunan_mayın_Sayisi == 3)
                    {
                        kalkan = false;
                    }
                }
                else
                {
                    if (Properties.Settings.Default.oyun_modu != '3')
                    {
                        if (hakVarmi == false)
                        {
                            GameOver(false);
                        }
                        else
                        {
                            timer1.Stop();
                            Form7 form7 = new Form7(this);
                            buttons[row, col].BackColor = Color.Green;
                            buttons[row, col].Enabled = false;
                            label1.Text = (int.Parse(label1.Text) - 1).ToString();
                            hakVarmi = false;
                            isGameOver = true;
                            await Task.Delay(500);
                            MessageBox.Show("Bomba seni aldı, ama endişelenme, bir şansın daha var! 🤗\n\nMatematik sorularını doğru cevapla ve oyuna geri dön, belki bu sefer patlamazsın!", "Son Bir Şans!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            isGameOver = false;
                            if (dogruKoyulanBayrakSayisi >= mineCount / 5)
                            {
                                form7.sınır_asildi_mi = true;
                            }
                            else
                            {
                                form7.sınır_asildi_mi = false;
                            }
                            form7.puan_hafıza = score;
                            form7.zaman = (int.Parse(label2.Text));
                            form7.Show(this);
                            this.Hide();
                        }
                    }
                    else
                    {
                        GameOver(false);
                    }
                }         
                return;
            }

            buttons[row, col].Enabled = false;
            buttons[row, col].BackColor = Color.FromArgb(100, 100, 100);

            if (field[row, col] != -1)
            {
                if (x2_bonus)
                {
                    score += 2;
                }
                else
                {
                    score++;
                }

                if (surpriz_puan)
                {
                    Point currentPoint = new Point(row, col);
                    if (puanlı_hucreler.Contains(currentPoint))
                    {
                        int randomBonus = rastgele_puan.Next(1, 11);
                        toplamSurprizPuan += randomBonus;
                        score += randomBonus;
                        puanlı_hucreler.Remove(currentPoint);
                    }
                }
            }


            if (field[row, col] > 0)
            {
                buttons[row, col].Text = field[row, col].ToString();
            }
            else if (field[row, col] == 0)
            {
                recursionDepth++;
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        if (dr == 0 && dc == 0) continue;
                        OpenCell(row + dr, col + dc);
                    }
                }
                recursionDepth--;
            }


            if (recursionDepth == 0)
            {
                if (toplamSurprizPuan > 0)
                {
                    label5.Text = "Puan: " + score + " | " + toplamSurprizPuan + " sürpriz puan eklendi.";
                    toplamSurprizPuan = 0;
                }
                else
                {
                    label5.Text = "Puan: " + score;
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            if (isGameOver) return;

            Button clickedButton = sender as Button;

            if (clickedButton?.Tag is Point coordinates)
            {
                int row = coordinates.X;
                int col = coordinates.Y;

                if (isFirstClick)
                {
                    PlaceMines(coordinates);
                    CalculateNumbers();
                    isFirstClick = false;
                }

                if (e.Button == MouseButtons.Left)
                {
                    OpenCell(row, col);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ToggleFlag(clickedButton, coordinates);
                }

                if (CheckWin())
                {
                    GameOver(true);
                }
            }
        }

        private void ToggleFlag(Button clickedButton, Point coordinates)
        {
            int tahmini_mayin_sayisi = Int16.Parse(label1.Text);

            if (field[coordinates.X, coordinates.Y] == -1)
            {
                if (clickedButton.Text != "🚩")
                {
                    if (tahmini_mayin_sayisi != 0)
                    {
                        clickedButton.Text = "🚩";
                        dogruKoyulanBayrakSayisi++;
                        label1.Text = (tahmini_mayin_sayisi - 1).ToString();
                        jokerHakkı_kontrol();
                    }
                }
                else
                {
                    clickedButton.Text = "";
                    dogruKoyulanBayrakSayisi--;
                    label1.Text = (tahmini_mayin_sayisi + 1).ToString();
                }
            }
            else
            {

                if (clickedButton.Text != "🚩")
                {
                    if (tahmini_mayin_sayisi != 0)
                    {
                        clickedButton.Text = "🚩";
                        label1.Text = (tahmini_mayin_sayisi - 1).ToString();
                    }
                }
                else
                {
                    clickedButton.Text = "";
                    label1.Text = (tahmini_mayin_sayisi + 1).ToString();
                }
            }
        }


        public void GameOver(bool won)
        {
            isGameOver = true;
            timer1.Stop();

            foreach (var button in buttons)
            {
                if (button.Tag is Point coordinates && field[coordinates.X, coordinates.Y] == -1)
                {
                    button.ForeColor = Color.FromArgb(60,60,60);
                    button.BackColor = Color.Crimson;
                    button.Text = "💣";
                }
            }

            if (won)
            {
                double toplam_puan;
                if (Properties.Settings.Default.oyun_modu == '0')
                {
                    toplam_puan = (score + 200) - (double.Parse(label2.Text) * 0.1);
                    puan_kayit.puan_kaydet(toplam_puan);
                    MessageBox.Show("Tebrikler! Mayınları buldun, oyun bitti ama zaferin yeni başlıyor!\n\nPuan: " + toplam_puan + "\nHam puan: " + score + " || Tamamlama ödülü: 200 || Süre cezası: " + (Int16.Parse(label2.Text) * 0.1), "Zafer Senin!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (Properties.Settings.Default.oyun_modu == '1')
                {
                    toplam_puan = score + 400 - (double.Parse(label2.Text) * 0.1);
                    puan_kayit.puan_kaydet(toplam_puan);
                    MessageBox.Show("Tebrikler! Mayınları buldun, oyun bitti ama zaferin yeni başlıyor!\n\nPuan: " + toplam_puan + "\nHam puan: " + score + " || Tamamlama ödülü: 400 || Süre cezası: " + (Int16.Parse(label2.Text) * 0.1), "Zafer Senin!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Properties.Settings.Default.oyun_modu == '2')
                {
                    toplam_puan = score + 800 - (double.Parse(label2.Text) * 0.1);
                    puan_kayit.puan_kaydet(toplam_puan);
                    MessageBox.Show("Tebrikler! Mayınları buldun, oyun bitti ama zaferin yeni başlıyor!\n\nPuan: " + toplam_puan + "\nHam puan: " + score + " || Tamamlama ödülü: 800 || Süre cezası: " + (Int16.Parse(label2.Text) * 0.1), "Zafer Senin!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Properties.Settings.Default.oyun_modu == '3')
                {
                    MessageBox.Show("Tebrikler! Mayınları buldun, oyun bitti ama zaferin yeni başlıyor!\n\nPuan: " + score + " (Özel ayarlarda skorlar liderlik tablosuna kaydedilmez.)", "Zafer Senin!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (dogruKoyulanBayrakSayisi >= mineCount / 5)
                {
                    double toplam_puan;
                    toplam_puan = score  - (double.Parse(label2.Text) * 0.1);
                    if (toplam_puan > 0)
                    {
                        puan_kayit.puan_kaydet(toplam_puan);
                        MessageBox.Show("Herkes kaybeder, ama sen biraz daha sesli kaybettin! Bir sonraki sefere daha dikkatli ol!\n\n" + "Puan: " + toplam_puan + "\nHam Puan: " + score + " || Süre cezası: " + (Int16.Parse(label2.Text) * 0.1), "Oooo, Patladın!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        puan_kayit.puan_kaydet(score);
                        MessageBox.Show("Herkes kaybeder, ama sen biraz daha sesli kaybettin! Bir sonraki sefere daha dikkatli ol!\n\n" + "Puan: " + score, "Oooo, Patladın!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                else
                {
                    MessageBox.Show("Herkes kaybeder, ama sen biraz daha sesli kaybettin! Bir sonraki sefere daha dikkatli ol!\n\n" + "Puan: 0 (%20 Mayın doğruluğu şartı karşılanamadı.)", "Oooo, Patladın!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Form frm3 = new Form3();
            frm3.Show();
            this.Close();
        }

        private bool CheckWin()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] != -1 && buttons[row, col].Enabled)
                        return false;
                }
            }
            return true;
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

        private void Form4_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this, 40);
            MakeControlRounded(panel2, 40);
            MakeControlRounded(panel4, 40);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
            this.Close();
        }
        private int sayi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            label2.Text = $"{elapsedTime}";
            label2.Left = panel3.Width - label2.Width;
            label1.Left = panel3.Left;
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            Form frm7 = new Form7();
            frm7.Show();
            this.Close();
        }


        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.oyun_modu == '0')
            {
                if (kullanilan_joker == 0)
                {
                    x2_bonus = true;
                    bonus_kontrol.Start();
                }
                else if (kullanilan_joker == 1)
                {
                    zamani_geri_al();
                }
            }
            else if (Properties.Settings.Default.oyun_modu == '1')
            {
                if (kullanilan_joker == 0)
                {
                    mayınları_göster();
                }
                else if (kullanilan_joker == 1)
                {
                    zamani_geri_al();
                }
                else if (kullanilan_joker == 2)
                {
                    puanları_yerleştir();
                    surpriz_puan = true;
                }
            }
            else if (Properties.Settings.Default.oyun_modu == '2')
            {
                if (kullanilan_joker == 0)
                {
                    puanları_yerleştir();
                    surpriz_puan = true;
                }
                else if (kullanilan_joker == 1)
                {
                    zamani_geri_al();
                }
                else if (kullanilan_joker == 2)
                {
                    mayınları_göster();
                }
                else if (kullanilan_joker == 3)
                {
                    x2_bonus = true;
                    bonus_kontrol.Start();
                }
                else if (kullanilan_joker == 4)
                {
                    kalkan = true;
                }
            }
            kullanilan_joker++;
            jokerHakkı_kontrol();
        }
        private bool kalkan = false;
        private int korunan_mayın_Sayisi;
        private void zamani_geri_al()
        {
            timer1.Stop();
            elapsedTime = elapsedTime - (elapsedTime / 2);
            timer1.Start();
        }

        private List<Point> revealedMines = new List<Point>();
        private void mayınları_göster()
        {

            List<Point> allMines = new List<Point>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == -1 && buttons[row, col].Text != "🚩" && buttons[row, col].BackColor != Color.Green)
                    {
                        allMines.Add(new Point(row, col));
                    }
                }
            }


            if (allMines.Count <= 3)
            {
                revealedMines = allMines;
            }
            else
            {

                Random random = new Random();
                while (revealedMines.Count < 3)
                {
                    Point randomMine = allMines[random.Next(allMines.Count)];
                    if (!revealedMines.Contains(randomMine))
                    {
                        revealedMines.Add(randomMine);
                    }
                }
            }


            foreach (var mine in revealedMines)
            {
                buttons[mine.X, mine.Y].Text = "☢";
                buttons[mine.X, mine.Y].BackColor = Color.Green;
                buttons[mine.X, mine.Y].Enabled = false;
            }

            mayın_goster_kontrol.Start();
        }

        private bool surpriz_puan = false;
        private HashSet<Point> puanlı_hucreler = new HashSet<Point>();
        private void puanları_yerleştir()
        {
            Random random = new Random();
            int bonusCount = rows * cols / 10;
            int placedBonuses = 0;

            while (placedBonuses < bonusCount)
            {
                int row = random.Next(rows);
                int col = random.Next(cols);
                Point point = new Point(row, col);

                if (field[row, col] != -1 && !puanlı_hucreler.Contains(point))
                {
                    puanlı_hucreler.Add(point);
                    placedBonuses++;
                }
            }
        }

        private void mayın_goster_kontrol_Tick(object sender, EventArgs e)
        {
            mayın_goster_kontrol.Stop();

            foreach (var mine in revealedMines)
            {
                buttons[mine.X, mine.Y].Text = "";
                buttons[mine.X, mine.Y].BackColor = Color.FromArgb(34, 34, 34);
                buttons[mine.X, mine.Y].Enabled = true;
            }

            revealedMines.Clear();
        }

        private void bonus_kontrol_Tick(object sender, EventArgs e)
        {
            x2_bonus = false;
            bonus_kontrol.Stop();
        }



        private void formu_ortala()
        {
            var ekranBoyutu = Screen.PrimaryScreen.WorkingArea;
            int yeniX = (ekranBoyutu.Width - this.Width) / 2;
            int yeniY = (ekranBoyutu.Height - this.Height) / 2;
            this.Location = new Point(yeniX, yeniY);
        }


        #region
        private void panel4_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender,e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }
        #endregion
    }
}