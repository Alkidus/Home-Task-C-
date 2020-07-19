/*Задание 2.
Разработать архитектуру классов иерархии товаров
при разработке системы управления потоками товаров для
дистрибьюторской компании.Прописать члены классов.
Создать диаграммы взаимоотношений классов.
Должны быть предусмотрены разные типы товаров,
в том числе:
• бытовая химия;
• продукты питания.
Предусмотреть классы управления потоком товаров
(пришло, реализовано, списано, передано).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task_02
{
    public abstract class Tovar
    {
        public string name;
        public int number;
        public double price;
        public Tovar (string name, int number, double price)
        {
            this.name = name;
            this.number = number;
            this.price = price;
        }
        public abstract override string ToString();
    }
    public class Chemistry : Tovar
    {
        public string category;
        public Chemistry(string name, int number, double price, string category) : base(name, number, price)
        {
            this.category = category;
        }
        public override string ToString()
        {
            return string.Format($"\nНа складе сейчас в\nКатегория товаров: {category}\nНаименование: {name}\nКоличество: {number}\nЦена: {price}\n");
        }
    }
    public class Cleaning : Chemistry
    {
        public string otdel;
        public Cleaning(string name, int number, double price, string category, string otdel) : base(name, number, price, category)
        {
            this.otdel = otdel;
        }
    }
    public class Bathroom : Cleaning
    {
        public Bathroom(string name, int number, double price, string category, string otdel) : base(name, number, price, category, otdel)
        {
        }
        public override string ToString()
        {
            return string.Format($"\nНа складе сейчас в\nКатегория товаров: {category}\nНаименование: {name}\nКоличество: {number}\nЦена: {price}\n");
        }
    }
    public class Dishes : Cleaning
    {
        public Dishes(string name, int number, double price, string category, string otdel) : base(name, number, price, category, otdel)
        {
        }
        public override string ToString()
        {
            return string.Format($"\nНа складе сейчас в\nКатегория товаров: {category}\nНаименование: {name}\nКоличество: {number}\nЦена: {price}\n");
        }
    }
    public class Foods : Tovar
    {
        public string category;
        public Foods(string name, int number, double price, string category) : base(name, number, price)
        {
            this.category = category;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    public class Alkogol : Foods
    {
        public string otdel;
        public Alkogol(string name, int number, double price, string category, string otdel) : base(name, number, price, category)
        {
            this.otdel = otdel;
        }
    }
    public class Whiskey : Alkogol
    {
        public Whiskey(string name, int number, double price, string category, string otdel) : base(name, number, price, category, otdel)
        {
        }
        public override string ToString()
        {
            return string.Format($"\nНа складе сейчас в\nКатегория товаров: {category}\nНаименование: {name}\nКоличество: {number}\nЦена: {price}\n");
        }
    }
    public class Beer : Alkogol
    {
        public Beer(string name, int number, double price, string category, string otdel) : base(name, number, price, category, otdel)
        {
        }
        public override string ToString()
        {
            return string.Format($"\nНа складе сейчас в\nКатегория товаров: {category}\nНаименование: {name}\nКоличество: {number}\nЦена: {price}\n");
        }
    }
    enum Position
    {
        Postupil, Realizovan, Spisan, Peredan
    }
    class Potok
    {
        public Tovar[] Lot;
        public Position Condition;

        public Potok(Tovar[] lot, Position condition)
        {
            Lot = lot;
            Condition = condition;
        }

        public override string ToString()
        {
            return string.Format($"\nУстановить новый статус:  {Condition}");
        }

        public void Print()
        {
            foreach (var item in Lot)
            {
                WriteLine($"Статус:  {Condition}");
                WriteLine(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tovar[] spisok =
            {
                new Beer("Чешское", 20, 19.99, "Подукты питания", "Алкоголь"),
                new Whiskey("Wild Turkey", 12, 450.99, "Подукты питания", "Алкоголь"),
                new Bathroom("Туалетный утенок", 112, 56.99, "Бытовая химия", "Чистящие средства"),
                new Dishes("Гала", 35, 44.75, "Бытовая химия", "Моющие для посуды")
            };
            Potok tovar1 = new Potok(spisok, Position.Postupil);
            tovar1.Print();
            tovar1.Condition = Position.Realizovan;
            WriteLine(tovar1.ToString());
            tovar1.Print();

            ReadKey();
        }
    }
}
