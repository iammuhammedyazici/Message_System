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


namespace MesajSistemi
{
    public partial class FrmMesaj : Form
    {
        public FrmMesaj()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From TBL_MESAJLAR WHERE ALICI=" + numara, bgl.baglanti());
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;
        }
        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From TBL_MESAJLAR WHERE GONDEREN=" + numara, bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        public string numara;
        private void FrmMesaj_Load(object sender, EventArgs e)
        {
            gelenkutusu();
            gidenkutusu();
            lblnumara.Text = numara;
            SqlCommand komut = new SqlCommand("Select AD, SOYAD FROM TBL_KISILER WHERE NUMARA=" + numara, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_MESAJLAR (GONDEREN ,ALICI, BASLIK, ICERIK) " +
                "VALUES (@P1, @P2, @P3, @P4) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", mskno.Text);
            komut.Parameters.AddWithValue("@p3", txtbaslik.Text);
            komut.Parameters.AddWithValue("@p4", rchmesaj.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Mesaj Gönderildi...");
            gidenkutusu();
            gelenkutusu();

        }
    }
}
