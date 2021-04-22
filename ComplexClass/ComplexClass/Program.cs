using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(Console.ReadLine());
            Complex c2 = new Complex(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine(c1 + c2);
            Console.WriteLine();
            Console.WriteLine(c1 - c2); 
            Console.WriteLine();
            Console.WriteLine(c1 * c2);
            Console.WriteLine();
            Console.WriteLine(c1 ^ 2);
            Console.WriteLine();
            Console.WriteLine(c2 ^ 3);
            Console.WriteLine();
            Console.WriteLine(c1.ToTrigonometricalForm());
            Console.WriteLine();
            Console.WriteLine(c2.ToTrigonometricalForm());
        }
    }
}
