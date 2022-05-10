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
    public partial class CalisanBilgiGüncelle : Form
    {
        public CalisanBilgiGüncelle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void CalisanBilgiGüncelle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string getir = "SELECT * from Calisan where TC=@tc";
            SqlCommand cmd = new SqlCommand(getir, con);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox5.Text = dr["TC"].ToString();
                textBox2.Text = dr["AD"].ToString();
                textBox3.Text = dr["SOYAD"].ToString();
                textBox4.Text = dr["TELEFON NUMARASI"].ToString();
                textBox6.Text = dr["DOĞUM TARİHİ"].ToString();
                textBox8.Text = dr["ADRES"].ToString();
                comboBox1.Text = dr["DEPARTMAN"].ToString();
                comboBox1.Items.Add("YÖNETİCİ");
                comboBox1.Items.Add("KASİYER");
                comboBox1.Items.Add("DEPO GÖREVLİSİ");
            }
            else
                MessageBox.Show("Çalışan Bulunamadı!!!");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string guncelle = "update Calisan set AD=@ad, SOYAD=@soyad, TC=@tc, [TELEFON NUMARASI]=@telefon, [DOĞUM TARİHİ]=@dgmtrh, ADRES=@adres, DEPARTMAN=@departman where TC=@tc";
            SqlCommand cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@tc", textBox5.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefon", textBox4.Text);
            cmd.Parameters.AddWithValue("@dgmtrh", textBox6.Text);
            cmd.Parameters.AddWithValue("@adres", textBox8.Text);
            cmd.Parameters.AddWithValue("@departman", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Çalısan Bilgileri Güncellendi");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox1.Items.Add("YÖNETİCİ");
            comboBox1.Items.Add("KASİYER");
            comboBox1.Items.Add("DEPO GÖREVLİSİ");
        }
    }
}
