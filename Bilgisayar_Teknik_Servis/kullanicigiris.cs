using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bilgisayar_Teknik_Servis
{
    class kullanicigiris
    {
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        public void girisyap(string ad, string sifre, Form frm1)
        {
            SqlCommand komut = new SqlCommand("select * from personel where kullaniciadi='" + ad + "' and sifre='" + sifre + "'", baglanti);
            baglanti.Open();
            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                frmpersonelgiris.gonderilecekpersoneladsoyad = read["personeladsoyad"].ToString();
                formtamir giris1 = new formtamir();
                frm1.Hide();
                giris1.ShowDialog();

                Application.Exit();
            }
            else
            {

                MessageBox.Show("Hatalı Giriş");

            }
            baglanti.Close();
            komut.Dispose();
        }


    }
}
