﻿using System;
using Stos;


namespace ConsoleAppStos

{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            
                s.Push("km");
                s.Push("aa");
                s.Push("xx");
                
            
            
            foreach (var x in s.ToArray())
                Console.WriteLine(x);

            Console.WriteLine(s[1]);

            Console.WriteLine();
        }
    }
}
