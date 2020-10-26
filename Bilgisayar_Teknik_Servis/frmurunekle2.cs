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
    public partial class frmurunekle2 : Form
    {
        public frmurunekle2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        DataSet daset = new DataSet();

        string secilenID = "-1";
        bool durum;
        private void urunkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urunler", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtUrunNo.Text == read["urunNo"].ToString() || txtUrunNo.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void btnYenıUrunEkle_Click(object sender, EventArgs e)
        {
            urunkontrol();
            if (durum==true)
            {
                secilenID = txtUrunNo.Text.ToString();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into urunler(urunNo,kategori,urunMarka,urunModel,seriNo,urunAriza,tamirfiyatı,tarih) values(@urunNo,@kategori,@urunMarka,@urunModel,@seriNo,@urunAriza,@tamirfiyatı,@tarih)  ", baglanti);
                komut.Parameters.AddWithValue("@urunNo", secilenID);

                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@urunMarka", comboMarka.Text);
                komut.Parameters.AddWithValue("@urunModel", txtUrunModel.Text);
                komut.Parameters.AddWithValue("@seriNo", txtSeriNo.Text);
                komut.Parameters.AddWithValue("@urunAriza", txtUrunsorunu.Text);
                komut.Parameters.AddWithValue("@tamirfiyatı", txtTamirFiyati.Text);
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Kaydı Eklendi");
            }
            else
            {
                MessageBox.Show("Bu Ürün No Zaten Var");
            }
            
            comboMarka.Items.Clear();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from Kategori ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
        private void frmurunekle2_Load(object sender, EventArgs e)
        {
           
            kategorigetir();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from musteri ", baglanti);
            adtr.Fill(daset, "musteri");
            dataGridView1.DataSource = daset.Tables["musteri"];
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;


            baglanti.Close();
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from Marka ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboMarka.Items.Add(read["urunmarka"].ToString());
            }
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secilenID = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtUrunNo.Text= dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtUrunNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
