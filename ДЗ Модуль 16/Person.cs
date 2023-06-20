using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ДЗ_Модуль_16
{
    internal class Person
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Email;
        public string Phone;

        

        public static List<Person> GetList() 
        {
            string firstNames = "Александр, Алексей, Анатолий, Андрей, Антон, Аркадий, Арсений, Артём, Артур, Борис, Вадим, Валентин, Валерий, Василий, Виктор, Виталий, Владимир, Владислав, Вячеслав, Георгий, Глеб, Григорий, Даниил, Денис, Дмитрий, Евгений, Егор, Иван, Игорь, Илья, Кирилл, Константин, Лев, Леонид, Максим, Марк, Матвей, Михаил, Никита, Николай, Олег, Павел, Пётр, Роман, Руслан, Сергей, Степан, Тимур, Фёдор, Юрий, Ярослав";
            string lastNames = "Иванов, Смирнов, Кузнецов, Попов, Васильев, Петров, Соколов, Михайлов, Новиков, Федоров";
            string middleNames = "Иванович, Александрович, Сергеевич, Петрович, Николаевич, Владимирович, Дмитриевич, Андреевич, Анатольевич, Михайлович";
            string emails = "Ivanov, Smirnov, Kuznetsov, Popov, Vasilyev, Petrov, Sokolov, Mikhaylov, Novikov, Fedorov";
            Random random = new Random();


            string[] FirstNames = GetArray(firstNames);
            string[] LastNames = GetArray(lastNames);
            string[] MiddleNames = GetArray(middleNames);
            string[] Emails = GetArray(emails);
            

            List<Person> fillerList = new List<Person>();
            string noRepeats ="";

            for (int i = 0; i < 100; i++)
            { 
                Person filler = new Person();
                filler.FirstName = FirstNames[random.Next(FirstNames.Length)];
                filler.LastName = LastNames[random.Next(LastNames.Length)];
                filler.MiddleName = MiddleNames[random.Next(MiddleNames.Length)];
                filler.Email = Emails[random.Next(Emails.Length)];

                while (noRepeats.Contains(filler.Email))
                {
                    filler.Email += "1";
                }
                noRepeats += filler.Email;

                filler.Email += "@mail.ru";
                
                filler.Phone = $"89";
                for (int j = 0; j <= 8; j++)
                {
                    filler.Phone += $"{random.Next(10)}";
                }
                

                fillerList.Add(filler);
            }

            return fillerList;
        }

        private static string[] GetArray(string str) 
        {
            str = str.Trim(' ');
            string[] arr = str.Split(',');
            return arr;
        }
    }
}
