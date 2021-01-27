using System;
using Stos;


namespace ConsoleAppStack

{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            for (int i = 1; i < 4; i++)
            {
                s.Push("km");
                s.Push("aa");
                s.Push("xx");
            }
            Console.WriteLine(s.Capacity);
            ((StosWTablicy<string>)s).TrimExcess();
            Console.WriteLine(s.Capacity);
            //foreach (var x in s.ToArray())
            //    Console.WriteLine(x);

            Console.WriteLine();
        }
    }
}
