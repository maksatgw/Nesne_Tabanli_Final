using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_5Hafta_3
{
    public partial class Form1 : Form
    {

        /*Veritabanı içinde bir takım işlemler yaparken ihtiyacımız olacak nesneler 
       ya da değişkenler olabilir. Bu nesne ve değişkenlerin mutlaka veri tipinde
       tanımlanmış olması gerekiyor ki aşağıda veri ataması yapabilelim.*/
        /*Kullanmamız gereken 4 adet temel nesnemiz var.
          Bu nesneleri mutlaka tanımlamalıyız, daha sonra bunlara değer ataması yapmalıyız*/
        /*Bu nesneleri public partial class altında tanımlayacağız çünkü bu nesneleri ileride bir çok yerde kullanacağız.*/
        OleDbConnection baglan;
        OleDbDataAdapter da1, da2;
        OleDbCommand komut1, komut2;
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        DataSet ds;

        //Veritabanında kayıtlı olan iki ayrı tabloyu nasıl ilişkilendireceğimizi göreceğiz.

        void iliskiKur()
        {
            //Olmazsa olmazımız database connectionumuz ile başlıyoruz.
            baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + Application.StartupPath + "\\deneme.mdb");
            //Kaç adet tabloyu birbiri ile ilişkilendirecekseniz, o kadar fazla ayarlama yapmanı gerekir.
            //1. Tablo için bir data adapter ve bir datatable, 2. tablo için bir data adapter ve bir datatable tanımlamasınız
            //dataseti bir kere tanımlıyacağız ve iki table için de kullanabileceksiniz. 

            //adı da1 olan, oledbdataadapter olan nesneye iki parametreden biri sql cümlesi, diğeri bağlantı nesnesi
            da1 = new OleDbDataAdapter("Select * from ogr1", baglan);
            //tablo 1 adında bir datatable tanımlıyoruz ve datatable parametresi olarak bir tablo adı giriyoruz.
            DataTable tablo1 = new DataTable("ogr1");
            //daha sonra data adapterimizdeki verileri ön belleğe almak için, adapterdeki verileri tablo1'e atıyoruz.
            da1.Fill(tablo1);

            da2 = new OleDbDataAdapter("Select * from ogr2", baglan);
            DataTable tablo2 = new DataTable("ogr2");
            da2.Fill(tablo2);

            //Bir adet dataset tanımlıyoruz.

            ds = new DataSet();

            //Iki tabloyu ilişkilendireceğim için bir adet datarelation tanımlıyoruz.
            //Eğer üç adet tablo ilişkilendireceksek, iki adet datarelation kullanırdık. 
            DataRelation dr;
            //Adı ds olan dataset nesnesinin table özelliğine tablo1 deki değerleri ata, yani verileri önbelleğe alalım.
            //Dikkat edelim, aynı datasetin üzerine tablo2 den gelen değerleri atıyoruz. 
            ds.Tables.Add(tablo1);
            ds.Tables.Add(tablo2);
    
            dr = new DataRelation("ogr1_ogr2_baglanti", tablo1.Columns["Kimlik"], tablo2.Columns["Kimlik"]);
            ds.Relations.Add(dr);
            dataGrid1.DataSource = ds;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
