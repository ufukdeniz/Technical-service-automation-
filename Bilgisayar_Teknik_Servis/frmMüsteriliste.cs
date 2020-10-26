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
    public partial class frmMüsteriliste : Form
    {
        public frmMüsteriliste()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void frmMüsteriliste_Load(object sender, EventArgs e)
        {
            Kayıt_Goster();

        }

        private void Kayıt_Goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from musteri", baglanti);
            adtr.Fill(daset, "musteri");
            dataGridView1.DataSource = daset.Tables["musteri"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtMüsteriID.Text = dataGridView1.CurrentRow.Cells["musteriID"].Value.ToString();
            TxtAdi.Text = dataGridView1.CurrentRow.Cells["adi"].Value.ToString();
            TxtSoyadi.Text = dataGridView1.CurrentRow.Cells["soyadi"].Value.ToString();
            TxtTelefonNo.Text = dataGridView1.CurrentRow.Cells["telefonno"].Value.ToString();
            TxtEposta.Text = dataGridView1.CurrentRow.Cells["eposta"].Value.ToString();
            TxtMahalle.Text = dataGridView1.CurrentRow.Cells["mahalle"].Value.ToString();
            Txtİlce.Text = dataGridView1.CurrentRow.Cells["ilce"].Value.ToString();
            TxtSehir.Text = dataGridView1.CurrentRow.Cells["sehir"].Value.ToString();
            TxtUrunNo.Text = dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteri set adi=@adi,soyadi=@soyadi,telefonno=@telefonno,eposta=@eposta,mahalle=@mahalle,ilce=@ilce,sehir=@sehir where musteriID=@musteriID",baglanti);
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
            daset.Tables["musteri"].Clear();
            Kayıt_Goster();
            MessageBox.Show("Müşteri Kaydı Güncellendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from musteri where musteriID='"+dataGridView1.CurrentRow.Cells["musteriID"].Value.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["musteri"].Clear();
            Kayıt_Goster();
            MessageBox.Show("Kayıt Silindi");

        }

        private void txtMusteriAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from musteri where musteriID like '%"+txtMusteriAra.Text+"%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

       
        }
    }
}
