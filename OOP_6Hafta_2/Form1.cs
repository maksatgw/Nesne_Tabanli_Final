using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_6Hafta_2
{
    public partial class Form1 : Form
    {
        //Detaylı açıklama hoca tarafından yapılmadı bu derste, isteyen 6. hafta 1. derse göz atabilir.

        Thread task1;
        Thread task2;
        Thread task3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Böylelikle metot otomatik olarak formun load olayına bağlıdır
            //Mutlaka yazmak zorundayiz
            Form1.CheckForIllegalCrossThreadCalls = false;

            task1 = new Thread(new ThreadStart(metot1));
            task2 = new Thread(new ThreadStart(metot2));
            task3 = new Thread(new ThreadStart(metot3));

            task1.Start();
            task2.Start();
            task3.Start();
        }
        int i = 0;
        int j = 0;

        //Bu, Listbox1'e her saniyede 1, 2, 3 şeklinde öğe ekleyecek metot.
        void metot1()
        {
            while (true)
            {
                listBox1.Items.Add(++i);
                //Milisaneyinin 1000de biri oraninda veri ekleyecek
                Thread.Sleep(1000);
            }
        }
        void metot2()
        {
            while (true)
            {
                listBox2.Items.Add(10 * j++);
                //Milisaneyinin 1000de biri oraninda veri ekleyecek
                Thread.Sleep(1000);
            }
        }
        void metot3()
        {
            while (true)
            {
                label1.Text = DateTime.Now.ToLongTimeString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task1.Abort();
            task2.Abort();
            task3.Abort();
        }
    }
}
