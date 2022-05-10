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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AcilisFormu AcilisFormuAc = new AcilisFormu();
            AcilisFormuAc.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd = new SqlCommand("Select*from Depo order by [ÜRÜN KODU]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secmeSorgusu = "SELECT*FROM Depo where [ÜRÜN KODU]=@uk";
            string uk = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=teknologic;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(secmeSorgusu, con);
            cmd.Parameters.AddWithValue("@uk", uk);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
