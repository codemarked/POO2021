using System;

namespace Matrici
{
    class Matrix
    {
        private int size;

        private double[,] values;

        public Matrix(int size)
        {
            this.init(size);
            this.setZero();
        }

        private void init(int size)
        {
            this.size = size;
            this.values = new double[this.size,this.size];
        }

        public Matrix add(Matrix matrix)
        {
            if (this.size != matrix.size)
                new Exception("Matrix don't have the same size");
            Matrix return_matrix = new Matrix(this.size);
            for (int a = 0; a < this.size; a++) 
                for (int b = 0; b < this.size; b++)
                {
                    return_matrix.values[a, b] = this.values[a, b] + matrix.values[a, b];
                }
            return return_matrix;
        }

        public Matrix substract(Matrix matrix)
        {
            if (this.size != matrix.size)
                new Exception("Matrix don't have the same size");
            Matrix return_matrix = new Matrix(this.size);
            for (int a = 0; a < this.size; a++)
                for (int b = 0; b < this.size; b++)
                {
                    return_matrix.values[a, b] = this.values[a, b] - matrix.values[a, b];
                }
            return return_matrix;
        }

        public Matrix power(int power)
        {
            Matrix first = this.clone();
            Matrix matrix = first;
            for (int i = 1; i < power; i++)
            {
                matrix = matrix.multiply(first);
            }
            return matrix;
        }

        public Matrix multiply(Matrix matrix)
        {
            if (this.size != matrix.size)
                new Exception("Matrix don't have the same size");
            if (this.size != matrix.size)
                new Exception("Impossible Multiplication Operation");

            Matrix return_matrix = new Matrix(this.size);
            double[] line_temp,col_temp;
            for (int line = 0; line < this.size; line++)
            {
                line_temp = this.getLine(line);
                for (int i = 0; i < this.size; i++)
                {
                    col_temp = matrix.getColumn(i);
                    for (int col = 0; col < this.size; col++)
                    {
                        return_matrix.values[i, col] += line_temp[i] * col_temp[col];
                    }
                }
            }
            return return_matrix;
        }
        public static double determinant(double[,] a, int size)
        {
            int i, j;
            double d, e, aux;
            if (size == 1)
                return a[0, 0];
            else
            {
                d = 0;
                for (j = 0; j < size; j++)
                {
                    if (((size - 1 - j) % 2 == 1) || (j == size - 1))
                        e = a[size - 1, j];
                    else
                        e = -a[size - 1, j];
                    for (i = 0; i < size - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, size - 1];
                        a[i, size - 1] = aux;
                    }
                    if ((size - 1 + j) % 2 == 0)
                        d += e * determinant(a, size - 1);
                    else
                        d -= e * determinant(a, size - 1);

                    for (i = 0; i < size - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, size - 1];
                        a[i, size - 1] = aux;
                    }
                }
                return d;
            }
        }
        public Matrix reverse()
        {
            double d = determinant(this.values, this.size);
            Matrix rez = new Matrix(this.size);
            if (d == 0)
            {
                Console.WriteLine("Determinant equal to 0");
                return rez;
            }
            double semn,aux;
            Matrix temp = new Matrix(this.size);
            for (int i = 0; i < this.size; i++)
                for (int j = 0; j < this.size; j++)
                    temp.values[i, j] = this.values[j, i];
            for (int i = 0; i < this.size; i++)
                for (int j = 0; j < this.size; j++)
                {
                    for (int k = 0; k < this.size; k++)
                    {
                        aux = temp.values[i, k];
                        temp.values[i, k] = temp.values[this.size - 1, k];
                        temp.values[this.size - 1, k] = aux;
                    }
                    for (int k = 0; k < this.size; k++)
                    {
                        aux = temp.values[k, j];
                        temp.values[k, j] = temp.values[k, this.size - 1];
                        temp.values[k, this.size - 1] = aux;
                    }
                    semn = 1;
                    if (((this.size - 1 - i) % 2 == 0) && (i != this.size - 1))
                        semn *= -1;
                    if (((this.size - 1 - j) % 2 == 0) && (j != this.size - 1))
                        semn *= -1;
                    if ((i + j) % 2 == 1)
                        semn *= -1;
                    rez.values[i, j] = semn * determinant(temp.values, this.size - 1);
                    for (int k = 0; k < this.size; k++)
                    {
                        aux = temp.values[i, k];
                        temp.values[i, k] = temp.values[this.size - 1, k];
                        temp.values[this.size - 1, k] = aux;
                    }
                    for (int k = 0; k < this.size; k++)
                    {
                        aux = temp.values[k, j];
                        temp.values[k, j] = temp.values[k, this.size - 1];
                        temp.values[k, this.size - 1] = aux;
                    }
                }
            for (int i = 0; i < this.size; i++)
                for (int j = 0; j < this.size; j++)
                    rez.values[i, j] /= d;
            return rez;
        }

        public int getSize()
        {
            return this.size;
        }
        public double[,] getValues()
        {
            return this.values;
        }

        public double[] getLine(int a)
        {
            double[] line = new double[this.size];
            for (int i = 0; i < this.size; i++)
            {
                line[i] = this.values[a, i];
            }
            return line;
        }

        public double[] getColumn(int a)
        {
            double[] line = new double[this.size];
            for (int i = 0; i < this.size; i++)
            {
                line[i] = this.values[i, a];
            }
            return line;
        }

        public void setValues(double[,] values)
        {
            this.values = values;
        }

        public void setValue(int x, int a, int b)
        {
            if (a < 0 || b < 0 || a >= this.size || b >= this.size)
            {
                new IndexOutOfRangeException($"The matrix doesn't contain those indexes! Current: L: {this.size} C: {this.size} Given: L: {a} C: {b}");
            }
            this.values[a, b] = x;
            Console.WriteLine($"Set value at ({a},{b}) to {x}");
        }

        public double getValue(int a, int b)
        {
            if (a < 0 || b < 0 || a >= this.size || b >= this.size)
            {
                new IndexOutOfRangeException($"The matrix doesn't contain those indexes! Current: L: {this.size} C: {this.size} Given: L: {a} C: {b}");
            }
            return this.values[a, b];
        }

        public void setZero()
        {
            for (int a = 0; a < this.size; a++) 
            {
                for (int b = 0; b < this.size; b++) 
                {
                    this.values[a, b] = 0;
                }
            }
        }

        public void view()
        {
            Console.WriteLine();
            double d;
            for (int a = 0; a < this.size; a++)
            {
                for (int b = 0; b < this.size; b++)
                {
                    if ((d = this.values[a, b]) % 1.00 > 0)
                        Console.Write($"{this.values[a, b].ToString("0.00")} ");
                    else
                        Console.Write($"{(int) this.values[a, b]} ");
                }
                Console.WriteLine();
            }
        }

        public Matrix clone()
        {
            Matrix matrix = new Matrix(this.size);
            matrix.values = this.values;
            return matrix;
        }
    }
}
