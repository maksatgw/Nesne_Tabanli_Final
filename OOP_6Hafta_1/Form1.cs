using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_6Hafta_1
{
    public partial class Form1 : Form
    {
        //Öncelikli tanımlanması gereken değerler.
        OleDbConnection baglanti;
        OleDbDataAdapter ad1, ad2, ad3;
        OleDbCommand cmd1, cmd2, cmd3;

        public void IliskiEkle()
        {
            //Eger öncesinden yukarıda tanımlanmamışsa, mutlaka bir connection nesnesi tanımlamak zorundayız.
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\deneme.mdb");
            baglanti.Open();

            //Tanımlamamız gereken kurallar var. 1.si mutlaka bir dataadapter tanımlayacağız.
            //2.si mutlaka bir datatable nesnesi tanımlayacağız
            //Unutmuyoruz, her table için bir adet dataadapter, her table için bir adet datatable tanımlayacağız
            //Burada iki table ilişkilendireceğimiz için ikişer adet nesne tanımladık.

            //1. Tanımlamaya gelirsek adı verial1 olan, dataadpter tanımladık ve iki adet parametre verdik.
            //1. si ssql query ikincisi connection nesnesi.
            //ilişkilendirme yapacağımız ogr1 adındaki tablodan verileri çekmiş olduk.
            OleDbDataAdapter verial1 = new OleDbDataAdapter("Select * From ogr", baglanti);
            //ikinci aşamada datatable'a ihtiyaç duyuyoruz, table 1 olan dt nesnesi.
            DataTable table1 = new DataTable("ogr1");
            //daha sonra dataadapter nesnesi üzerinden sql querysi ve connection ile gelen verileri önbelleğe alabilmek için datatable'a atıyoruz.
            verial1.Fill(table1);

            //burası da ikinci table için yapacağımız işlemler
            OleDbDataAdapter verial2 = new OleDbDataAdapter("Select * From ogr2", baglanti);
            DataTable table2 = new DataTable("ogr1");
            verial2.Fill(table2);

            //İki tabloyu ilişkilendireceğimiz için !!!bir adet!!! dataset nesnesine ihtiyacımız var.
            DataSet ds = new DataSet();

            //Datarelation nesnesi iki adet tabloyu birbirine bağlayacağım için bir adet kullanımımız yetiyor.
            DataRelation dr;

            //Dataadapterlerden gelen ve datatable'lara atanan bilgileri dataset nesnesine aktarıyoruz. 
            //Datasetten bir tane tanımlıyoruz ancak içine birden fazla nesne atayabiliyoruz.
            ds.Tables.Add(table1);
            ds.Tables.Add(table2);

            //Datagride aktarmadan önce relationları atıyoruz. 
            //Önce relation adımızı, sonra parent tablomuzun sütununu, sonra child tablomuzun sütununu parametrelere ekliyoruz.
            dr = new DataRelation("ogr1_to_ogr2", table1.Columns["sicilno"], table2.Columns["sicilno"]);

            //Bu ilişkiyi de, datasource'ın relations propertysini kullanarak ekliyoruz.
            ds.Relations.Add(dr);

            //Datagridview kullanmıyoruz, datagrid kullanıyoruz.
            dataGrid1.DataSource = ds;

            
            baglanti.Close();

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
