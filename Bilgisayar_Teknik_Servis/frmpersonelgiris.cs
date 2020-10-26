using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgisayar_Teknik_Servis
{
    public partial class frmpersonelgiris : Form
    {
        public frmpersonelgiris()
        {
            InitializeComponent();
        }
        public static string  gonderilecekpersoneladsoyad;
            

        private void btgiris_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtkullancı.Text;
            string sifre = txtsifre.Text;
            kullanicigiris islemim = new kullanicigiris();
            islemim.girisyap(kullaniciadi,sifre,this);
            //formtamir giris1 = new formtamir();
            //giris1.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void frmpersonelgiris_Load(object sender, EventArgs e)
        {

        }
    }
}
