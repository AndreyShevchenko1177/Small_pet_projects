using System;

namespace MyFirstMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                writeHi(i.ToString() + " Hello World");
            }

            Console.WriteLine("\n\n");
            int[] nums = new int [2];
            for (int i=1; i<=2; i++)
            {
                Console.Write("Input number " + i+":  ");
                nums[i - 1] = Convert.ToInt32 (Console.ReadLine());
            }
                        
            writeHi("Rusult of adding: " + AddMyMethod(nums[0], nums[1]));
           


            Console.ReadKey();
        }


        static void writeHi(string strokanaekran)
        {
            Console.WriteLine(strokanaekran);
        }

        static int AddMyMethod (int k1, int k2)
        {
            return k1+k2;
        }


    }
}
