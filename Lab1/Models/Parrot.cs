using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    internal class Parrot : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Parrot move");
        }
    }
}
