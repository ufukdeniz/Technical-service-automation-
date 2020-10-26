using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bilgisayar_Teknik_Servis
{
    public partial class frmmüsteriekle : Form
    {
        public frmmüsteriekle()
        {
            InitializeComponent();
        }



        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        bool durum;
        private void urunkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from musteri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtUrunNo.Text == read["urunNo"].ToString() || TxtUrunNo.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmmüsteriekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            urunkontrol();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into musteri(adi,soyadi,telefonno,eposta,mahalle,ilce,sehir,urunNo) values(@adi,@soyadi,@telefonno,@eposta,@mahalle,@ilce,@sehir,@urunNo) ", baglanti);
                komut.Parameters.AddWithValue("@musteriID", TxtMüsteriID.Text);
                komut.Parameters.AddWithValue("@adi", TxtAdi.Text);
                komut.Parameters.AddWithValue("@soyadi", TxtSoyadi.Text);
                komut.Parameters.AddWithValue("@telefonno", TxtTelefonNo.Text);
                komut.Parameters.AddWithValue("@eposta", TxtEposta.Text);
                komut.Parameters.AddWithValue("@mahalle", TxtMahalle.Text);
                komut.Parameters.AddWithValue("@ilce", Txtİlce.Text);
                komut.Parameters.AddWithValue("@sehir", TxtSehir.Text);
                komut.Parameters.AddWithValue("@urunNo", TxtUrunNo.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Müşteri Kaydı Eklendi");
            }
            else
            {
                MessageBox.Show("Bu Ürün No Zaten Var");

            }

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
