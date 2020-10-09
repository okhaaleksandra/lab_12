using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Person> myCol_1 = new MyCollection<Person>();
            myCol_1.ShowCollection();
            Console.WriteLine("Попробуем удалить:");
            myCol_1.Remove(myCol_1[0]);

            Console.WriteLine("Добавим элементы типа Person и Employee:");
            myCol_1.Add(new Person());
            myCol_1.Add(new Person());
            myCol_1.Add(new Employee());
            myCol_1.Add(new Employee());

            SetColor.ReversedBW("\nКоллекция:");
            myCol_1.ShowCollection();


            Console.WriteLine("\nТеперь создадим коллкцию на основе List<Person>:");
            int size = 0;
            Console.WriteLine("Число элементов:");
            List<Person> people = new List<Person>();
            bool ok = Int32.TryParse(Console.ReadLine(), out size);
            if (ok)
            {
                for (int i = 0; i < size; i++)
                    people.Add(new Person());
            }
            else
                throw new Exception("Invalid input.");

            MyCollection<Person> myCol_2 = new MyCollection<Person>(people);
            SetColor.ReversedBW("Коллекция");
            myCol_2.ShowCollection();

            Employee emp = new Employee("Дроздов Н.В.", 40, "бухгалтер", "финансовый отдел");
            Console.WriteLine("\nДобавление:");
            myCol_2.Add(emp);
            SetColor.ReversedBW("\nТеперь коллекция выглядит так:");
            myCol_2.ShowCollection();

            SetColor.ReversedBW("\nПроверка работы foreach. Вывод коллекции:");
            foreach (Person p in myCol_2)
                Console.WriteLine(p);

            Console.WriteLine("\nУдалим ранее добавленный элемент и элемент на третьей позиции:");
            myCol_2.Remove(emp);
            myCol_2.Remove(myCol_2[2]);
            SetColor.ReversedBW("\nТеперь коллекция выглядит так:");
            myCol_2.ShowCollection();
            Console.WriteLine("\nПопробуем удалить уже удаленный элемент:");
            myCol_2.Remove(emp);
            Console.WriteLine("Попробуем удалить элемент с индексом -4:");
            myCol_2.Remove(myCol_2[-4]);




            Console.ReadKey();
        }

         class SetColor
        {
            public static void ReversedBW(string message)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }

    
}
