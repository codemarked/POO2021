using System;
using System.Text;

namespace StarClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int lines = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Star star = new Star(lines);
            star.view();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
        }
    }

    class Star
    {
        private static readonly string STAR_SYMBOL = "*";
        private int lines;
        private int id;
        private static int COUNTER = 0;

        public Star(int lines)
        {
            this.lines = lines;
            this.id = ++COUNTER;
        }

        public void view()
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine(getStars(i + 1));
            }
        }

        private string getStars(int total)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < total; i++)
            {
                str.Append(STAR_SYMBOL);
            }
            return str.ToString();
        }

        ~Star()
        {
            Console.WriteLine($"Star #{this.id} has been destroyed!");
        }
    }
}
