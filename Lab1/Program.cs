using Lab1.Models;
using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassActivator.Activate<Cat>();
            ClassActivator.Activate<Parrot>();

            var cat = new Cat();

            cat.Children.Add(new Parrot());
            cat.Children.First().Die();
            cat.Children.First().DisplayInfo();

            Console.ReadLine();
        }
    }
}
