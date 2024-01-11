using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Ortalama_Hesapla
    {
        //Ben geçti kaldı karar döngüsünü metodun içinde ayarladım
        //İsteyen int değer döndürüp form içinde sağlamasını yapabilir.
        public string Hesapla(int vize1, int vize2, int final)
        {
            int ortalama = (vize1 + vize2 + final) / 3;

            if (ortalama < 50)
            {
                return "Kaldı";
            }
            else
            {
                return "Geçti";
            }
        }
    }
}
