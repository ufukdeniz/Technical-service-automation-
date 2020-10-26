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
    public partial class frmmarka : Form
    {
        public frmmarka()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        bool durum;
        private void markaengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from Marka ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox2.Text == read["urunmarka"].ToString() || textBox2.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            markaengelle();
            if (durum==true)
            {
                baglanti.Open();


                SqlCommand komut = new SqlCommand("insert into Marka(kategori,urunmarka) values(@kategori,'" + textBox2.Text + "') ", baglanti);
                komut.Parameters.AddWithValue("@kategori", comboBox1.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                
                MessageBox.Show("Marka Eklendi");
            }
            else
            {
                MessageBox.Show("Bu Marka Zaten Var");
            }
            textBox2.Text = "";
            comboBox1.Text = "";

        }

        private void frmmarka_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from Kategori ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategorigetir();
        }
    }
}
