using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            Matrix m1 = new Matrix(size);

            double[,] values = new double[size, size];
            for (int a = 0; a < size; a++)
            {
                for (int b = 0; b < size; b++)
                {
                    Console.Write($"({a},{b}) = ");
                    values[a, b] = int.Parse(Console.ReadLine());
                }
            }
            m1.setValues(values);
            Console.WriteLine();

            Matrix m2 = new Matrix(size);

            values = new double[size, size];
            for (int a = 0; a < size; a++)
            {
                for (int b = 0; b < size; b++)
                {
                    Console.Write($"({a},{b}) = ");
                    values[a, b] = int.Parse(Console.ReadLine());
                }
            }
            m2.setValues(values);
            Console.WriteLine();

            Console.WriteLine("M1");
            m1.view();
            Console.WriteLine();

            Console.WriteLine("M2");
            m2.view();
            Console.WriteLine();

            Console.WriteLine("Add");
            m1.add(m2).view();
            Console.WriteLine();
            Console.WriteLine("Sub");
            m1.substract(m2).view();
            Console.WriteLine();
            Console.WriteLine("Multy");
            m1.multiply(m2).view();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("M1 - Power");
            m1.power(2).view();
            Console.WriteLine();
            Console.WriteLine("M1 - Reverse");
            m1.reverse().view();
            Console.WriteLine();
            Console.WriteLine("M2 - Reverse");
            m2.reverse().view();
            Console.WriteLine();
            Console.WriteLine($"M1 - Determinant: {Matrix.determinant(m1.getValues(),m1.getSize())}");
            Console.WriteLine();
            Console.WriteLine($"M2 - Determinant: {Matrix.determinant(m2.getValues(), m2.getSize())}");
        }
    }
}
