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
    public partial class frmkategori : Form
    {
        public frmkategori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        bool durum;
        private void kategoriengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from Kategori", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text==read["kategori"].ToString()||textBox1.Text=="")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void frmkategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategoriengelle();
                if (durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Kategori(kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Bu Kategori Zaten Var");
            }
            textBox1.Text = "";


        }
    }
}
