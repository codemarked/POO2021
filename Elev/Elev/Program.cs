using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Elev
{
    class Elev
    {
        private string name, firstname;
        private int n;
        private int[] grades;

        public Elev(string nume,string prenume)
        {
            this.name = nume;
            this.firstname = prenume;
            this.n = 0;
            this.grades = new int[this.n];
        }

        public String getName()
        {
            return this.name;
        }

        public String getFirstName()
        {
            return this.firstname;
        }

        public void setGrades(int a)
        {
            this.n = a;
        }

        public int getGrades()
        {
            return this.n;
        }

        public void setGradeList(int[] a)
        {
            this.grades = a;
        }

        public int[] getGradesList()
        {
            return this.grades;
        }

        public double getAvg()
        {
            double sum = 0;
            for (int i = 0; i < this.n; i++)
            {
                sum += this.grades[i];
            }
            return sum / this.n;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.name + " ");
            str.Append(this.firstname + " ");
            for (int i = 0; i < this.n; i++)
            {
                str.Append(this.grades[i] + " ");
            }
            str.Append(" | " + this.getAvg() + " ");
            return str.ToString();
        }
    }
    class SortElev : IComparer<Elev>
    {
        public int Compare(Elev elev1, Elev elev2)
        {
            if (elev1.getAvg() > elev2.getAvg())
                return 0 - 1;
            if (elev1.getAvg() < elev2.getAvg())
                return 1;
            return string.Compare(elev1.getName(), elev2.getName());
        }
    }

    class Program
    {
        static readonly string input_path = @"../../date.in";
        static readonly string output_path = @"../../date.out";

        static List<Elev> load()
        {
            List<Elev> list = new List<Elev>();

            TextReader reader = new StreamReader(input_path);

            string line;
            string[] split_line;
            int[] grades;
            Elev elev;
            while ((line = reader.ReadLine()) != null)
            {
                split_line = line.Split(' ');
                elev = new Elev(split_line[0], split_line[1]);
                elev.setGrades(split_line.Length - 3);
                grades = new int[split_line.Length - 3];
                for (int i = 3; i < split_line.Length; i++)
                {
                    grades[i - 3] = int.Parse(split_line[i]);
                }
                elev.setGradeList(grades);
                list.Add(elev);
            }
            Console.WriteLine();
            reader.Close();
            return list;
        }

        static void save(List<Elev> list)
        {
            TextWriter writer = new StreamWriter(output_path);

            StringBuilder str;
            int[] grades;
            foreach (Elev elev in list)
            {
                str = new StringBuilder();
                grades = elev.getGradesList();
                for (int i = 0; i < elev.getGrades(); i++)
                {
                    str.Append($"{grades[i]} ");
                }
                writer.WriteLine($"{elev.getName()} {elev.getFirstName()} {elev.getGrades()} {str.ToString()}");
            }
            writer.Close();
        }

        static void view(List<Elev> list)
        {
            foreach (Elev elev in list)
            {
                Console.WriteLine(elev.ToString());
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<Elev> elevi = load();

            elevi.Sort(new SortElev());

            view(elevi);

            save(elevi);
        }
    }
}
