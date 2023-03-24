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



namespace Personel_Kayıt
{
    public partial class FrmGris : Form
    {
        public FrmGris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LK988TL\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@w1 and Sifre=@w2", baglanti);
            komut.Parameters.AddWithValue("@w1", textBox1.Text);
            komut.Parameters.AddWithValue("@w2", textBox2.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                
                FrmAnaform fr=new FrmAnaform();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş yaptınız");

            }
            baglanti.Close();
        }
    }
}
