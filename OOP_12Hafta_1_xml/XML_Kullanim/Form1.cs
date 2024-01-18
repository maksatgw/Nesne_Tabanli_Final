using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Adım
using System.Xml;
using System.Windows.Forms;

namespace XML_Kullanim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "YES!";
            //XML dosyasını yükleyerek XMLDocument nesnesi oluştur
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\PC\Desktop\test.xml");

            //Ogren Adında yeni bir XML öğesi oluştur
            //Kimlik adinda bir attribute ekleyerek texbox1den gelen değeri ona at
            XmlElement ogren = doc.CreateElement("ogren");
            ogren.SetAttribute("Kimlik", textBox1.Text);

            //'tc' adinda yeni bir xml ogesi olustur ve kimlik adinda bir
            //oznitelik ekleyerek textboxtan gelen degeri ata, sonra "ogren" ogesine ekle
            XmlNode tc = doc.CreateNode(XmlNodeType.Element, "tc", "");
            tc.InnerText = textBox1.Text;
            ogren.AppendChild(tc);

            //Ayni islemi ad soyad, adres, dersad, vize ve final, sonuc ogeleri icin tekrarlayin
            XmlNode ad_soyad = doc.CreateNode(XmlNodeType.Element, "adsoyad", "");
            ad_soyad.InnerText = textBox1.Text;
            ogren.AppendChild(ad_soyad);

            XmlNode adres = doc.CreateNode(XmlNodeType.Element, "adres", "");
            adres.InnerText = textBox1.Text;
            ogren.AppendChild(adres);


            XmlNode vize = doc.CreateNode(XmlNodeType.Element, "vize", "");
            vize.InnerText = textBox1.Text;
            ogren.AppendChild(vize);

            XmlNode final = doc.CreateNode(XmlNodeType.Element, "final", "");
            final.InnerText = textBox1.Text;
            ogren.AppendChild(final);

            XmlNode ort = doc.CreateNode(XmlNodeType.Element, "ort", "");
            ort.InnerText = textBox1.Text;
            ogren.AppendChild(final);

            XmlNode sinifCode = doc.CreateNode(XmlNodeType.Element, "sinifCode", "");
            sinifCode.InnerText = textBox1.Text;
            ogren.AppendChild(sinifCode);

            //Bunlarin hepsini kok dosyasina kaydet
            doc.DocumentElement.AppendChild(ogren);
            doc.Save(@"C:\Users\PC\Desktop\test.xml");
        }
    }
}
