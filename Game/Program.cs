using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class Program
    {
        static void ErrorParity()
        {
            Console.WriteLine("The number of arguments must be odd");
            Environment.Exit(0);
        }
        static void ErrorOfOne()
        {
            Console.WriteLine("The number of arguments cannot be 1");            
            Environment.Exit(0);
        }
        static void ErrorOfNull()
        {
            Console.WriteLine("The number of arguments cannot be 0");            
            Environment.Exit(0);
        }
        static void ErrorOfRepeat()
        {
            Console.WriteLine("Arguments must not be repeated");            
            Environment.Exit(0);
        }
        static string CheckNumberOfArguments(string[] args)
        {
            if(args.Length == 1 )
            {
                ErrorOfOne();}
            else if(args.Length == 0) {
                        ErrorOfNull();
                    }
            else if ((args.Length % 2) == 0){
                    ErrorParity();
                    }
            
            return null;
        }
        static string CheckRepeat(string[] args)
        {
            if (args.Distinct().Count() != args.Length)
                ErrorOfNull();
                
            return null;
        }
        public static void Main(string[] args)
        {
            Console.Clear();

            CheckNumberOfArguments(args);
            CheckRepeat(args);
            ArtificiaLintelligence artificiaLintelligence = new ArtificiaLintelligence(args);
            
            Console.ReadKey();
        }

    }
}
