using Lab1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    internal class Cat : Animal, IVoice
    {
        public override void Move()
        {
            Console.WriteLine("Cat move");
        }

        public override void Eat()
        {
            base.Eat();

            Console.WriteLine("cat eat second time");
        }
    }
}
