using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalpaperAdvicePage
{
    public partial class Form1 : Form
    {
        private List<Image> resimler;
        private Image selectedImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimler = new List<Image>
            {
                Properties.Resources.resim0,
                Properties.Resources.resim1,
                Properties.Resources.resim2,
                Properties.Resources.resim3,
            };

            comboBox1.Items.Add("Düz Renk");
            comboBox1.Items.Add("Resimli Duvar Kağıdı");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string secim = comboBox1.SelectedItem.ToString();

                if (secim == "Düz Renk")
                {
                    Random random = new Random();
                    int red = random.Next(0, 256);
                    int green = random.Next(0, 256);
                    int blue = random.Next(0, 256);

                    this.BackColor = Color.FromArgb(red, green, blue);
                    this.BackgroundImage = null; // Arka plan resmini kaldır
                    pictureBox1.Image = null; // PictureBox'tan resmi kaldır
                }
                else if (secim == "Resimli Duvar Kağıdı")
                {
                    Random random = new Random();
                    int index = random.Next(resimler.Count);
                    selectedImage = resimler[index]; // Seçilen resmi sakla

                    pictureBox1.Image = selectedImage; // Resmi PictureBox'ta göster
                    this.BackgroundImage = null; // Arka planı sıfırla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedImage != null)
            {
                this.BackgroundImage = selectedImage; // Seçilen resmi arka plan olarak ayarla
                this.BackgroundImageLayout = ImageLayout.Stretch; // Resmi formun boyutuna göre uzat
                pictureBox1.Visible = false;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedImage = null; // Seçilen resmi sıfırla
            pictureBox1.Image = null; // PictureBox'ı sıfırla
            pictureBox1.Visible = true;
            this.BackgroundImage = null; // Arka planı sıfırla
            this.BackColor = SystemColors.Control; //
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Uygulamayı kapat
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(resimler.Count);
            Image selectedImage = resimler[index]; // Seçilen resmi sakla

            // Seçilen resmi PictureBox'ta göster
            pictureBox1.Image = selectedImage;
        }
    }
}
