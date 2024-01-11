using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//[1] Threads Kütüphanesini ekliyoruz
using System.Threading;

namespace OOP_6Hafta_3
{
    public partial class Form1 : Form
    {
        /*
         Form üzerine 3 adet listbox, 1 adet DataGridView ve 1 adet button yerleştirin.
         Form load edildiği zaman ListBox1 içinde öğrenci numaraları (başlangıç noktası 2023000001 olmak kaydıyla 1'er 1'er artarak devam edecek.
         Bununla aynı anda bölüm ismi Listbox2'de, yıl ListBox3'te görüntülenecek. 
         listBox 1 değerleri DataGridView kolon 1'de, Listbox3 Kolon 2'de, Listbox3 de kolon3 de aynı anda görüntülenecek.
         Not: Numara 1'er artarken yıl ve bölüm değerleri sabit kalacak.
        */
        //Sırası ile çözümleri [] parantezlerin içinde sayıyla belirledim.

        //[1] Thread nesnelerini tanımlıyoruz
        Thread task1;
        Thread task2;
        Thread task3;
        Thread task4;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //[2]Böylelikle metot otomatik olarak formun load olayına bağlıdır
            //Mutlaka yazmak zorundayiz
            Form1.CheckForIllegalCrossThreadCalls = false;
            
            //[6] Tanımladığımız tasklare ThreadStart ile çalıştıracağımız metotları veriyoruz, ardından start ile başlatıyoruz.
            task1 = new Thread(new ThreadStart(OgrenciNumaralari));
            task2 = new Thread(new ThreadStart(func2));
            task3 = new Thread(new ThreadStart(func3));
            task4 = new Thread(new ThreadStart(func4));
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
        }

        //[3] Öğrenci numalaraları için bir adet numara ve bir adet counter değişkeni tanımlıyoruz.
        int no = 2023000001;
        //Counter değişkenimizin değerini -1 yapıyoruz
        //Yani ilk değerin 0 olması lazım. Threadler ile eşzamanlı çalıştığımız için bu değere 0 atarsak, OgrenciNumaralari fonksiyonundan sonra 1 olacagi icin
        //Program hata verir. Indexler, 0dan başlar.
        //Listbox icindeki nesneleri ayni anda hem yazdirip hem eklersek 1 numarali index yazilmadan direkt acmaya calisacagi icin hata verecektir.
        int counter = -1;


        //[4] Formload içine yazmaktansa ayrı metodlar oluşturuyoruz.
        void OgrenciNumaralari()
        {
            //Sonsuz bir döngü oluşturmak için while true döngüsü oluşturuyoruz.
            while (true)
            {
                //Listeye ilk numarayı ekledik, bir arttırdık.
                listBox1.Items.Add(no);
                no++;
                //Counter nesnemizi işte burada sıfır yaptık. neden sıfır? INDEXLER SIFIRDAN BAŞLAR DA ONDAN.
                counter++;
                Thread.Sleep(1000);
            }
        }
        void func2()
        {
            while (true)
            {
                listBox2.Items.Add(DateTime.Now.Year);
                Thread.Sleep(1000);
            }
        }
        void func3()
        {
            while (true)
            {
                listBox3.Items.Add("D.E.Ü. İ.M.Y.O. Bilgisayar");
                Thread.Sleep(1000);
            }
        }

        void func4()
        {
            Thread.Sleep(100);
            while (true)
            {
                //DataGridView nesnesinin ilgili satirinin birinca kolonuna sirasiyla
                //Listbox1.Items[0],1,2 diye giderek eklemeler yapiyoruz.
                dataGridView1.Rows.Add(listBox1.Items[counter], listBox2.Items[counter], listBox3.Items[counter]);
                Thread.Sleep(1000);
            }
        }
        //[5] Butona bastigimizda, gorevleri bitiriyoruz. 
        private void button1_Click(object sender, EventArgs e)
        {
            task1.Abort();
            task2.Abort();
            task3.Abort();
            task4.Abort();

        }

    }
}   
