using System;
/*
 * Класс арифметических операций
 */
namespace Arithmetic
{
    public class Arithmetic
    {
        private dynamic a;
        private dynamic b;
        public Arithmetic(dynamic a, dynamic b)
        {
            this.a = a;
            this.b = b;
        }
        public Arithmetic(dynamic a)
        {
            this.a = a;
        }
        public dynamic sum()
        {
            return a + b;
        }
        public dynamic subtr()
        {
            return a - b;
        }
        public dynamic multipl()
        {
            return a * b;
        }
        public dynamic div()
        {
            return a / b;
        }
        public dynamic logf()
        {
            return Math.Log(a) / Math.Log(b);
        }
        public dynamic abs()
        {
            return Math.Abs(a);
        }
        public dynamic degree()
        {
            return Math.Pow(a, b);
        }
        public dynamic root()
        {
            return Math.Pow(a, 1 / b);
        }
        public dynamic rem()
        {
            return a % b;
        }
        public dynamic per()
        {
            dynamic c = a / 100.0;
            return b / c;
        }
    }
}