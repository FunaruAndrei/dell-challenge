using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            //Output:
            //  A.A()
            //  B.B()
            //  A.Age
            //Considering that class B inherit class A, when it's instantiated it call the parent class
            //constructor automatically, this is why first it's printed "A.A()", after that it's executed
            //the code in the instantiated class constructor, printing out "B.B()", followed by assignment 
            //of value 0 to the Age property, that prints out "A.Age" in it's setter.
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
