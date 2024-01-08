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

namespace OOP_4Hafta_2
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        DataTable dt;

        BindingSource bs = new BindingSource();
        
        public Form1()
        {
            InitializeComponent();
        }

        //[1]Listeleme işlemi için ayrı bir metod oluşturuyoruz.
        void Listele()
        {
            /*[2]Bağlantı cümlesi ve komut için iki adet değişken oluşturuyoruz. */
            string constring, cmd;
            constring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\personel.mdb";
            cmd = "Select * from maas";
            /*[3]Buradaki sıralamaya dikkat etmemiz gerekiyor. 
             Öncelikle bağlantımızı tanımlıyoruz. Bu DB hangisi bunu söylememiz gerekiyor. 
             Akabinde adapter ile verileri alıyoruz.
             adaptarden gelen veriyi DataTable'a veriyoruz ve bu verdiğimiz datayı 
             data table üzerinden binding source'un datasource'ına atıyoruz.
             son aşama olarak gridview'ımzı binding source ile dolduruyoruz.
             */
            connection = new OleDbConnection(constring);
            adapter = new OleDbDataAdapter(cmd, constring);
            dt = new DataTable();
            adapter.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }

        /*[1]Textbox'ları temizlemek için ayrı bir metod oluşturuyoruz.*/
        void Temizle()
        {
            /*[2] Ben burda kişisel tercih ve kod karmaşasını önlemek adına dizi ve for döngüsü kullandım. (chatgpt)
             isteyen textboxları teker teker sıfırlayabilir.
            */
            TextBox[] textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = "";
            }
        }

        /*[1] Silme işlemi için ayrı bir metod oluşturuyoruz. Gerek var mı? Eh. Direkt butonun click metoduna da tanımlanabilir.*/
        void Sil()
        {
            /*[2] Burada işler kritikleşiyor, hem silmede hem de güncellemede biraz SQL sorgusu bilgisine ihtiyacınız olmalı.
              bu aşamada yukarıda tanımladığımız command nesnesine ihtiyacımız var. 
              Hatırlarsınız OleDBCommand nesnesini Listelemede kullanmadık. Burada da adapter kullanmayacağız. 
              !!İlgili sütunlara erişebilmek için, cümle içindeki sütuna bir parametre atadık, cümleden sonra connection'umuzu tanımladık.
             */
            command = new OleDbCommand("Delete From maas Where SIGORTANO=@SIGORTANO", connection);
            /*[3]Burası istek üzerine olan bir kod. If Else bloğu zorunlu değil.
             Silme işlemini yaparken uygulamanın patlamaması için if else ile null kontrolü yapıyoruz. 
             Hem row hem cell değerlerinin ikisini de kontrol etmemizdeki amaç hiç data yoksa yine hata vermemesidir.*/
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                /*[4] Geldik kritik noktaya. Sınavda ezberlemedik 27 aldık aq. command öğesinin parametrelerinden Parameters ile
                 ona ait olan AddWithValue Metodunu çağırıyoruz. Metodun Overloadında, SQL cümleciği içindeki parametremiz ve
                o paremetreye atayacağımız value yer alıyor. JSON bilenler için key value gibi düşünebiliriz.*/
                command.Parameters.AddWithValue("@SIGORTANO", dataGridView1.CurrentRow.Cells[0].Value);
                /*[5] Unutursak puan kırılıyor. CRUD işlemlerinin R işlemi hariç hepsinde ORM kullanmıyorsak (Berke sen de orm ye geçeceksin)
                 SQL connectionumuz açık olmalı, commandımızı çalıştırmalı ve bağlantıyı kapatmalıyız. Sonraki çağrılan metodlar ise, zaten yukarıda
                anlattım gidin bakın mantık kurun aq. */
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Listele();
                Temizle();
            }
            /*[5] Dediğim gibi, zorunlu değil. Anlatmaya gerek yok, görüyorsunuz.*/
            else
            {
                MessageBox.Show("Silinecek Bir Kayıt Yok", "Uyarı");
            }
        }

        /*[1] Güncelleme yapabilmek için ayrı metodumuzu yazıyoruz.*/
        void Guncelle()
        {
            /*[2] Silme işleminde yaptığımız gibi, öncesinde parametreli bir şekilde query tanımlıyoruz
              Burada dikkat etmemiz gereken hususlardan biri ki ben aynısını yaşadım, parametrelerin sıralamasını doğru yapmak.
              örneğin önce @ad parametresini koyduysak AddWithValue metodunun sıralamasını da ona göre yapmamız gerekiyor.
              Connection open'ları daha fazla anlatmama gerek var mı? Kafanızı karıştıran bir yer olursa benimle iletişime geçmeyin.*/
            command = new OleDbCommand("UPDATE maas SET AD = @AD WHERE SIGORTANO = @SIGORTANO;", connection);
            command.Parameters.AddWithValue("@AD", textBox2.Text);
            command.Parameters.AddWithValue("@SIGORTANO", dataGridView1.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Listele();
        }
        
        /*[1] Ekleme işlemi yapabilmek için ayrı metod oluşturuyoruz. (evet, tekrardan.) */
        void Ekle()
        {
            //Buralardaki kodları açıklamama gerek olmadığını varsayarak ilerliyoruz.
            command = new OleDbCommand("Insert into maas (SIGORTANO, AD, SOYAD, MAAS, ADRES) values (@SIGORTANO, @AD, @SOYAD, @MAAS, @ADRES)", connection);
            command.Parameters.AddWithValue("@SIGORTANO", Convert.ToInt32(textBox1.Text));
            command.Parameters.AddWithValue("@AD", textBox2.Text);
            command.Parameters.AddWithValue("@SOYAD", textBox3.Text);
            command.Parameters.AddWithValue("@AD", Convert.ToInt32(textBox4.Text));
            command.Parameters.AddWithValue("@AD", textBox5.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Listele();
            Temizle();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ekle();
        }
    }
}
