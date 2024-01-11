using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Personel_Maas
    {
        public int MaasHesapla(int brut, int mesai, int cocuk)
        {
            int vergi = brut * 14 / 100;
            int gunluk = brut / 30;
            int saatlik = gunluk / 8;
            int cocukYardim = (brut * 2 / 100) * cocuk;
            int mesailiUcret = saatlik * mesai;    
            int net = cocukYardim + mesailiUcret + brut - vergi;
            return net;
        }
    }
}
