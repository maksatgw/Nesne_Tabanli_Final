using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//Adım 1 DLL Olarak referans ettiğimiz class library kütüphanesi.
using ClassLibrary1;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alan_Hacim
{
    public partial class Form1 : Form
    {
        //Adım 2, referansımızın gücü ile ilgili classlarımızdan nesneler türetiyoruz.
        Alan_Hesabi alan = new Alan_Hesabi();
        Hacim_Hesabi hacim = new Hacim_Hesabi();
        int a, b, c;

        public Form1()
        {
            InitializeComponent();
        }

        //Adım 3, Mantık olarak
        //Önce değer atama fonksiyonunu çağırıp alacağımız değerleri hazırlıyoruz. 
        //Daha az karışık yolu için burada bir metod tanımladım.
        private void basit()
        {
            a = int.Parse(textBox1.Text);
            b = int.Parse(textBox2.Text);
            c = int.Parse(textBox3.Text);

            int listeyeEkle = alan.kare(a);

            listBox1.Items.Add(listeyeEkle.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deger_atama();
            listBox1.Items.Add(alan.kare(a).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deger_atama();
            listBox1.Items.Add(hacim.kup(a).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deger_atama();
            listBox1.Items.Add(alan.dikdortgen(a, b).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deger_atama();
            listBox1.Items.Add(hacim.dikdortgen_prizma(a, b, c).ToString());
        }

        public void deger_atama()
        {
            a = int.Parse(textBox1.Text);
            b = int.Parse(textBox2.Text);
            c = int.Parse(textBox3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
