using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
     static class puan_kayit
    {
        public static void puan_kaydet(double puan)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO oyunkayitlari (kullanici_id, oyun_modu, puan) " +
                                   "VALUES (@KullaniciID, @OyunModu, @Puan)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciID", Properties.Settings.Default.id);
                    cmd.Parameters.AddWithValue("@OyunModu", Properties.Settings.Default.oyun_modu);
                    cmd.Parameters.AddWithValue("@Puan", puan);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
