using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//Bir veritabanı uygulaması yapacağımız için, oleDB kütüphanesini uygulamamıza ekliyoruz.
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_5Hafta_1
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


        //Veri tabanında listeleme işlemi yapmak için aşağıdaki şekilde bir yol izliyoruz.
        void Listele1()
        {
            //Adı bağlan olan connection tipindeki nesnemize bir değer ataması yapıyoruz.
            //İki adet parametre ataması yapıyoruz, biri provider öbürü datasource.
            baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\deneme.mdb");
            //Daha sonra connection nesnemizi open methodu ile bağlantımızı açıyoruz.
            baglan.Open();
            //İkinci atama yapmamız gereken değer DataAdapter nesnesidir.
            //Data adapter nesnesi iki tane parametre alır, birinci parametre sql cümleciği, ikinci parametre bağlantı nesnesidir.
            da1 = new OleDbDataAdapter("Select * from ogr", baglan);
            //Burada select * from ogr diyerek, adı ogr olan tablonun tüm alan bilgilerini seçip alacaktır. 
            //da1 üzerine verdiğimiz verilerin önbelleğe yüklenebilmesi için ya dataset ya da datatable kullanmak zorundayız.
            //hem dataset hem datatable verileri önbelleğe taşır.
            //biz burada datatable kullandık. 
            DataTable tablo1 = new DataTable();
            //adı da1 olan dataadapter tipindeki nesnenin üzerinde yer alan değerlerini önbelleğe taşımak için da1'in fill metodu ile adı tablo1 olan datatable nesnesinin üzerine aktardık.
            da1.Fill(tablo1);
            //Verilerin daha hızlı iletişim kurmasını sağlamak için binding source kullanma yöntemine gittik.
            //Bunun için partial class altında tanımladığımız bindingsource nesnelerine gittik. Bu binding source nesnesini kullanabilmek için, tools kısmından binding source nesnesini forma getirmemiz gerekiyor.
            //Önbelleğe verilerin taşınabilmesi için de tablo1'in üzerindeki tüm değerleri yani dataadapterden gelen tüm değerleri, adı bs1 olan bindingsource nesnesinin datasource'ına atadık.
            bs1.DataSource = tablo1;
            //Artık önbellekteki bilgiler, bs1 nesnesinin üzerinde. 
            //Sıra bunları gösterebilmek için tools nesnelerine atamaya geldi.
            //Nesne olarak da datagridview1 nesnesini kullandık ve datagridview1 nesnesinin datasource özelliğine de bs1'den gelen, yani dataadapterden gelen verileri aktardık.
            dataGridView1.DataSource = bs1;
            //Tüm bu bağlantılar sonucunda sadece bir tablodan veri çektiğimiz unutulmamalıdır. Eğer birden fazla tablodan veri çekeceksek, metodlarımızı çoğaltabiliriz. 
            baglan.Close();
        }

        //Buradaki tüm değişiklikler, nesnelerin adlarıdır. O yüzden olduğu gibi bırakıyorum.
        void Listele2()
        {
            //Adı bağlan olan connection tipindeki nesnemize bir değer ataması yapıyoruz.
            //İki adet parametre ataması yapıyoruz, biri provider öbürü datasource.
            baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\deneme.mdb");
            //Daha sonra connection nesnemizi open methodu ile bağlantımızı açıyoruz.
            baglan.Open();
            //İkinci atama yapmamız gereken değer DataAdapter nesnesidir.
            //Data adapter nesnesi iki tane parametre alır, birinci parametre sql cümleciği, ikinci parametre bağlantı nesnesidir.
            da2 = new OleDbDataAdapter("Select * from ogr2", baglan);
            //Burada select * from ogr diyerek, adı ogr olan tablonun tüm alan bilgilerini seçip alacaktır. 
            //da1 üzerine verdiğimiz verilerin önbelleğe yüklenebilmesi için ya dataset ya da datatable kullanmak zorundayız.
            //hem dataset hem datatable verileri önbelleğe taşır.
            //biz burada datatable kullandık. 
            DataTable tablo2 = new DataTable();
            //adı da1 olan dataadapter tipindeki nesnenin üzerinde yer alan değerlerini önbelleğe taşımak için da1'in fill metodu ile adı tablo1 olan datatable nesnesinin üzerine aktardık.
            da2.Fill(tablo2);
            //Verilerin daha hızlı iletişim kurmasını sağlamak için binding source kullanma yöntemine gittik.
            //Bunun için partial class altında tanımladığımız bindingsource nesnelerine gittik. Bu binding source nesnesini kullanabilmek için, tools kısmından binding source nesnesini forma getirmemiz gerekiyor.
            //Önbelleğe verilerin taşınabilmesi için de tablo1'in üzerindeki tüm değerleri yani dataadapterden gelen tüm değerleri, adı bs1 olan bindingsource nesnesinin datasource'ına atadık.
            bs2.DataSource = tablo2;
            //Artık önbellekteki bilgiler, bs1 nesnesinin üzerinde. 
            //Sıra bunları gösterebilmek için tools nesnelerine atamaya geldi.
            //Nesne olarak da datagridview1 nesnesini kullandık ve datagridview1 nesnesinin datasource özelliğine de bs1'den gelen, yani dataadapterden gelen verileri aktardık.
            dataGridView2.DataSource = bs2;
            //Tüm bu bağlantılar sonucunda sadece bir tablodan veri çektiğimiz unutulmamalıdır. Eğer birden fazla tablodan veri çekeceksek, metodlarımızı çoğaltabiliriz. 
            baglan.Close();
        }

        //Aynı işlemleri, Kaydet metodunda da yapma ihtiyacı duyduk.
        void Kaydet1()
        {
            //Command nesnesi olarak komut1 kullandık. 
            //Yeri gelmişken söyleyelim, sil kaydet ve güncelle gibi ifadeler için bir sql cümleciği kullanıcaksam bu cümleciğin command nesnesi olduğunu biliyoruz.
            //Önce komut1 diye kaydettiğimiz değişkeni tanımlamak ile başladık.
            //INSERT ifadesinden faydalandık, INSERT komutunu OleDBCommand içinde kullanırken iki parametre kullandık, birinci parametre sql cümleciği, ikinci parametre bağlantı nesnesi.
            komut1 = new OleDbCommand("INSERT INTO ogr (Kimlik, ad, soyad) values (@kimlik, @ad, @soyad)", baglan);
            //Yukarıda tanımlamış olduğumuz, kimlik ad soyad adlı parametrelerin hangi nesnelerden değer alacağını belirlemek için 
            //komut1.Parameters.AddWithValue metodlarını kullandık.
            komut1.Parameters.AddWithValue("@Kimlik", Convert.ToInt32(textBox1.Text));
            komut1.Parameters.AddWithValue("@ad", textBox2.Text);
            komut1.Parameters.AddWithValue("@soyad", textBox3.Text);
            //Kaydetme işlemlerinde aynı veritabanı bağlantısında olduğu gibi baglan nesnesini kullanarak connection açılır.
            baglan.Open();
            //yukarıda yapılan işlemleri çalıştırabilmek adına, komut1 nesnesinin executenonquery metodunu kullanıyoruz.
            komut1.ExecuteNonQuery();
            //Programı çalıştırıp geriye değer döndürdükten sonra yine baglan nesnesinin close metodu ile bağlantıyı kapatıyoruz.
            baglan.Close();
            //Textboxların üzerindeki yazıların da görünmemesi için de textbox nesnesinin clear metodunu kullandık.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

           

            //Bir tane table üzerindeki işlemler bu şekilde yürürken, ikinci table için de aynı şekilde yürütülebileceğini ayrı bir alanda göstermek için ayrı bir metod oluşturduk.  
        }

        //Buradaki farklılıklar table ismi, sql cümleciğindeki parametreler ve clear ettiğimiz texboxlar. 
        void Kaydet2()
        {
            //Command nesnesi olarak komut1 kullandık. 
            //Yeri gelmişken söyleyelim, sil kaydet ve güncelle gibi ifadeler için bir sql cümleciği kullanıcaksam bu cümleciğin command nesnesi olduğunu biliyoruz.
            //Önce komut1 diye kaydettiğimiz değişkeni tanımlamak ile başladık.
            //INSERT ifadesinden faydalandık, INSERT komutunu OleDBCommand içinde kullanırken iki parametre kullandık, birinci parametre sql cümleciği, ikinci parametre bağlantı nesnesi.
            komut1 = new OleDbCommand("INSERT INTO ogr2 (ders_kod, ders_adi) values (@ders_kod, @ders_adi)", baglan);
            //Yukarıda tanımlamış olduğumuz, kimlik ad soyad adlı parametrelerin hangi nesnelerden değer alacağını belirlemek için 
            //komut1.Parameters.AddWithValue metodlarını kullandık.
            komut1.Parameters.AddWithValue("@ders_kod", textBox4.Text);
            komut1.Parameters.AddWithValue("@ders_adi", textBox5.Text);
            //Kaydetme işlemlerinde aynı veritabanı bağlantısında olduğu gibi baglan nesnesini kullanarak connection açılır.
            baglan.Open();
            //yukarıda yapılan işlemleri çalıştırabilmek adına, komut1 nesnesinin executenonquery metodunu kullanıyoruz.
            komut1.ExecuteNonQuery();
            //Programı çalıştırıp geriye değer döndürdükten sonra yine baglan nesnesinin close metodu ile bağlantıyı kapatıyoruz.
            //Textboxların üzerindeki yazıların da görünmemesi için de textbox nesnesinin clear metodunu kullandık.
            textBox4.Clear();
            textBox5.Clear();
            //Bir tane table üzerindeki işlemler bu şekilde yürürken, ikinci table için de aynı şekilde yürütülebileceğini ayrı bir alanda göstermek için ayrı bir metod oluşturduk.  
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
