using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereRationale
{
    class RationalNumberException : Exception
    {
        public RationalNumberException()
        {

        }

        public RationalNumberException(string type) : base ($"{type}")
        {

        }
    }
}
