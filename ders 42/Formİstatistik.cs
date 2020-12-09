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
    public partial class Formİstatistik : Form
    {
        public Formİstatistik()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-L3TE5819\\KADER;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Formİstatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select count (*) from tablo_1 ", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label2.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select count (*) from tablo_1 where perdurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label4.Text = dr2[0].ToString();
            }

             baglanti.Close();

             //bekar personel sayısı
             baglanti.Open();

             SqlCommand komut3 = new SqlCommand("select count (*) from tablo_1 where perdurum=0", baglanti);
             SqlDataReader dr3 = komut3.ExecuteReader();
             while (dr3.Read())
             {
                 label6.Text = dr3[0].ToString();
             }

             baglanti.Close();

            //şehir sayısı
             baglanti.Open();

             SqlCommand komut4= new SqlCommand("select count (distinc(PerSehir)) from tablo_1", baglanti);
             SqlDataReader dr4 = komut4.ExecuteReader();
             while (dr4.Read())
             {
                 label8.Text = dr4[0].ToString();
             }

             baglanti.Close();

            //toplam maaş
             baglanti.Open();

             SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from tablo_1", baglanti);
             SqlDataReader dr5 = komut5.ExecuteReader();
             while (dr5.Read())
             {
                 label10.Text = dr5[0].ToString();
             }

             baglanti.Close();

            //ortalama maaş
             baglanti.Open();

             SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from tablo_1 ", baglanti);
             SqlDataReader dr6 = komut6.ExecuteReader();
             while (dr6.Read())
             {
                 label12.Text = dr6[0].ToString();
             }

             baglanti.Close();

        }

    }
}
