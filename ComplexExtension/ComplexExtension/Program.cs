using System;
using System.Collections.Generic;

namespace ComplexExtension
{
    class Complex
    {
        public int real, imaginary;

        public Complex()
        {
            this.real = 0;
            this.imaginary = 0;
        }

        public Complex(int real)
        {
            this.real = real;
            this.imaginary = 0;
        }

        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public Complex(string inp)
        {
            try
            {
                string[] split;
                string input = inp.Replace("i", "");
                if (input.Contains("+"))
                {
                    split = input.Split('+');
                    this.real = int.Parse(split[0]);
                    this.imaginary = int.Parse(split[1]);
                }
                else if (input.Contains("-"))
                {
                    split = input.Split('-');
                    this.real = int.Parse(split[0]);
                    this.imaginary = -int.Parse(split[1]);
                }
                else
                {
                    this.real = int.Parse(input);
                    this.imaginary = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid format! Use: 'a+bi' or 'a-bi' instead");
            }
        }

        public double Distance(Complex complex)
        {
            return Math.Sqrt(Math.Pow(this.real - complex.real, 2) + Math.Pow(this.imaginary - complex.imaginary, 2));
        }

        public double Abs()
        {
            return Math.Abs(Math.Sqrt(this.real * this.real + this.imaginary * this.imaginary));
        }

        public string ToTrigonometricalForm()
        {
            string teta = $"{Math.Atan(this.imaginary / this.real).ToString("0.00")}";
            return $"{this.Abs().ToString("0.00")} * ( cos {teta} + i*sin {teta} )";
        }

        public bool Equals(Complex c)
        {
            return this.real == c.real && this.imaginary == c.imaginary;
        }
        private Complex Add(Complex a)
        {
            return new Complex(this.real + a.real, this.imaginary + a.imaginary);
        }

        private Complex Substract(Complex a)
        {
            return new Complex(this.real - a.real, this.imaginary - a.imaginary);
        }

        private Complex Multiply(Complex a)
        {
            return new Complex(this.real * a.real - this.imaginary * a.imaginary, this.real * a.imaginary + this.imaginary * a.real);
        }

        public virtual string Power(int n)
        {
            Complex return_complex = this;
            for (int i = 1; i <= n; i++)
            {
                return_complex *= this;
            }
            return return_complex.ToString();
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return a.Add(b);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return a.Substract(b);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return a.Multiply(b);
        }

        public static Complex operator ^(Complex a, int pow)
        {
            Complex return_complex = a;
            for (int i = 1; i <= pow; i++)
            {
                return_complex *= a;
            }
            return return_complex;
        }

        public static implicit operator string(Complex r)
        {
            return r.ToString();
        }
        public override String ToString()
        {
            return $"{this.real} {(this.imaginary < 0 ? "-" : "+")} {Math.Abs(this.imaginary)}i";
        }

    }

    class ComplexD : Complex
    {

        public double distance(List<Complex> list)
        {
            double min = this.Distance(list[0]);
            double dist;
            for (int i = 1; i < list.Count; i++)
            {
                if ((dist = this.Distance(list[i])) < min)
                    min = dist;
            }
            return min;
        }

        public override string Power(int n)
        {
            double abs = this.Abs() * n;
            double teta = Math.Atan(this.imaginary / this.real) * n;
            string a = $"{(teta % 1.00D == 0.00D ? $"{teta}" : teta.ToString("0.00"))}";
            return $"{(abs % 1.00D == 0.00D ? $"{abs}" : abs.ToString("0.00"))} * ( cos {a} + i*sin {a} )";
        }
    }
}
