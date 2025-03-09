using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SortedPhoneBook
{
    internal class Program
    {
        public class Contact // модель класса
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
        static void Main()
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Игорь", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Char.IsDigit(input))
                {
                    Console.WriteLine("Ошибка ввода, введите число от 1 до 3");
                }
                else
                {
                    IEnumerable<Contact> page = null;
                    switch (input)
                    {
                        case '1':
                            page = phoneBook.Take(2).OrderBy(s => s.Name).ThenBy(s => s.LastName);
                            break;
                        case '2':
                            page = phoneBook.Skip(2).Take(2).OrderBy(s => s.Name).ThenBy(s => s.LastName);
                            break;
                        case '3':
                            page = phoneBook.Skip(4).Take(2).OrderBy(s => s.Name).ThenBy(s => s.LastName);
                            break;
                    }
                    if (page == null)
                    {
                        Console.WriteLine("Данной страницы не существует");
                        continue;
                    }
                    foreach (var p in page)
                    {
                        Console.WriteLine(p.Name + " " + p.LastName + " " + p.Email + " " + p.PhoneNumber);
                    }
                }
            }
        }
    }
}
