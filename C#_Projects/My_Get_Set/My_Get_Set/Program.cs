using System;

namespace My_Get_Set
{

    class student 
    {
        private string name="";
        private int kurs = 0;
        private bool stepuha;

        public int KursAcsessor { get; set; } = 0;
        

        

        public student ()
        {
            name = "John Dow";
            kurs = 0;
            stepuha = false;
            PrintAll();
        }

        public student (string _name, int _kurs, bool _stepuha)
        {
            this.name = _name;
            kurs = _kurs;
            stepuha = _stepuha;
            PrintAll();
        }

        public void PrintAll()
        {
            Console.WriteLine("{0,10}{1,3}   {2,-8}\n", name, kurs, stepuha);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n\n");

            student John = new student();
            Console.WriteLine(John.KursAcsessor);
            John.KursAcsessor = 3;
            Console.WriteLine(John.KursAcsessor);

            John.PrintAll();

            student Alex = new student("Alex", 1, false);
            student Mariya = new student("Mariya",3,true);
            student Gerda = new student("Gerda", 5, true);








            Console.ReadKey();
        }
    }
}
