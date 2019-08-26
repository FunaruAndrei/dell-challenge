using System;
using System.Collections.Generic;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            MyObject _myNewObject = new MyObject(1,3);
            _myNewObject.AddTheNumbers();
            _myNewObject.PrintResult();

            MyObject _myNewObject1 = new MyObject(1, 3, 5);
            _myNewObject1.AddTheNumbers();
            _myNewObject1.PrintResult();

            MyObject _myNewObject2 = new MyObject(1, 3, 5, 7, 9);
            _myNewObject2.AddTheNumbers();
            _myNewObject2.PrintResult();
            _myNewObject2.AddToExistent(11);
            _myNewObject2.PrintResult();

        }
    }

    class MyObject
    {
        private List<int> _numbers;
        private int _sum;

        public MyObject(int a, int b)
        {
            this._sum = 0;
            this._numbers = new List<int> { a, b };
        }

        public MyObject(int a, int b, int c)
        {
            this._sum = 0;
            this._numbers = new List<int> { a, b, c };
        }

        public MyObject(params int[] numbers)
        {
            this._sum = 0;
            this._numbers = new List<int>(numbers);
        }
        
        public virtual void AddToExistent(int number)
        {
            this._numbers.Add(number);
            this._sum += number;
        }

        public virtual int AddTheNumbers()
        {
            this._sum = 0;
            foreach (int num in _numbers)
                this._sum += num;

            return this._sum;
        }

        public virtual void PrintResult()
        {
            Console.WriteLine(this._sum);
        }
    }
}
