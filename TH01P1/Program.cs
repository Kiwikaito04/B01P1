using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH01P1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Bai1();
            //Bai2a3();
            //Bai4();
            //Bai5();
            //Bai6();
            //Bai7();
        }

        private static void Bai7()
        {
            var fi = new StreamReader("Input");
            int[,] Arr;
            TH01P1.Bai7.Input(fi, out Arr);
            fi.Close();
            TH01P1.Bai7.cauA(Arr);
            TH01P1.Bai7.cauB(Arr);
            TH01P1.Bai7.cauC(Arr);
        }

        private static void Bai6()
        {
            int[,] Arr;
            int k = TH01P1.Bai6.Input(out Arr);
            TH01P1.Bai6.Output(Arr);
            Console.WriteLine();

            TH01P1.Bai6.CauA(Arr, k);
            TH01P1.Bai6.Output(Arr);
            Console.WriteLine();

            TH01P1.Bai6.CauB(Arr, k);
            TH01P1.Bai6.Output(Arr);
            Console.WriteLine();

            TH01P1.Bai6.CauD(Arr, k);
            Console.WriteLine();
        }

        private static void Bai5()
        {
            int[,] Arr;
            int k = TH01P1.Bai5.Input(out Arr);
            Console.WriteLine(TH01P1.Bai5.CauA(k, Arr));
            Console.WriteLine(TH01P1.Bai5.CauB(k, Arr));
            TH01P1.Bai5.CauC(k, Arr);
        }

        private static void Bai4()
        {
            var fi = new StreamReader("Input");
            string[] st = fi.ReadLine().Split();
            int m = int.Parse(st[0]), n = int.Parse(st[1]), k = int.Parse(st[2]);
            var arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                st = fi.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(st[j]);
                }
            }
            fi.Close();
            Console.WriteLine($"Sum row {k} = {SumRowK(arr, k)}");
            Console.WriteLine($"Sum column {k} = {SumColumnK(arr, k)}");
            Console.WriteLine($"Sum array = {SumArr(arr)}");
            Console.WriteLine($"Sum even(chan) = {SumEven(arr)}");
            Console.WriteLine($"Sum odd(le) = {SumOdd(arr)}");
            Console.WriteLine($"Sum average = {SumAvg(arr)}");
        }

        private static void Bai2a3()
        {
            var fi = new StreamReader("Input");
            string[] st = fi.ReadLine().Split();
            int m = int.Parse(st[0]), n = int.Parse(st[1]), k = int.Parse(st[2]);
            var arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                st = fi.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(st[j]);
                }
            }
            fi.Close();

            var fo2 = new StreamWriter("Output2");
            if (k >= 0 && k < n)
                for (int j = 0; j < n; j++)
                    fo2.Write($"{arr[k, j]} ");
            else fo2.Write("Invalid k");
            fo2.Close();

            var fo3 = new StreamWriter("Output3");
            if (k >= 0 && k < m)
                for (int i = 0; i < m; i++)
                    fo3.WriteLine($"{arr[i, k]} ");
            else fo3.Write("Invalid k");
            fo3.Close();
        }
        private static void Bai1()
        {
            Console.WriteLine("Nhap mang a:");
            int[,] a;
            NhapMang1(out a);
            Console.WriteLine("Mang a vua nhap:");
            XuatMang(a);
            Console.WriteLine("Nhap mang b:");
            int[,] b;
            b = NhapMang2();
            Console.WriteLine("Nhap b vua nhap:");
            XuatMang(b);
            Console.WriteLine("Nhap mang c:");
            int m, n;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            int[,] c = new int[m, n];
            NhapMang3(ref c);
            Console.WriteLine("Mang c vừa nhập:");
            XuatMang(c);
        }
        static double SumAvg(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j];

            return (double)sum / arr.Length;
        }
        static int SumOdd(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] % 2 != 0)
                        sum += arr[i, j];
            return sum;
        }
        static int SumEven(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] % 2 == 0)
                        sum += arr[i, j];
            return sum;
        }
        static int SumArr(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j];
            return sum;
        }
        static int SumColumnK(int[,] arr, int k)
        {
            int sum = 0;
            if (k >= 0 && k < arr.GetLength(0))
                for (int i = 0; i < arr.GetLength(0); i++)
                    sum += arr[i, k];
            else Console.Write("Invalid k");
            return sum;
        }
        static int SumRowK(int[,] arr, int k)
        {
            int sum = 0;
            if (k >= 0 && k < arr.GetLength(1))
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[k, j];
            else Console.Write("Invalid k");
            return sum;
        }
        static void NhapMang1(out int[,] arr)
        {
            Console.Write("Input array A row: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Input array A column: ");
            int n = int.Parse(Console.ReadLine());
            arr = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Input Arr[{i},{j}]= ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
        }
        static int[,] NhapMang2()
        {
            Console.Write("Input array B row: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Input array B column: ");
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Input Arr[{i},{j}]= ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            return arr;
        }
        static void NhapMang3(ref int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Input Arr[{i},{j}]= ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
        }
        static void XuatMang(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write($"{arr[i, j]} ");
                Console.WriteLine();
            }
        }
    

    }
    class Bai5
    {
        public static int Input(out int[,] Arr)
        {
            var fi = new StreamReader("Input");
            string[] st = fi.ReadLine().Split();
            int m = int.Parse(st[0]), n = int.Parse(st[1]);
            Arr = new int[m, n];
            int k = int.Parse(st[2]);
            for(int i=0;i<m;i++)
            {
                st = fi.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    Arr[i, j] = int.Parse(st[j]);
            }
            fi.Close();
            return k;
        }
        public static int CauA(int k,int[,] Arr)
        {
            int max = Arr[k, 0];
            for (int i = 0; i < Arr.GetLength(1); i++)
                if (max < Arr[k, i])
                    max = Arr[k, i];
            return max;
        }
        public static int CauB(int k, int[,] Arr)
        {
            int min = Arr[0, k];
            for (int i = 0; i < Arr.GetLength(0); i++)
                if (min > Arr[i, k])
                    min = Arr[i, k];
            return min;
        }
        public static void CauC(int k, int[,] Arr)
        {
            for (int i = 0; i < Arr.GetLength(0); i++)
                for (int j = 0; j < Arr.GetLength(1); j++)
                    if(checkprime(Arr[i,j]))
                        Console.Write(Arr[i,j] + " ");
            Console.WriteLine();
        }
        static bool checkprime(int a)
        {
            for (int z = 2; z <= Math.Sqrt(a); z++)
                if (a % z == 0)
                    return false;
            return true;

        }
    }
    class Bai6
    {
        public static int Input(out int[,] Arr)
        {
            var fi = new StreamReader("Input");
            string[] st = fi.ReadLine().Split();
            int m = int.Parse(st[0]), n = int.Parse(st[1]);
            Arr = new int[m, n];
            int k = int.Parse(st[2]);
            for (int i = 0; i < m; i++)
            {
                st = fi.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    Arr[i, j] = int.Parse(st[j]);
            }
            fi.Close();
            return k;
        }
        public static void Output(int[,] Arr)
        {
            for(int i=0;i<Arr.GetLength(0);i++)
            {
                for(int j=0;j<Arr.GetLength(1);j++)
                    Console.Write(Arr[i,j]+" ");
                Console.WriteLine();
            }
        }
        public static void CauA(int[,] Arr,int k)
        {
            for(int i=0;i<=Arr.GetLength(1)-1-1;i++)
                for(int j=i+1;j<Arr.GetLength(1);j++)
                    if(Arr[k,i]>Arr[k,j])
                    {
                        int temp = Arr[k, i];
                        Arr[k, i] = Arr[k, j];
                        Arr[k, j] = temp;
                    }
        }
        public static void CauB(int[,] Arr, int k)
        {
            for (int i = 0; i <= Arr.GetLength(0) - 1 - 1; i++)
                for (int j = i + 1; j < Arr.GetLength(0); j++)
                    if (Arr[i,k] < Arr[j,k])
                    {
                        int temp = Arr[i,k];
                        Arr[i,k] = Arr[j,k];
                        Arr[j,k] = temp;
                    }
        }

        public static void CauD(int[,] Arr, int k)
        {
            int[] sum = new int[Arr.GetLength(0)];
            for (int i = 0; i < Arr.GetLength(0); i++)
                for (int j = 0; j < Arr.GetLength(1); j++)
                    sum[i] += Arr[i, j];
            int[] point = new int[Arr.GetLength(0)];
            for (int i = 0; i < Arr.GetLength(0); i++)
                point[i] = i;
            for(int i=0;i<=sum.Length-1-1;i++)
                for(int j=i+1;j<sum.Length;j++)
                    if(sum[i]>sum[j])
                    {
                        int temp = sum[i];
                        sum[i] = sum[j];
                        sum[j] = temp;
                        temp = point[i];
                        point[i] = point[j];
                        point[j] = temp;
                    }
            for (int i = 0; i < sum.Length; i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                    Console.Write(Arr[point[i],j] +" "); ;
                Console.WriteLine();
            }

        }
    }
    class Bai7
    {
        public static void cauC(int[,] Arr)
        {
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = i; j < Arr.GetLength(0); j++)
                    Console.Write($"{Arr[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void cauB(int[,] Arr)
        {

            for (int i = 0; i < Arr.GetLength(0); i++)
                Console.Write($"{Arr[i, Arr.GetLength(0)-i-1]} ");
            Console.WriteLine();
        }
        public static void cauA(int[,] Arr)
        {
            for(int i=0;i<Arr.GetLength(0);i++)
                Console.Write($"{Arr[i,i]} ");
            Console.WriteLine();
        }
        public static void Input(StreamReader f,out int[,] Arr)
        {
            string[] st;
            int n = int.Parse(f.ReadLine());
            Arr = new int[n, n];
            for(int i=0;i<n;i++)
            {
                st = f.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    Arr[i, j] = int.Parse(st[j]);
            }
        }
    }
}
