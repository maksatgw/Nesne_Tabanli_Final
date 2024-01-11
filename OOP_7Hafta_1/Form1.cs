using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//Adım 1
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_7Hafta_1
{
    public partial class Form1 : Form
    {
        //Adım 2
        Thread task1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Adım 3
            //Yazmamız zorunlu
            Form1.CheckForIllegalCrossThreadCalls = false;
            
            //Adım 6
            task1 = new Thread(new ThreadStart(fun1));
            task1.Start();
        }
        //Adım 4
        int no = 1;
        string yazi = "Bilgisayar Programcılığı";
        int no2 = 1001;

        //Adım 5
        public void fun1()
        {
            while (true)
            {
                //Listbox'ın üç kolonuna istenilen şekilde eklenebilir.
                //Addrange ile yapmak için ilgili dökümana göz atabilirsiniz
                //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.multicolumn?view=windowsdesktop-8.0
                listBox1.Items.AddRange(new object[]
                {
                    $"{no}, {yazi} {no2}"
                });
                //listBox1.Items.Add(no +" "+ $"{no2}" );
                no++;
                no2++;
                Thread.Sleep(1000);
            }
        }

        //Adım 7
        private void button1_Click(object sender, EventArgs e)
        {
            task1.Abort();
        }
    }
}
