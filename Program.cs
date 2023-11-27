
using BSUIR_Lab_4_task2;

Person alex = new Person("Alex", "Poliak", "male", "11.10.1994", "000001A1");

Person nika = new Person("Nika", "Tarasova", "female", "11.12.1994", "0000SEKRET5CODE0", "BY", "Minsk", "Minsk", "Odincova", 56, 34);
Patient<string> max = new Patient<string>("Maxim", "Smirnov","male", "11.11.1996", "9999SEKRET33CODE", "BY", "Minsk", "Minsk", "Odoevskogo", 34,12);
Doctor<string> vika = new Doctor<string>("Vika", "Glyshko", "female", "10.10.1998", "111SEKRET888CODE", "BY", "Grodno", "Grodno", "Masherova", 56, 73);

Console.WriteLine(nika.GetIdentificationNumber()); // Вирутальный метод
Console.WriteLine(max.GetIdentificationNumber()); // Переопредленный метод
Console.WriteLine(vika.GetIdentificationNumber()); // Скрытие метода