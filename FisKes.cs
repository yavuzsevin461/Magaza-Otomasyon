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
    public partial class FisKes : Form
    {
        public FisKes()
        {
            InitializeComponent();
        }

        private void FisKes_Load(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand(string.Format("SELECT [ÜRÜN ADI],[SATIŞ FİYATI] from Depo where [ÜRÜN KODU] like '%{0}%'", textBox1.Text), con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            string urunAdi;
            double satisFiyati;
            while (dr.Read())
            {
                urunAdi = dr.GetString(0);
                satisFiyati =dr.GetDouble(1);
                ListViewItem listeleme = new ListViewItem();
                listeleme.Text = urunAdi;   
                listeleme.SubItems.Add(satisFiyati.ToString()); 
                listView1.Items.Add(listeleme);
            }
            textBox1.Text = "";
            textBox1.Focus();
            dr.Close();
            con.Close();
            textBox1.Text = "";
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Soru = MessageBox.Show("İŞLEMİ İPTAL ETMEK İSTİYOR MUSUNUZ", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Soru == DialogResult.Yes)
            {
                MessageBox.Show(" SATIŞ İPTAL EDİLİYOR ... ");
                DataTable dt = new DataTable();
                dt.Clear();
                listView1.Clear();
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Soru = MessageBox.Show("YENİ İŞLEM AÇILSIN MI?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Soru == DialogResult.Yes)
            {
                MessageBox.Show(" YENİ İŞLEM AÇILIYOR... ");
                DataTable dt = new DataTable();
                dt.Clear();
                listView1.Clear();
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            double[] topla = new double[listView1.Items.Count]; 
            
            for (int i = 0; i < listView1.Items.Count; i++) 
            {
                topla[i] = Convert.ToDouble(listView1.Items[i].SubItems[1].Text.ToString());
                toplam = toplam + topla[i];
                
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string azaltma = "update Depo set ADET=ADET-1 where [ÜRÜN ADI]=@ua";
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(azaltma, con);
                cmd.Parameters.AddWithValue("@ua",listView1.Items[i].SubItems[0].Text);
                try
                { 
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                }
                finally
                {
                    con.Close();
                }
            }


            textBox4.Text = Convert.ToString(toplam);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (textBox1.Text.Trim() != "")
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
                SqlDataAdapter dgvbilgi = new SqlDataAdapter("SELECT * FROM Depo",con);
                con.Open();
                dgvbilgi.Fill(dt);
                dataGridView1.DataSource = dt;
                DataView dv = new DataView(dt);
                dv.RowFilter = "[ÜRÜN KODU] LIKE '" + textBox1.Text + "%' ";
                dataGridView1.DataSource = dv;
                con.Close();

            }
            else
            {
                dt.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float AlinanPara = 0;
            float ToplamTutar = 0;
            if (textBox2.Text != string.Empty)
            {
                AlinanPara = float.Parse(textBox2.Text);
            }
            if (textBox4.Text != string.Empty)
            {
                ToplamTutar = float.Parse(textBox4.Text);
            }
            textBox3.Text = string.Format("{0:C}", AlinanPara - ToplamTutar);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
