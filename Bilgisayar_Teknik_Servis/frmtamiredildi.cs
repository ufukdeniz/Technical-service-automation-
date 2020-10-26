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
    public partial class frmtamiredildi : Form
    {
        public frmtamiredildi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void tamiredildi()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from urunislem", baglanti);
            adtr.Fill(daset, "urunislem");
            dataGridView2.DataSource = daset.Tables["urunislem"];
            dataGridView2.Columns[0].Visible = true;
            dataGridView2.Columns[1].Visible = true;
            //dataGridView1.Columns[2].Visible = true;

            baglanti.Close();

        }
        private void frmtamiredildi_Load(object sender, EventArgs e)
        {
            tamiredildi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from urunislem ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıtlar Silindi");
            daset.Tables["urunislem"].Clear();
            tamiredildi();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from urunislem where urunNo like '%" + textBox1.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
    }
}
