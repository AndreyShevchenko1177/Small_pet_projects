using System;

namespace MyFirstOOP
{

    class Animal
    {
        public static int count = 0;

        public string name;
        public int age;
        public float happyness;

        public Animal ()
            {
            name = "Jon Do";
            age=0;
            happyness=0f;
            count++;
            print();
            }

        public Animal(string _name, int _age, float _happ)
        {
            name = _name;
            age = _age;
            happyness = _happ;
            count++;
            print();
        }

        public void print()
        {
            Console.WriteLine("{0,10} {1,10} {2,10}", name, age, happyness);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Animal cat = new Animal("Tom",3,0.2f);
            
            Animal dog = new Animal("Dog",5,0.8f);

            Animal samsam = new Animal();

            Console.WriteLine("Summary {0} objects were created.", Animal.count);







            Console.ReadKey();
        }
    }
}
