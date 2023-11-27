using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_4_task2
{
    // Расширающий класс персоны.
    internal class Patient <D> : Person where D : class // необходимое ограничение для работы операторв сравнения в методе RemoveDiagnose.
    {
        private D[] diagnoses = new D[0];

        public Patient() : base() { }
        public Patient(string name, string surname, string gender, string birthday, string indtNumber)
            : base(name, surname, gender, birthday, indtNumber ) { }
        public Patient(string name, string surname, string gender, string birthday, string indtNumber,
               string country, string city, string region, string street, int house, int flat)
            :base(name, surname, gender,birthday,indtNumber,country, city, region, street, house, flat) { }

        public void AddDiagnose(D new_diagnose)
        {
            // Добалвяет диагноз в массив.
            diagnoses = diagnoses.Append(new_diagnose).ToArray();
        }
        public void AddDiagnoses(params D[] new_diagnoses)
        {
            // Добавляет диагнозы в массив.
            foreach(D new_diagnose in new_diagnoses) 
            { 
                if (!diagnoses.Contains(new_diagnose))
                {
                    AddDiagnose(new_diagnose);
                }

            }
        }
        public D? RemoveDiagnose(D rem_diagnose)
        {
            // Удалить диагноз из массива
            D[] bufferDiagnoses = new D[diagnoses.Length-1];
            int IndexBufferDiagnoses = 0;

            if (diagnoses.Contains(rem_diagnose))
            {
                foreach(D diagnose in diagnoses)
                {
                    if (diagnose != rem_diagnose)
                    {
                        bufferDiagnoses[IndexBufferDiagnoses] = diagnose;
                        IndexBufferDiagnoses++;
                    }
                }
                diagnoses = bufferDiagnoses;
                return rem_diagnose;
            }
            else
            {
                return null;
            }
            
        }

        //Метод ,который переопределяется, согласно заданию
        public override string GetIdentificationNumber()
        {
            // Метод возвращает идентификационный номер с скрытыми на 60% символами.
            const int hidingLevel = 60;

            string indNumber = base.GetIdentificationNumber();

            char[] indNumberArr = indNumber.ToCharArray();
            int hideNumber = indNumber.Length * hidingLevel / 100;

            int indexHide = 0;
            for(int i = 0; i< indNumberArr.Length && indexHide<=hideNumber; i++, indexHide++)
            {
                indNumberArr[i] = '*';
            }

            return new string(indNumberArr);
        }
    }
}
