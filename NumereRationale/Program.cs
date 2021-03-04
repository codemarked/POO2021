using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereRationale
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Numarator: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Numitor: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Rational r = new Rational(a,b);
            Rational r2;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Rational: " + r);
                Console.WriteLine();
                Console.WriteLine("Introduceti operatia/compararea dorita:");
                Console.WriteLine("+ , - , * , /");
                Console.WriteLine("< , > , <= , >= , == , !=");
                Console.WriteLine();
                switch (Console.ReadLine())
                {
                    case "+":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " + " + r2 + " = " + (r + r2));
                            Console.WriteLine();
                            break;
                        }
                    case "-":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " - " + r2 + " = " + (r - r2));
                            Console.WriteLine();
                            break;
                        }
                    case "*":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " * " + r2 + " = " + (r * r2));
                            Console.WriteLine();
                            break;
                        }
                    case "/":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " / " + r2 + " = " + (r / r2));
                            Console.WriteLine();
                            break;
                        }
                    case "<":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " < " + r2 + ": " + (r < r2));
                            Console.WriteLine();
                            break;
                        }
                    case ">":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " > " + r2 + ": " + (r > r2));
                            Console.WriteLine();
                            break;
                        }
                    case "<=":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " <= " + r2 + ": " + (r <= r2));
                            Console.WriteLine();
                            break;
                        }
                    case ">=":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " >= " + r2 + ": " + (r >= r2));
                            Console.WriteLine();
                            break;
                        }
                    case "==":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " == " + r2 + ": " + (r == r2));
                            Console.WriteLine();
                            break;
                        }
                    case "!=":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Introduceti un numar rational de forma(a/b):");
                            r2 = new Rational(Console.ReadLine());
                            Console.WriteLine(r + " != " + r2 + ": " + (r != r2));
                            Console.WriteLine();
                            break;
                        }
                }
                Console.WriteLine("Doriti sa reluati programul? (y/n)");
                if (!Console.ReadLine().Equals("y"))
                    break;
            }
            
        }
    }
}
