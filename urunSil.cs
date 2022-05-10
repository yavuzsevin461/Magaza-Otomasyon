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

namespace magaza
{
    public partial class urunSil : Form
    {
        public urunSil()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string getir = "SELECT * from Depo where [ÜRÜN KODU]=@uk";
            SqlCommand cmd = new SqlCommand(getir, con);
            cmd.Parameters.AddWithValue("@uk", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                string isim = dr["ÜRÜN ADI"].ToString();
                dr.Close();
                DialogResult durum = MessageBox.Show(" ÜRÜNÜ SİLMEK İSTİYOR MUSUNUZ?", "SİL", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    string sil = "DELETE from Depo where [ÜRÜN KODU]=@uk";
                    SqlCommand cmdsil = new SqlCommand(sil, con);
                    cmdsil.Parameters.AddWithValue("@uk", textBox1.Text);
                    cmdsil.ExecuteNonQuery();
                    MessageBox.Show("ÜRÜN SİLME BAŞARILI!");
                }
            }
            else
                MessageBox.Show("HATA!");
            con.Close();
            textBox1.Text = "";
        }
    }
}
