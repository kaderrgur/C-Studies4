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
    public partial class FormGrafikler : Form
    {
        public FormGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-L3TE5819\\KADER;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FormGrafikler_Load(object sender, EventArgs e)
        {
            //grafik1
            baglanti.Open();

            SqlCommand komutg1 = new SqlCommand("select PerSehir, count(*) from tablo_1 group by PerSehir ", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0],dr1[1]);
            }

            baglanti.Close();

            //grafik2
            baglanti.Open();

            SqlCommand komutg2 = new SqlCommand("select PerMeslek, Avg(PerMaas) from tablo_1 group by PerMeslek ", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglanti.Close();

        }
    }
}
