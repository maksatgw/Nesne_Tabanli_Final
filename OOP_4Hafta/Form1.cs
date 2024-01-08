using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_4Hafta
{
    public partial class Form1 : Form
    {
        //Bir manual veritabanı bağlantısı yaparken
        /*
        Mutlaka bir bağlantı nesnesine,
        Adaptör nesnesine, 
        Komut nesnesine, 
        DataTable veya DataSet nesnelerine ihtiyacımız oluyor.
         */

        OleDbConnection baglan;
        OleDbDataAdapter verial;
        OleDbCommand komut;
        DataTable dt;

        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            //İki adet string değişkeni tanımlıyoruz, biri bağlantı cümleciğimizi diğeri sorgumuzu tutacak ve bunları ilgili nesnelere yollayacağız. 
            string baglanti, sorgu;
            baglanti = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\deneme.mdb";
            sorgu = "select * from ogr";
            //Public class altında tanımladığımız nesnelerimizi kullanmaya başlıyoruz.
            baglan = new OleDbConnection(baglanti);
            verial = new OleDbDataAdapter(sorgu, baglanti);
            dt = new DataTable();
            verial.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }

        void Temizle()
        {
            dataGridView1.DataSource = bs;
        }
        void Insert()
        {
            string insertCmd;
            insertCmd = "Insert into ogr (ORGRAD) values (@ORGRAD)";
            komut = new OleDbCommand(insertCmd, baglan);
            komut.Parameters.AddWithValue("@ORGRAD", textBox1.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
        }
    }
}
