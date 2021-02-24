using System;
using System.IO;

namespace MyTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            try
            {
                int num = Convert.ToInt32 (Console.ReadLine());
                Console.WriteLine("Num is: " + num);
            } 
                catch (FormatException e)
                      {
                        Console.WriteLine("Format Exeption!!!");
                        //throw new FormatException ("!!! no-no-no !!!") ;
             }
            
            finally
            {
                Console.WriteLine("All done...");
            }






            Console.ReadKey();
        }
    }
}
