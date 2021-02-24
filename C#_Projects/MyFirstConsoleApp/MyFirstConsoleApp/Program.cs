using System;
using System.Linq;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n\nIt's my first project on C# ;)\n\nPress Any Key...\n\n");
            Console.ReadKey();
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.WriteLine("Let's count some simple example...\n\n");
            bool tf = true;
            int num_2=0, num_1=0;
            while (tf)
            {
                Console.Write("\n\n");
                bool goodnumber = true;
                
                do
                {
                    Console.Write("Input first number: ");
                    try
                    {
                        num_1 = Convert.ToInt32(Console.ReadLine());
                        goodnumber = true;
                    }
                    catch (Exception)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop-1);
                        Console.WriteLine("                                    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        goodnumber = false;
                    }
                } while (!goodnumber);


                do
                {
                    Console.Write("Input second number: ");
                    try
                    {
                        num_2 = Convert.ToInt32(Console.ReadLine());
                        goodnumber = true;
                    }
                    catch (Exception)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop-1);
                        Console.WriteLine("                                    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        goodnumber = false;
                    }
                } while (!goodnumber);




                Console.WriteLine("The addition result is:  " + (num_1 + num_2).ToString()+"\n\n");
                string answer = "";
                do
                {
                    Console.SetCursorPosition (0, Console.CursorTop);
                    Console.Write("                                             ");
                    Console.SetCursorPosition (0, Console.CursorTop);
                    Console.Write("Another one ? (Y / N) : ");
                    answer = (Console.ReadLine().ToUpper());
                    Console.SetCursorPosition(0, Console.CursorTop-1);

                } while ((answer != "N") && (answer != "Y"));
                Console.WriteLine("\n\n");
                tf = (answer == "N") ? false :  true;
            }
            Console.WriteLine("\n\nGood Bye...");
            Console.ReadKey();
        }
    }
}