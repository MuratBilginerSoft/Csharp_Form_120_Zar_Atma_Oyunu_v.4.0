using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Zar_Atma_Oyunu
{
    public partial class Form1 : Form
    {
        #region Metodlar

        public void gizle()
        {
            comboBox1.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            i = 0;
            oyuntur = 0;
            tur = 1;
            toplam = 0;
            label2.Text = toplam.ToString();
            listBox1.Items.Clear();
            listBox2.Items.Clear();


        
        }

        public void göster()
        {
            comboBox1.Visible = false;
            button2.Visible = false;
            button1.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
          
        
        }

        #endregion

        #region Tanımlamalar

        Random r = new Random();

        int x1, x2;

        int x3, x4;

        int y1, y2;

        int i = 0;

        int oyuntur = 0;

        int tur = 1;

        int toplam = 0;

        int enyüksekskor = 0;

        ArrayList eniyiskor=new ArrayList();

        

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gizle();
            comboBox1.Text = "Kaç Tur Oynayacaksınız?";
            eniyiskor.Add(enyüksekskor);
            label3.Text = eniyiskor[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            i = 0;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tur<oyuntur)
            {
                i++;

                if (i < 10)
                {

                    x3 = r.Next(0, 191);
                    x4 = r.Next(250, 451);
                    y1 = r.Next(30, 331);
                    y2 = r.Next(30, 331);
                    x1 = r.Next(1, 7);
                    x2 = r.Next(1, 7);

                    pictureBox1.Location = new Point(x3, y1);
                    pictureBox2.Location = new Point(x4, y2);

                    pictureBox1.Image = ımageList1.Images[x1 - 1];
                    pictureBox2.Image = ımageList1.Images[x2 - 1];
                }

                else
                {

                    x1 = r.Next(1, 7);
                    x2 = r.Next(1, 7);

                    pictureBox1.Image = ımageList1.Images[x1 - 1];
                    pictureBox2.Image = ımageList1.Images[x2 - 1];
                    timer1.Stop();

                    listBox1.Items.Add(x1);
                    listBox2.Items.Add(x2);
                    tur++;
                    toplam += x1 + x2;
                    label2.Text = toplam.ToString();

                }

                
	
            }

            else if (tur==oyuntur)
           
            {

                i++;

                if (i < 10)
                {

                    x3 = r.Next(0, 191);
                    x4 = r.Next(250, 451);
                    y1 = r.Next(30, 331);
                    y2 = r.Next(30, 331);
                    x1 = r.Next(1, 7);
                    x2 = r.Next(1, 7);

                    pictureBox1.Location = new Point(x3, y1);
                    pictureBox2.Location = new Point(x4, y2);

                    pictureBox1.Image = ımageList1.Images[x1 - 1];
                    pictureBox2.Image = ımageList1.Images[x2 - 1];
                }

                else
                {

                    x1 = r.Next(1, 7);
                    x2 = r.Next(1, 7);

                    pictureBox1.Image = ımageList1.Images[x1 - 1];
                    pictureBox2.Image = ımageList1.Images[x2 - 1];
                   

                    listBox1.Items.Add(x1);
                    listBox2.Items.Add(x2);
                    tur++;
                    toplam += x1 + x2;
                    label2.Text = toplam.ToString();

                    if ((int)eniyiskor[0] < toplam)
                    {
                        eniyiskor.Clear();
                        eniyiskor.Add(toplam);
                        label3.Text = eniyiskor[0].ToString();
                        timer1.Stop();
                        

                        MessageBox.Show("Tebrikler!!! En iyi skorunuzu geçtiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gizle();
                        comboBox1.Text = "Kaç Tur Oynayacaksınız?";
                    }

                    else
                    {
                        timer1.Stop();
                        MessageBox.Show("Ne yazık ki en iyi skorunuzu geçemediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       gizle();
                        comboBox1.Text = "Kaç Tur Oynayacaksınız?";
                    }
                }

           }
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                oyuntur = int.Parse(comboBox1.Text);
                if (oyuntur == 3 || oyuntur == 5 || oyuntur == 7 || oyuntur == 10)
                {
                    göster();
                }

                else
                    MessageBox.Show("Listedeki değerlerden başka bir değer giremezsiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch
            {
                MessageBox.Show("Listedeki değerlerden başka bir değer giremezsiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

   }
}