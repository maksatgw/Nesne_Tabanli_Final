using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class Alan_Hesabi
    {
        public int kare(int s)
        {
            int alan = s * s;
            return alan;
        }

        public int cember(int r)
        {
            int alan = 3 * (r*r);
            return alan;
        }
        public int dikdortgen(int a, int b)
        {
            int alan = a * b;
            return alan;
        }
        public int ucgen(int b, int h)
        {
            int alan = (int)(0.5 * b * h);
            return alan;
        }
        public int paralelkenar(int b, int h)
        {
            int alan = b * h;
            return alan;
        }
    }
}
