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

namespace OOP_4Hafta_3
{
    public partial class Form1 : Form
    {
        //[1] Geçen dersteki tanımlamaların aynısını yapıyoruz. Dileyen bir önceki forma gidip göz atabilir.
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        //[2] Her şeyden önce Mutlaka bir connection string tanımlamalı ve connection açmalıyız. Listeleme ile ilgili detayları nerde bulacağınızı biliyorsunuz.
        private void Listele()
        {
            string constring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + Application.StartupPath + "\\deneme.mdb";

            connection = new OleDbConnection(constring);
            adapter = new OleDbDataAdapter("select * from ogr", constring);
            dt = new DataTable();
            adapter.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;

        }

        /*
         Dersin Asıl konusuna gelirsek, Vizede karşımıza çıkmış olan bu soru iki tablo arasındaki ilişkiyi, 
         C# üzerinden nesneler kullanarak ilişkilendirmeyi hedefliyor.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            /*[1] Üç adet tablomuzu birbirine bağlayacağımız için üç adet adapter kullanarak tablolarımızdaki
             * verileri elde ediyoruz. Sırasıyla a, b ve c olarak isimlendirdik. SQL Cümleciklerine dikkat.*/
            OleDbDataAdapter a = new OleDbDataAdapter("Select * from ogr", connection);
            OleDbDataAdapter b = new OleDbDataAdapter("Select * from ogr2", connection);
            OleDbDataAdapter c = new OleDbDataAdapter("Select * from ogr3", connection);

            //[2] DataTable nesnelerimizi oluşturuyoruz ve bu oluşturduğumuz, nesneleri birer isimle temsil ediyoruz.
            DataTable dt1 = new DataTable("ogr");
            a.Fill(dt1);

            DataTable dt2 = new DataTable("ogr2");
            b.Fill(dt2);

            DataTable dt3 = new DataTable("ogr3");
            c.Fill(dt3);

            //[3] Kritik noktalardan biri, OGR1 -> OGR2 -> OGR3 olacağı için iki adet (2) ilişkiye ihtiyacımız var.
            //Bu bağlantı için DataRelation sınıfını kullanıyoruz.
            DataRelation dr1;
            DataRelation dr2;

            //[4] Binding source yerine DataSet kullaniyoruz çünkü hocamız bunların hepsinin aynı olduğunu söyledi, sebep? bilmiyoruz. Aynı şey.
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt3);
            ds.Tables.Add(dt2);

            //[5] DataRelation sınıfını kullanmaya başlıyoruz, DataRelation nesnesi bizden üç adet parametre ister,
            //Bu parametreler sırasıyla, title - açıklaması, parent yani üst tablo ve child yani alt tablo parametreleridir.
            dr1 = new DataRelation("ogr_den_gecis_yap_ogr2", dt1.Columns["Kimlik"], dt2.Columns["Kimlik"]);
            dr2 = new DataRelation("ogr2_den_gecis_yap_ogr3", dt2.Columns["Kimlik"], dt3.Columns["Kimlik"]);

            //[6] Dataset nesnesinin Relations özelliklerini kullanarak, kurduğumuz ilişkileri database'e ekliyoruz.
            ds.Relations.Add(dr1);
            ds.Relations.Add(dr2);
            //[7] Kullanacağımız tablonun datagridview yerine datagrid olmasına dikkat edelim. Tools kısmında bulamazsanız, küçük bir araştırma ile bulabilirsiniz. 
            dataGrid1.DataSource = ds;

        }
    }
}
