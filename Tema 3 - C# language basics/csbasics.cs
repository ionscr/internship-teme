using System;
using System.Collections;

namespace ConsoleApp1
{
    public abstract class shape
    {
        public string Name { set; get; }
        public abstract double area();

    }
    public class Square: shape
    {
        protected double l { set; get; }
        public override double area()
        {
            return this.l * this.l;
        }
    }
    public class Rectangle: square, IEnumerable, ICloneable
    {
        private double L { set; get; }
        public override double area()
        {
            return this.l * this.L;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public rectangleEnum GetEnumerator()
        {
            return new rectangleEnum();
        }

        public object Clone()
        {
            rectangle r1 = this;
            return r1;
        }
    }
    public class RectangleEnum: IEnumerator
    {
        private int position = -1;

        object IEnumerator.Current { get { return null; } }

        bool IEnumerator.MoveNext()
        {
            position++;
            return true;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
