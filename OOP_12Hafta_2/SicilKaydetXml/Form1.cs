using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SicilKaydetXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Bu kodları çalıştırabilmek için vb interactions kullanmamız gerekti.
            //Çalıştırabilecek var mı bilmiyorum ama denemek isterseniz, projenin referans bölümünden eklemeniz gerekir.
            //Textboxlardan tek farkı çok afedersiniz skko bir component kullanma isteğidir. İş hayatınızda çıkma oranını hesaplamak için microsoftta çalışan amcamdan program yazmasını istedim istifa ett.

            string s;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\PC\Desktop\sicil.xml");


            XmlElement kullanici = doc.CreateElement("kullanici");
            s = Interaction.InputBox("SİCİL=", "Input", "");
            kullanici.SetAttribute("Sicil", s);


            XmlNode adsoyad = doc.CreateNode(XmlNodeType.Element, "adsoyad", "");
            adsoyad.InnerText = Interaction.InputBox("ADSOYAD=", "Input", ""); ;
            kullanici.AppendChild(adsoyad);


            XmlNode gorev = doc.CreateNode(XmlNodeType.Element, "gorev", "");
            gorev.InnerText = Interaction.InputBox("GOREV=", "Input", "");
            kullanici.AppendChild(gorev);

            XmlNode maas = doc.CreateNode(XmlNodeType.Element, "maas", "");
            maas.InnerText = Interaction.InputBox("MAAS=", "Input", "");
            kullanici.AppendChild(maas);

            doc.DocumentElement.AppendChild(kullanici);
            doc.Save(@"C:\Users\PC\Desktop\sicil.xml");
        }
    }
}
