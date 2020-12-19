using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    public abstract class Animal
    {
        public Animal Father { get; set; }
        public Animal Mother { get; set; }
        public ICollection<Animal> Children { get; set; } = new List<Animal>();

        public bool IsDead { get; private set; }

        private static int animalId = 0;

        private int id;

        protected Animal()
        {
            id = animalId++;
        }

        public abstract void Move();

        public virtual void Eat()
        {
            Console.WriteLine("base eat");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{this.GetType().Name} ({id}). Is dead - {IsDead}");
        }

        public void Die()
        {
            IsDead = true;
        }
    }
}
