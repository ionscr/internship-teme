using System;

namespace ConsoleApp1
{
    public class CustomException : Exception
    {
        public CustomException() {}
        public CustomException(string message): base(message) { }
    }
    class Program
    {
        public double div(double x1, double x2)
        {
            try { 
                if (x1 == 0) throw new CustomException("Impartirea din 0")  ; 
                return x1 / x2;
            }
            catch(CustomException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.ToString());
                throw;

            }
#if DEBUG
            finally
            {

                Console.WriteLine("We are in finally!");
            }
        }
#endif
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
