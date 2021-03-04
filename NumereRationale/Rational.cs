using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereRationale
{
    class Rational
    {
        private int numarator, numitor;

        public Rational(int numarator,int numitor)
        {
            if (numitor == 0)
            {
                new RationalNumberException("Division by 0");
            }
            this.numarator = numarator;
            this.numitor = numitor;

            if (numitor < 0)
            {
                this.numarator = -numarator;
                this.numitor = -numitor;
            }

            int div = Math.Abs(Utils.gcd(numarator,numitor));
            this.numitor /= div;
            this.numarator /= div;
        }

        public Rational(string a)
        {
            string[] str = a.Split('/');
            if (str.Length > 2 || str.Length == 0)
            {
                new RationalNumberException("String Conversion. Invalid number");
            }
            this.numarator = int.Parse(str[0]);
            if (str.Length < 2)
            {
                this.numitor = 1;
            } else
            {
                this.numitor = int.Parse(str[1]);
            }
            if (this.numitor == 0)
            {
                new RationalNumberException("Division by 0");
            }

            if (numitor < 0)
            {
                this.numarator = -this.numarator;
                this.numitor = -this.numitor;
            }

            int div = Math.Abs(Utils.gcd(this.numarator, this.numitor));
            this.numitor /= div;
            this.numarator /= div;
        }

        public bool Equals(Rational r)
        {
            return this.numarator == r.numarator && this.numitor == r.numitor;
        }
        private Rational add(Rational a)
        {
            return new Rational(this.numarator * a.numitor + a.numarator * this.numitor, this.numitor * a.numitor);
        }

        private Rational substract(Rational a)
        {
            return new Rational(this.numarator * a.numitor - a.numarator * this.numitor, this.numitor * a.numitor);
        }

        private Rational multiply(Rational a)
        {
            return new Rational(this.numarator * a.numarator, this.numitor * a.numitor);
        }

        private Rational divide(Rational a)
        {
            return new Rational(this.numarator * a.numitor, this.numitor * a.numarator);
        }

        private Comparison compare(Rational r)
        {
            int div = Math.Abs(Utils.gcd(this.numitor, r.numitor));
            long a = this.numarator * r.numitor / div;
            long b = r.numarator * this.numitor / div;

            if (a < b)
                return Comparison.Greater;
            else if (a > b)
                return Comparison.Less;
            return Comparison.Equal;
        }

        public enum Comparison
        {
            Equal,Greater,Less
        }

        //Comparare (<,>,<=,>=,==,!=)
        public static bool operator <(Rational a, Rational b)
        {
            return a.compare(b) == Comparison.Greater;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a.compare(b) == Comparison.Less;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            Comparison c = a.compare(b);
            return c == Comparison.Equal || c == Comparison.Less;
        }
        public static bool operator <=(Rational a, Rational b)
        {
            Comparison c = a.compare(b);
            return c == Comparison.Equal || c == Comparison.Greater;
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.compare(b) == Comparison.Equal;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return a.compare(b) != Comparison.Equal;
        }

        //Operatii (+,-,*,/)
        public static Rational operator +(Rational a, Rational b)
        {
            return a.add(b);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return a.substract(b);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return a.multiply(b);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            return a.divide(b);
        }

        public static implicit operator string(Rational r) {
            return r.toString(); 
        }

        public string toString()
        {
            return $"{this.numarator}/{this.numitor}";
        }
    }
}
