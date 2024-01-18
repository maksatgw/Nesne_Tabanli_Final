using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//1. Adım
using System.Data.OleDb;
//2. Adım
using ClassLibrary4;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometriHesapla
{
    /*
     Geometrik şekillerin alanı ve çevresini heasplayan program kodunu yazınız.
    Koşul: Dll-1 de alanlar, Dll-2'de çevre, Dll-3 hacim hesaplanacaktır.
    Verilerin dönüşü form üzerinde gösterilirken buton tıklamasıyla veri tabanına kaydedilecektir. 
    Hangi geometrik şeklin bilgisi ekranda görüntülenmek isteniyorsa istene veri, veritabanından okunup listView üstünde görüntülenecek.
    */

    public partial class Form1 : Form
    {
        //Adım 3. Command tanımla, referansını aldığın classı tanımla. Connectionu tanımla.
        OleDbCommand command1, command2;

        Alan_Hesabi alan_hesabi = new Alan_Hesabi();

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\deneme.mdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadComboBox();
        }

        //Adım 4. Comboboxa isimleri tanımla, daha sonra veritabanında isimleri bunlara göre kaydedeceğiz.
        void loadComboBox()
        {
            comboBox1.Items.Add("Kare");
            comboBox1.Items.Add("Üçgen");
            comboBox1.Items.Add("Diktörtgen");
        }

        //Adım 5. Hesaplama
        private void aln_hsp_Click(object sender, EventArgs e)
        {
            //Üç adet integer değer tanımmladık. bu değerlere textboxtan gelen verileri atacağız
            int a, b, c;
            //İki basit kontrol var. combobox1.SelectedIndex == 0 değeri 'Kare' ye eşittir. Uzatmamak için ben iki tane koydum.
            if (comboBox1.SelectedIndex == 0)
            {
                a = Convert.ToInt32(textBox1.Text);
                //Burada kafası karışabilecekler için, referans aldığımız sınıftan yani dll den bir nesne üretmiştik. o nesne içindeki metotlara ve özelliklere
                //Bu şekilde erişiyoruz, nesne_adi . metot_adi. kare metodumuz bir parametre istediği için onu da vermeyi ihmal etmeyelim.
                b = alan_hesabi.kare(a);
                alan_txtbx.Text = b.ToString();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox2.Text);
                c = alan_hesabi.ucgen(a,b);
                alan_txtbx.Text = c.ToString();
            }
        }

        //Adım 6. Kaydetme
        private void kaydt_btn_Click(object sender, EventArgs e)
        {
            //komut nesnesine Insert queryimizi girdik. Parametrelerin kullanım şekline dikkat.
            command1 = new OleDbCommand("INSERT INTO Geometrik (sekil, alan) values (@sekil, @alan)", connection);
            //combobox.selectedItem, seçili değeri direkt verir.
            command1.Parameters.AddWithValue("@sekil", comboBox1.SelectedItem.ToString());
            command1.Parameters.AddWithValue("@alan", alan_txtbx.Text.ToString());
            //bağlantı aç kapa unutma!
            connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
        }

        //Adım 7. İstenilen şeklin verilerini getirme.
        private void kyt_getr_Click(object sender, EventArgs e)
        {
            //Listeyi temizle
            listBox1.Items.Clear();
            //Bağlantıyı aç
            connection.Open();
            //Query yaz
            command2 = new OleDbCommand("SELECT * FROM Geometrik where sekil ='" + comboBox1.SelectedItem.ToString() + "'", connection);
            //Reader tanımla ve değer olarak command'ı execute et.
            OleDbDataReader reader = command2.ExecuteReader();
            //Reader çalıştığı sürece ve readerda satır olduğu sürece listboxa ekleme yapmaya devam et.
            while(reader.Read() && reader.HasRows == true)
            {
                listBox1.Items.Add(reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " " + reader.GetValue(4).ToString());
     
            }
            //Bağlantıyı kapat.
            connection.Close();
        }
        
    }
}
