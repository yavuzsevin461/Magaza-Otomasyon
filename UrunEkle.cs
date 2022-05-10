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
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=true");
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string kayit = "insert into Depo([ÜRÜN ADI],[ÜRÜN KODU],[ALIŞ FİYATI],ADET,[SATIŞ FİYATI],KATEGORİ) values (@ua,@uk,@af,@adt,@sf,@ktgr)";
                    SqlCommand cmd = new SqlCommand(kayit, con);
                    cmd.Parameters.AddWithValue("@ua", textBox1.Text);
                    cmd.Parameters.AddWithValue("@uk", textBox2.Text);
                    cmd.Parameters.AddWithValue("@af", textBox3.Text);
                    cmd.Parameters.AddWithValue("@adt", textBox5.Text);
                    cmd.Parameters.AddWithValue("@sf", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ktgr", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Kaydedildi");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("HATA OLUŞTU!" + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("BÜTÜN ALANLARI DOLDURMAK ZORUNLUDUR!");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Text = "KATEGORİ SEÇİNİZ";
            comboBox1.Items.Add("TABLET");
            comboBox1.Items.Add("TELEFON");
            comboBox1.Items.Add("BİLGİSAYAR");
            comboBox1.Items.Add("DRONE");
            comboBox1.Items.Add("KULAKLIK");
            comboBox1.Items.Add("GİYİLEBİLİR TEKNOLOJİ");
            comboBox1.Items.Add("PC PARÇALARI");
        }
    }
}
