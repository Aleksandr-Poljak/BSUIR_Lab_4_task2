using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_4_task2
{
    internal abstract class BasePerson
    {
        // Абстрактный класс персоны.
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract string Gender { get; set; }
        public abstract int Age { get; }
        public virtual string IdentificationNumber { get; set; } = "Unknown";
        public abstract DateOnly Birthday { get; set; }

        public BasePerson() 
        {
            Name = "Unknown";
            Surname = "Unknown";
            Gender = "male";
            Birthday = new DateOnly(1901, 01, 01);
        }

        // Метод в абстракном классе с реализацией, согласно условию.
        public virtual bool IsAdult()
        {
            return Age >= 18;
        }
        // Вирутальный ,абстрактный ,переопределенный методы в абстрактном классе.
        public virtual string Info()
        {
            string str = $"Имя: {Name}\nФамилия: {Surname}\nПол: {Gender}\n" +
                $"Дата рождения: {Birthday.ToShortDateString()}\nТекущий возраст {Age}\n";
            return str;
        }
        public abstract bool ChekIndtNumber(string indtNumber);
        public abstract override string ToString();
    }
}
