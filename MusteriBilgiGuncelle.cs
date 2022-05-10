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
    public partial class MusteriBilgiGuncelle : Form
    {
        public MusteriBilgiGuncelle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void MusteriBilgiGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string guncelle = "update MUSTERİ set TC=@tc,AD=@ad,SOYAD=@soyad,[TELEFON NUMARASI]=@telno,[DOĞUM TARİHİ]=@dgmtrh where TC=@tc";
            SqlCommand cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@dgmtrh", textBox5.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@tc", textBox4.Text);
            cmd.Parameters.AddWithValue("@telno", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("MÜŞTERİ BİLGİLERİ GÜNCELLENDİ");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string getir = "SELECT * from MUSTERİ where TC=@tc";
            SqlCommand cmd = new SqlCommand(getir, con);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox4.Text = dr["TC"].ToString();
                textBox2.Text = dr["AD"].ToString();
                textBox3.Text = dr["SOYAD"].ToString();
                textBox6.Text = dr["TELEFON NUMARASI"].ToString();
                textBox5.Text = dr["DOĞUM TARİHİ"].ToString();
            }
            else
                MessageBox.Show("Müşteri Bulunamadı!!!");
            con.Close();
        }
    }
}
