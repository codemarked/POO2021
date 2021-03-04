using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereRationale
{
    class Utils
    {
        public static int gcd(int a,int b)
        {
            if (b == 0) return a;
            return gcd(b, a % b);
        }
    }
}
