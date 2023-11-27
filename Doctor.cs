using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_4_task2
{
    // Расширающий класс персоны.
    internal sealed class Doctor<P> : Person
    {
        private P? position;
        public P? Position 
        {
            get => position;
            set => position = value;
        }

        public Doctor() : base() { }
        public Doctor(string name, string surname, string gender, string birthday, string indtNumber)
            : base(name, surname, gender, birthday, indtNumber) { }
        public Doctor(string name, string surname, string gender, string birthday, string indtNumber,
               string country, string city, string region, string street, int house, int flat)
            : base(name, surname, gender, birthday, indtNumber, country, city, region, street, house, flat) { }

        //Метод ,котрый скрывает родительский метод, согласно заданию
        public new string GetIdentificationNumber()
        {
            // Метод возвращает идентификационный номер с скрытыми на 40% символами.
            const int hidingLevel = 40;

            string indNumber = base.GetIdentificationNumber();

            char[] indNumberArr = indNumber.ToCharArray();
            int hideNumber = indNumber.Length * hidingLevel / 100;

            int indexHide = 0;
            for (int i = 0; i < indNumberArr.Length && indexHide <= hideNumber; i++, indexHide++)
            {
                indNumberArr[i] = '#';

            }
            return new string(indNumberArr);
        }
    }
}
