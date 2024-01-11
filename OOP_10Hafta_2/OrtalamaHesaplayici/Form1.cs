using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//Adım 1 
using ClassLibrary2;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrtalamaHesaplayici
{
    public partial class Form1 : Form
    {
        /*
            Öğrencilerin vize1 ,vize2 ve 
            final notları klavyeden girildikten 
            sonra sonucu ekranda görüntüleyen program kodunu yazınız. 
            Koşul, öğrencilerin notları textbox1, textbox2, ve textbox3 ten 
            girilecek sonuç textbox4 te 
            not ortalaması ile birlikte geçti ve kaldı olarak gözükecek
         */

        //Adım 2
        Ortalama_Hesapla hesap = new Ortalama_Hesapla();
        int a, b, c;

        public Form1()
        {
            InitializeComponent();
        }

        //Adım 3
        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            c = Convert.ToInt32(textBox3.Text);

            textBox4.Text = hesap.Hesapla(a, b, c);
        }
    }
}
