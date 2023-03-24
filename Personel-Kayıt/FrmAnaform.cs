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
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-LK988TL\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            textid.Text = "";
            textad.Text = "";
            textmeslek.Text = "";
            textsoyad.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked= false;
            radioButton2.Checked= false;
            textad.Focus();
        }
        void radiobuton()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        
        
        {

           
        }

        private void btnliste_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);

            komut.Parameters.AddWithValue("@p1", textad.Text);
            komut.Parameters.AddWithValue("@p2",textsoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", textmeslek.Text);
            if (radioButton1.Checked == true)
            {
                label8.Text = 1.ToString();

            }
            if (radioButton2.Checked == true)
            {
                label8.Text = 0.ToString();
            }
            komut.Parameters.AddWithValue("@p6", label8.Text);



            komut.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if (label8.Text=="False")
            {
                radioButton2.Checked = true;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",textid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncel = new SqlCommand("Update Tbl_Personel Set PerAd=@g1,PerSoyad=@g2,PerSehir=@g3,PerMaas=@g4,PerDurum=@g5,PerMeslek=@g6 where Perid=@g7", baglanti);
            komutguncel.Parameters.AddWithValue("@g1", textad.Text);
            komutguncel.Parameters.AddWithValue("@g2", textsoyad.Text);
            komutguncel.Parameters.AddWithValue("@g3", comboBox1.Text);
            komutguncel.Parameters.AddWithValue("@g4", maskedTextBox1.Text);
            komutguncel.Parameters.AddWithValue("@g5", label8.Text);
            komutguncel.Parameters.AddWithValue("@g6", textmeslek.Text);
            komutguncel.Parameters.AddWithValue("@g7", textid.Text);
            

            komutguncel.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr=new Frmistatistik();
            fr.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)

            {
                label8.Text = "true";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)

            {
                label8.Text = "false";
            }
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRaporr fr=new FrmRaporr();
            fr.Show();
        }
    }
}
