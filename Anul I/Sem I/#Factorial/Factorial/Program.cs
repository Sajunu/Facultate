﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Print(n.ToString() + "!=", Factorial(n));
            Console.ReadKey();
        }

        static void Print(string nume, int[] v)
        {
            string str = "";
            for (int i = 0; i < v.Length; i++)
                str += v[i].ToString();
            while (str[0] == '0' && str.Length > 1)
                str = str.Substring(1, str.Length - 1);
            Console.WriteLine(nume + " {0}", str);
        }

        static int[] Factorial(int n)
        {
            int[] v = { 1 };
            if (n == 1 || n == 2) return v;
            for (int i = 2; i <= n; i++)
            {
                int[] x = ntov(i);
                v = Times(v, x);
            }
            return v;
        }

        static int[] ntov (int n)
        {
            int x = n, k = 0;
            while (x>0)
            {
                x /= 10;
                k++;
            }
            int[] v = new int[k];
            x = n;
            for (int i=k-1; i>=0; i--)
            {
                v[i] = x % 10;
                x /= 10;
            }
            return v;
        }

        static int[] Times(int[] a, int[] b)
        {
            a = Inv(a);
            b = Inv(b);
            if (b.Length > a.Length)
            {
                int[] t = a;
                a = b;
                b = t;
            }
            int max = a.Length, min = b.Length;
            int[] v = new int[max + min];
            string k;
            for (int i = 0; i < min; i++)
            {
                int[] x = new int[max + 1];
                for (int j = 0; j < max; j++)
                    x[j] = b[i] * a[j];
                for (int j = 0; j < x.Length; j++)
                    if (x[j] > 9)
                    {
                        x[j + 1] += x[j] / 10;
                        x[j] = x[j] % 10;
                    }
                int[] c = new int[i];
                k = Concat(c) + Concat(x);
                int[] y = new int[k.Length];
                for (int j = 0; j < k.Length; j++)
                {
                    y[j] = int.Parse(k[j].ToString());
                }
                v = Add(v, Inv(y));
            }
            return v;
        }

        static int[] Inv(int[] v)
        {
            for (int i = 0; i < v.Length / 2; i++)
            {
                int t = v[i];
                v[i] = v[v.Length - 1 - i];
                v[v.Length - 1 - i] = t;
            }
            return v;
        }

        static string Concat(int[] x)
        {
            string k = "";
            for (int i = 0; i < x.Length; i++)
                k += x[i].ToString();
            return k;
        }

        static int[] Add(int[] v1, int[] v2)
        {
            v1 = Inv(v1);
            v2 = Inv(v2);
            int min = v1.Length;
            if (v2.Length < min) min = v2.Length;
            int max = v1.Length;
            if (v2.Length > max) max = v2.Length;
            int[] v = new int[max + 1];
            for (int i = 0; i < min; i++)
                v[i] = v1[i] + v2[i];
            for (int i = v1.Length; i < max; i++)
                v[i] = v2[i];
            for (int i = v2.Length; i < max; i++)
                v[i] = v1[i];
            for (int i = 0; i <= max; i++)
                if (v[i] > 9)
                {
                    v[i] %= 10;
                    v[i + 1]++;
                }
            Inv(v);
            return v;
        }
    }
}
