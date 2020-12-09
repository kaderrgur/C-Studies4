using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ders_42
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-L3TE5819\\KADER;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tablo_yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();  //üstünde çalıştığım formu gizle
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
            baglanti.Close();

        }
    }
}
