using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surroundings
{
    class Program
    {
        public static int[,] T;
        public static int lines, cols;
        static Random r = new Random();

        public static void init()
        {
            T = new int[lines,cols];
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    T[i, j] = r.Next(2);
                }
            }
            printTable();
        }

        static int[] getSurroundings(int line, int col)
        {
            int zero = 0;
            int one = 0;

            int new_line, new_col;
            for (int a = -1; a <= 1; a++)
            {
                new_line = line + a;
                if (new_line < 0 || new_line > lines-1)
                    continue;
                for (int b = -1; b <= 1; b++)
                {
                    new_col = col + b;
                    if (new_col < 0 || new_col > cols-1 || new_col == col && new_line == line)
                        continue;
                    Console.WriteLine($"{new_line},{new_col} - {a},{b}");
                    Console.WriteLine(getCoord(a, b));
                    if (T[new_line, new_col] == 0)
                        zero++;
                    else if (T[new_line, new_col] == 1)
                        one++;
                }
            }
            int[] final_res = new int[2];
            final_res[0] = zero;
            final_res[1] = one;
            return final_res;
        }

        static string getCoord(int a,int b)
        {
            if (a == -1)
            {
                if (b == -1) return "NW";
                if (b == 0) return "N";
                if (b == 1) return "NE";
            }
            if (a == 0)
            {
                if (b == -1) return "W";
                if (b == 1) return "E";
            }
            if (a == 1)
            {
                if (b == -1) return "SW";
                if (b == 0) return "S";
                if (b == 1) return "SE";
            }
            return "";
        }

        static bool isAllZero()
        {
            for (int line = 0; line < lines; line++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (T[line, col] != 0)
                        return false;
                }
            }
            return true;
        }

        static void printTable()
        {
            for (int line = 0; line < lines; line++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(T[line,col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            /*string[] lines = Console.ReadLine().Split(' ');
            int t_lines = lines.Length;
            int t_cols = lines[0].Length;
            int[,] v = new int[t_lines, t_cols];
            int l = 0;
            int a;
            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    a = int.Parse($"{line[i]}");
                    v[l, i] = a;
                }
                l++;
            }
            */
            lines = 3;
            cols = 6;
            init();


            int zero, one;
            int[] result;
            do
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result = getSurroundings(i, j);
                        zero = result[0];
                        one = result[1];
                        if (zero > one)
                            T[i, j] = 0;
                    }
                }
                printTable();
            } while (!isAllZero());

        }
    }
}
