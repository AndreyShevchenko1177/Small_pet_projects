using System;
using System.Collections.Generic;

namespace My_First_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] massiv = new int[20];
            var rand = new Random();
            for (int i = 0; i < massiv.Length; i++) {
                massiv[i] = rand.Next(10, 21);
                Console.Write("{0,5}", massiv[i].ToString() + ',');
            }

            string[] stroki = new string[3] {
                "Tom", "Jery", "Dog"
            };

            Console.WriteLine();
            foreach (string odnastroka in stroki) {
                Console.Write(odnastroka + "   ");

            }

            Console.WriteLine();
            List<int> numbers = new List<int>();
            numbers.Add(11);
            numbers.Add(22);
            numbers.Add(33);
            foreach (int i in numbers) {
                Console.Write(i + ",  ");
            }

            numbers.RemoveAt(1);
            Console.WriteLine();

            for (int i = 0; i < numbers.Count; i++)
                Console.Write(numbers[i] + ",  ");

            char[] nameofcoll = new char[8] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};

            string[,] chess = new string[8, 8];
            for (int rnk = 0; rnk < chess.Rank-1; rnk++)
            {
                for (int i = 0; i <= chess.GetUpperBound(rnk); i++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < chess.GetUpperBound(rnk+1) + 1; k++)
                    {
                        chess[i, k] = nameofcoll[i].ToString() + "-" + (k + 1).ToString();
                        Console.Write("   " + chess[i, k]);
                    }
                }
            }
            
            
            
            
            
            
            
            Console.ReadKey();
        }
    }
}
