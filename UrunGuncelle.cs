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
    public partial class UrunGuncelle : Form
    {
        public UrunGuncelle()
        {
            InitializeComponent();
        }

        private void UrünGüncelle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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

                textBox2.Text = dr["ÜRÜN ADI"].ToString();
                textBox3.Text = dr["ALIŞ FİYATI"].ToString();
                textBox4.Text = dr["SATIŞ FİYATI"].ToString();
                textBox5.Text = dr["ÜRÜN KODU"].ToString();
                textBox7.Text = dr["ADET"].ToString();
                comboBox1.Text = dr["KATEGORİ"].ToString();
            }
            else
                MessageBox.Show("ÜRÜN BULUNAMADI!");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            string guncelle = "update Depo set [ÜRÜN KODU]=@uk,[ÜRÜN ADI]=@ua,[ALIŞ FİYATI]=@af,[SATIŞ FİYATI]=@sf,ADET=@adet,KATEGORİ=@ktgr where [ÜRÜN KODU]=@uk";
            SqlCommand cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@uk", textBox5.Text);
            cmd.Parameters.AddWithValue("@ua", textBox2.Text);
            cmd.Parameters.AddWithValue("@af", textBox3.Text);
            cmd.Parameters.AddWithValue("@sf", textBox4.Text);
            cmd.Parameters.AddWithValue("@adet", textBox7.Text);
            cmd.Parameters.AddWithValue("@ktgr", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
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
