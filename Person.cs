using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_4_task2
{
    // Реализация абстрактного классы персоны.
    internal class Person : BasePerson 
    {
        private TextInfo _ti = CultureInfo.CurrentCulture.TextInfo;

        private string name;
        private string surname;
        private string gender;
        private DateOnly birthday;
        private string identificationNumber;

        // Переопредление свойств базового абстрактного класса.
        public override string Name
        {
            get { return name; }
            set
            {
                name = _ti.ToTitleCase(value);
            }
        }
        public override string Surname 
        { get => surname;
          set { surname =  _ti.ToTitleCase(value); }
        }
        public override string Gender 
        {  get => gender;
           set 
            { 
                if(value == "male" || value == "female")
                {
                    gender = value;
                }
                else
                {
                    throw new Exception("Гендер должен быть male либо female");
                }
            }
        }
        public override int Age 
        { 
            
            get
            {

                TimeSpan courrentAge = DateTime.Now - new DateTime(Birthday.Year, Birthday.Month, Birthday.Day);
                int currentAgeYears = (int)(courrentAge.TotalDays / (DateTime.IsLeapYear(DateTime.Now.Year) ? 366: 365));
                return currentAgeYears;
            }
        }
        public override DateOnly Birthday 
        {  get => birthday;
           set 
            {
                if (value.Year < 1900)
                {
                    throw new Exception("Не корректная дата рождения.");
                }
                else
                {
                    birthday = value;
                }
                //Console.WriteLine(value.Year.ToString());
                //birthday = value;


            }
        }
        public new virtual string IdentificationNumber
        { get => identificationNumber;
          private set => identificationNumber = value;
        }
        // Расширение базового класса
        public virtual string Country { get; set; }
        public virtual string City {  get; set; }
        public virtual string Region { get; set; }
        public virtual string Street {  get; set; }
        public virtual int House { get; set; }
        public virtual int Flat { get; set; }

        public Person()
        {
            name = "Unknown";
            surname = "Unknown";
            gender = "male";
            Birthday = new DateOnly(1901, 01, 01);
            identificationNumber = "Unknown0000001";
            Country = "unidentified";
            City = "unidentified";
            Region = "unidentified";
            Street = "unidentified";
        }
        public Person(string name, string surname, string gender, string birthday, string indtNumber): this()
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Birthday = DateOnly.Parse(birthday);         
            IdentificationNumber = indtNumber;
        }
        public Person(string name, string surname, string gender, string birthday, string indtNumber, 
               string country, string city, string region, string street, int house, int flat) :this(name, surname, gender, birthday,indtNumber) 
        {
            SetAdress(country, city, region, street, house, flat);
        }

        public void SetAdress(string country, string city, string region, string street, int house, int flat)
        {
            Country = country;
            City = city;
            Region = region;
            Street = street;
            House = house >0 ? house: 0;
            Flat = flat >0? flat: 0;    
        }
        public virtual string GetAdress()
        {
            string adress = $"Страна: {Country}\nГород: {City}\nРегион: {Region}\nУлица: {Street}\nДом: {House}\nКвартира: {Flat}\n";
            return adress;
        }
        public override bool ChekIndtNumber(string indt)
        {
            return IdentificationNumber == indt;
        }
        public override string ToString()
        {
            string result = Info() + GetAdress();
            return result;
        }

        //Метод который нужно переопредлить в одном наследнике и скрыть в другом наслденик, согласно заданию.
        public virtual string GetIdentificationNumber()
        {
            return IdentificationNumber;
        }

    }
}
