using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_Модуль_16
{
    internal class Order
    {
        public string email;
        public string goodCode;
        public string goodName;

        public static List<Order> GetList()
        {
            string goodNames = "Яблоко, Банан, Книга, Винтовка, Мыло, Наушники, Вода, Чай, Салфетки, Телефон, Клавиатура, Крем для лица, Дезодорант, Шампунь, Перчатки, Сетевой фильтр, Коврик, Стакан, Лампа";
            
            Random random = new Random();


            string[] goodName = GetArray(goodNames);
            List<string> emails = TableFiller.GetEmails();

            List<Order> fillerList = new List<Order>();
            

            for (int i = 0; i < 1000; i++)
            {
                Order order = new Order();
                order.email = emails[random.Next(emails.Count)];
                order.goodCode = random.Next(10000).ToString();
                order.goodName = goodName[random.Next(goodName.Length)];
                fillerList.Add(order);
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
