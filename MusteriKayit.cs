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
    public partial class MusteriKayit : Form
    {
        public MusteriKayit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void MusteriKayit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=true");
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" ) 
            {

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string kayit = "insert into MUSTERİ(TC,AD,SOYAD,[TELEFON NUMARASI],[DOĞUM TARİHİ]) values (@tc,@ad,@soyad,@tlfn,@dgmtrh)";
                    SqlCommand cmd = new SqlCommand(kayit, con);
                    cmd.Parameters.AddWithValue("@tc", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
                    cmd.Parameters.AddWithValue("@tlfn", textBox2.Text);
                    cmd.Parameters.AddWithValue("@dgmtrh", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri Kaydedildi");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show("HATA OLUŞTU!" + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("lütfen tüm alanları doldurunuz!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
