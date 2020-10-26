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
    public partial class frmurunliste : Form
    {
        public frmurunliste()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void frmurunliste_Load(object sender, EventArgs e)
        {
            urungetir();

        }

        private void urungetir()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from urunler", baglanti);
            adtr.Fill(daset, "urunler");
            dataGridView1.DataSource = daset.Tables["urunler"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunNotxt.Text = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
            Kategoritext.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            urunMarkatext.Text = dataGridView1.CurrentRow.Cells["urunMarka"].Value.ToString();
            UrunModeltxt.Text = dataGridView1.CurrentRow.Cells["urunModel"].Value.ToString();
            SeriNotxt.Text = dataGridView1.CurrentRow.Cells["seriNo"].Value.ToString();
            UrunSorunutxt.Text = dataGridView1.CurrentRow.Cells["urunAriza"].Value.ToString();
            TamirFiyatıtxt.Text = dataGridView1.CurrentRow.Cells["tamirfiyatı"].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urunler set kategori=@kategori,urunMarka=@urunMarka,urunModel=@urunModel,seriNo=@seriNo,urunAriza=@urunAriza,tamirfiyatı=@tamirfiyatı where urunNo=@urunNo",baglanti);
            komut.Parameters.AddWithValue("@urunNo", UrunNotxt.Text);
            komut.Parameters.AddWithValue("@kategori", Kategoritext.Text);
            komut.Parameters.AddWithValue("@urunMarka", urunMarkatext.Text);
            komut.Parameters.AddWithValue("@urunModel", UrunModeltxt.Text);
            komut.Parameters.AddWithValue("@seriNo", SeriNotxt.Text);
            komut.Parameters.AddWithValue("@urunAriza", UrunSorunutxt.Text);
            komut.Parameters.AddWithValue("@tamirfiyatı", TamirFiyatıtxt.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urunler"].Clear();
            urungetir();
            MessageBox.Show("Güncelleme Yapıldı");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from urunler where urunNo='" + dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urunler"].Clear();
            urungetir();
            MessageBox.Show("Kayıt Silindi");
        }

        private void txturunnoara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from urunler where urunNo like '%" + txturunnoara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
    