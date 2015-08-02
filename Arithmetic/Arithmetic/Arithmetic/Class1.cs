using System;
/*
 * Класс арифметических операций
 */
namespace Arithmetic
{
    public static class Arithmetic
    {
        public static dynamic sum(dynamic a, dynamic b)
        {
            return a + b;
        }
        public static dynamic subtr(dynamic a, dynamic b)
        {
            return a - b;
        }
        public static dynamic multipl(dynamic a, dynamic b)
        {
            return a * b;
        }
        public static dynamic div(dynamic a, dynamic b)
        {
            return a / b;
        }
        public static dynamic logf(dynamic a, dynamic b)
        {
            return Math.Log(a) / Math.Log(b);
        }
        public static dynamic abs(dynamic a)
        {
            return Math.Abs(a);
        }
        public static dynamic degree(dynamic a, dynamic b)
        {
            return Math.Pow(a, b);
        }
        public static dynamic root(dynamic a, dynamic b)
        {
            return Math.Pow(a, 1 / b);
        }
        public static dynamic rem(dynamic a, dynamic b)
        {
            return a % b;
        }
        public static dynamic per(dynamic a, dynamic b)
        {
            dynamic c = a / 100.0;
            return b / c;
        }
    }
}