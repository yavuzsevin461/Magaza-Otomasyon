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
    public partial class AcilisFormu : Form
    {
        public AcilisFormu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string secilen;
            secilen = comboBox3.Text;
            if (secilen == "Çalışan Ekle")
            {
                Form3 CalisanEkleAc = new Form3();
                CalisanEkleAc.Show();
                this.Hide();
            }
            else if (secilen == "Çalışan Sorgula")
            {
                CalisanGoruntule CalisanBilgiAc = new CalisanGoruntule();
                CalisanBilgiAc.Show();
                this.Hide();
            }
            else if (secilen == "Çalışan Bilgi Güncelle")
            {
                CalisanBilgiGüncelle CalisanBilgiAc = new CalisanBilgiGüncelle();
                CalisanBilgiAc.Show();
                this.Hide();
            }
            else if (secilen == "Çalışan Sil")
            {
                CalisanSil CalisanSilAc = new CalisanSil();
                CalisanSilAc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seçim Yapınız!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secilen;
            secilen = comboBox1.Text;
            if (secilen == "Fiş Kes")
            {
                FisKes FisKesAc = new FisKes();
                FisKesAc.Show();
                this.Hide();
            }
            else if (secilen == "Stok Sorgula")
            {
                Form2  StokSorguAc = new Form2();
                StokSorguAc.Show();
                this.Hide();
            }
            else if (secilen == "İade Al")
            {
                IadeAl iadealAc = new IadeAl();
                iadealAc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seçim Yapınız!");
            }

            
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AcilisFormu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string secilen;
            secilen = comboBox4.Text;
            if (secilen == "Müşteri Ekle")
            {
                MusteriKayit MusteriKayitAc = new MusteriKayit();
                MusteriKayitAc.Show();
                this.Hide();
            }
            else if (secilen == "Müşteri Bilgi Güncelle")
            {
                MusteriBilgiGuncelle MusteriBilgiGuncelleAc = new MusteriBilgiGuncelle();
                MusteriBilgiGuncelleAc.Show();
                this.Hide();
            }
            else if (secilen == "Müşteri Sorgula")
            {
                MusteriGoruntule MusteriBilgiAc = new MusteriGoruntule();
                MusteriBilgiAc.Show();
                this.Hide();
            }
            else if (secilen == "Müşteri Sil")
            {
                MusteriSil MusteriSilAc = new MusteriSil();
                MusteriSilAc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seçim Yapınız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string secilen;
            secilen = comboBox5.Text;
            if (secilen == "Ürün Ekle")
            {
                UrunEkle UrunEkleAc = new UrunEkle();
                UrunEkleAc.Show();
                this.Hide();
            }
            else if (secilen == "Ürün Bilgi Güncelle")
            {
                UrunGuncelle UrunBilgiGuncelleAc = new UrunGuncelle();
                UrunBilgiGuncelleAc.Show();
                this.Hide();
            }
            else if (secilen == "Ürün-Stok Sorgula")
            {
                Form2 UrunSorgulamaAc = new Form2();
                UrunSorgulamaAc.Show();
                this.Hide();
            }
            else if (secilen == "Ürün Sil")
            {
                urunSil UrunSilmeAc = new urunSil();
                UrunSilmeAc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seçim Yapınız!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1Ac = new Form1();
            form1Ac.Show();
            this.Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }
