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
    public partial class formtamir : Form
    {
        
        public formtamir()
        {
            InitializeComponent();
        }
        string secilenID = "-1";

        SqlConnection baglanti = new SqlConnection("Data Source=UFUKDENIZHP\\SQLEXPRESS;Initial Catalog=BilgisayarTeknikServis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void islemlistele()
        {
            baglanti.Open();

            SqlDataAdapter adtr = new SqlDataAdapter("select *from urunislem", baglanti);
            adtr.Fill(daset, "urunislem");
            dataGridView1.DataSource = daset.Tables["urunislem"];
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;

            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ürünislem_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmmüsteriekle ekle = new frmmüsteriekle();
            ekle.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmMüsteriliste listele = new frmMüsteriliste();
            listele.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmurunekle2 ekle = new frmurunekle2();
            ekle.ShowDialog();
        }







        private void formtamir_Load(object sender, EventArgs e)
        {
            //frmpersonelgiris giris = new frmpersonelgiris();
            //giris.ShowDialog();
            label1.Text = frmpersonelgiris.gonderilecekpersoneladsoyad;
            islemlistele();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmurunliste listele = new frmurunliste();
            listele.ShowDialog();
        }



        private void txturunno_TextChanged(object sender, EventArgs e)
        {
            if (txturunno.Text == "")
            {
                MusteriNotxt.Text = "";
                txttutar.Text = "";
                txttarih.Text = "";

            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" select * from urunler  where urunNo like'" + txturunno.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txturunno.Text = read["urunNo"].ToString();

                // MusteriNotxt.Text = read["musteriID"].ToString();
                txttarih.Text = DateTime.Now.ToString();
                txttutar.Text = read["tamirfiyatı"].ToString();



            }
            //komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            baglanti.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into urunislem(urunNo,cikisTarihi,tutar) values(@urunNo,@cikisTarihi,@tutar)  ", baglanti);
            komut.Parameters.AddWithValue("urunNo", txturunno.Text);
            komut.Parameters.AddWithValue("cikisTarihi", DateTime.Now.ToString());
            komut.Parameters.AddWithValue("tutar", txttutar.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urunislem"].Clear();
            islemlistele();


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from urunislem where urunNo='" + dataGridView1.CurrentRow.Cells["urunNo"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün İptal Edildi");
            daset.Tables["urunislem"].Clear();
            islemlistele();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("delete from urunislem ", baglanti);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //MessageBox.Show("Ürün İptal Edildi");
            //daset.Tables["urunislem"].Clear();
            //islemlistele();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmtamiredildi listele = new frmtamiredildi();
            listele.ShowDialog();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmkategori kategori = new frmkategori();
            kategori.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmmarka marka = new frmmarka();
            marka.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        
    }
}
