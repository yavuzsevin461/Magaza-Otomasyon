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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            con.Open();
            if (textBox1.Text.Trim() == "")

            {
                MessageBox.Show("Giriş Başarısız! Eksiksiz Giriniz!", " HATA !!!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                string Calisanlar = "SELECT * FROM Calisan WHERE TC=@tc ";
                SqlParameter prms = new SqlParameter("@tc", textBox1.Text);
                SqlCommand cmd = new SqlCommand(Calisanlar, con);
                cmd.Parameters.Add(prms);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string kisitc = textBox1.Text;
                    SqlCommand cmmd = new SqlCommand("Select DEPARTMAN from Calisan Where Tc=@tc", con);
                    cmmd.Parameters.AddWithValue("@tc", kisitc);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    SqlDataReader drr = cmd.ExecuteReader();
                    if (drr.Read())
                    {

                        label1.Text = drr["DEPARTMAN"].ToString();
                    }
                    if (label1.Text == "YÖNETİCİ")
                    {
                        MessageBox.Show(textBox1.Text + " KİMLİK NOLU " + label1.Text + " ÇALIŞANIMIZ HOŞGELDİNİZ :) ");
                        AcilisFormu AcilisFormuAc = new AcilisFormu();
                        AcilisFormuAc.Show();
                        AcilisFormuAc.comboBox1.Visible = true;
                        AcilisFormuAc.comboBox3.Visible = true;
                        AcilisFormuAc.comboBox4.Visible = true;
                        AcilisFormuAc.comboBox5.Visible = true;
                        AcilisFormuAc.button1.Visible = true;
                        AcilisFormuAc.button2.Visible = true;
                        AcilisFormuAc.button3.Visible = true;
                        AcilisFormuAc.button5.Visible = true;
                        this.Hide();
                    }
                    else if (label1.Text == "KASİYER")
                    {
                        MessageBox.Show(textBox1.Text + " KİMLİK NOLU " + label1.Text + " ÇALIŞANIMIZ HOŞGELDİNİZ :) ");
                        AcilisFormu AcilisFormuAc = new AcilisFormu();
                        AcilisFormuAc.Show();
                        AcilisFormuAc.comboBox1.Visible = true;
                        AcilisFormuAc.comboBox3.Visible = false;
                        AcilisFormuAc.comboBox4.Visible = true;
                        AcilisFormuAc.comboBox5.Visible = false;
                        AcilisFormuAc.button1.Visible = true;
                        AcilisFormuAc.button2.Visible = false;
                        AcilisFormuAc.button3.Visible = false;
                        AcilisFormuAc.button5.Visible = true;
                        this.Hide();
                    }
                    else if (label1.Text == "DEPO GÖREVLİSİ")
                    {
                        MessageBox.Show(textBox1.Text + " KİMLİK NOLU " + label1.Text + " ÇALIŞANIMIZ HOŞGELDİNİZ :) ");
                        AcilisFormu AcilisFormuAc = new AcilisFormu();
                        AcilisFormuAc.Show();
                        AcilisFormuAc.comboBox1.Visible = false;
                        AcilisFormuAc.comboBox3.Visible = false;
                        AcilisFormuAc.comboBox4.Visible = false;
                        AcilisFormuAc.comboBox5.Visible = true;
                        AcilisFormuAc.button1.Visible = false;
                        AcilisFormuAc.button2.Visible = true;
                        AcilisFormuAc.button3.Visible = false;
                        AcilisFormuAc.button5.Visible = false;

                        this.Hide();
                    }
                }

                else
                {
                    MessageBox.Show("BÖYLE BİR ÇALIŞAN BULUNMAMAKTADIR!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}
