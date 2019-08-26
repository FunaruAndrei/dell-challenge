using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();

    }

    public interface IFlyingSpecies {
        void Fly();
    }

    public interface ISwimmingSpecies {
        void Swim();
    }

    public class Species:ISpecies
    {
        public virtual void Drink() {

            Console.WriteLine("Drink");

        }

        public virtual void Eat() {

            Console.WriteLine("Eat");

        }
    }

    public class FlyingSpecies : Species, IFlyingSpecies
    {
        public virtual void Fly()
        {
            Console.WriteLine("Fly");
        }
    }

    public class SwimmingSpecies : Species, ISwimmingSpecies
    {
        public virtual void Swim()
        {
            Console.WriteLine("Swimming");
        }
    }

    public class Human : Species, IFlyingSpecies, ISwimmingSpecies
    {
        public override void Eat()
        {
            Console.WriteLine("Eat like a human");
        }

        public void Fly()
        {
            Console.WriteLine("Fly with an airplane");
        }

        public void Swim()
        {
            Console.WriteLine("Swim with a life jacket for safety!");
        }
    }

    public class Bird : FlyingSpecies
    {
        
    }

    public class Fish : SwimmingSpecies
    {
    }
}

