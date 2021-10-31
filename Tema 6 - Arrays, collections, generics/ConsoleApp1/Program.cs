using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericArray<string> S = new GenericArray<string>();
            S.SetItem("asd", 1);
            Console.WriteLine(S.GetItem(1));
            S.SetItem("fgh", 2);
            S.SwapItemsByIndex(1, 2);
            Console.WriteLine(S.GetItem(1));
            S.SwapItems("asd", "fgh");
            Console.WriteLine(S.GetItem(1));
            
        }
    }
}
