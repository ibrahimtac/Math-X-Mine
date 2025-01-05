using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp15
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            MakeControlRounded(this, 40);
            MakeControlRounded(listBox1, 30);
            MakeControlRounded(listBox2, 30);
            MakeControlRounded(listBox3, 30);
            verileri_getir();
        }

        private void verileri_getir()
        {
            string query = @"
                SELECT 
                    k.kullanici_adi, 
                    o.oyun_modu, 
                    SUM(o.puan) AS toplam_puan
                FROM 
                    OyunKayitlari o
                JOIN 
                    Kullanıcılar k ON o.kullanici_id = k.id
                GROUP BY 
                    k.kullanici_adi, o.oyun_modu
                ORDER BY 
                    o.oyun_modu, toplam_puan DESC;";

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string user = row["kullanici_adi"].ToString();
                        string gameMode = row["oyun_modu"].ToString();
                        string totalPoints = row["toplam_puan"].ToString();

                        string displayText = $"⭐ {user} -> {totalPoints} Puan";

                        if (gameMode == "0") listBox1.Items.Add(displayText);
                        else if (gameMode == "1") listBox2.Items.Add(displayText);
                        else if (gameMode == "2") listBox3.Items.Add(displayText);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
