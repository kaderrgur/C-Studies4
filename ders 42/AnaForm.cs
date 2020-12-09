using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;  //sql komutlarını kullanmak için kullanılması gereken kütüphane

namespace ders_42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-L3TE5819\\KADER;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tablo_1TableAdapter.Fill(this.personelVeriTabaniDataSet.tablo_1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tablo_1 (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", textBox4.Text);
            //komut.Parameters.AddWithValue("@p6", label8.Text);
            if (radioButton1.Checked)
            {
                komut.Parameters.AddWithValue("@p6", '0');
            }
            else if (radioButton2.Checked)
            {
                komut.Parameters.AddWithValue("@p6", '1');
            }
            else
            {
                MessageBox.Show("Lütfen Medeni Durum Seçimi Yapınız.");
                //button2_Click(sender, e);
            }

            komut.ExecuteNonQuery();     //insert sorgusunu çalıştırır. ekle-sil-güncelle de kullanılır


            baglanti.Close();
            MessageBox.Show("Personel Eklendi!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "1";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //herhangi bir hücreye iki defa tıklandığında ne olsun.
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }



        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "1")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "0")
            {
                radioButton2.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("delete from tablo_1 where perid=@k1 ", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kayıt Silindi!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update tablo_1 set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where PerId=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", textBox4.Text);
            komutguncelle.Parameters.AddWithValue("@a7", textBox1.Text);
            komutguncelle.ExecuteNonQuery();
            
           

            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Formİstatistik fr = new Formİstatistik();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormGrafikler frg = new FormGrafikler();  //butona tıklanıldığında grafik formuna yönlendirir
            frg.Show();
        }
    }
}
