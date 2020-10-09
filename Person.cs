using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_12
{
    class Person : IComparable, ICloneable
    {
            protected static Random rnd = new Random();

            static string[] surnames = { "Юшков", "Распутина", "Филатов", "Зотова", "Сотников", "Быстрых", "Одинцова", "Белов", "Королёв", "Каменских","Кузьмин", "Кузьмина",
                                     "Макарова", "Попов", "Соловьёва","Соловьёв", "Павленко","Юшкова", "Распутин", "Филатова", "Зотов", "Сотникова", "Одинцов", "Попова",
                                     "Зотов", "Зотова", "Морозов", "Морозова", "Ким", "Бондарев", "Бондарева", "Петров", "Петрова", "Сорокина","Сорокин", "Шмидт"};
            static string[] inits = { "Р.В.", "И.А.", "В.П.", "Т.А.", "А.Д.", "Н.С.", "М.В.", "Ф.М.", "А.А.", "К.Д.", "Т.М.", "П.И.", "А.В.", "Е.С.", "К.В.", "К.Ф.",
                                  "А.В.", "И.Д.", "К.П.", "Т.Р.", "П.Д.", "Н.Н.", "М.С.", "Е.М.", "Е.Е.", "К.К.", "Т.Т.", "П.ИП", "В.В.", "С.С.", "Б.В.", "О.В."};

            protected int age;

            public string Name { get; set; }

            public int Age
            {
                get { return age; }
                set
                {
                    if (value >= 0)
                        age = value;
                    else
                    {
                        Console.WriteLine($"Error. Invalid input (age cannot be {value}).");
                        age = 0;
                    }
                }
            }

            public Person(string nm, int a)
            {
                Name = nm;
                Age = a;
            }

            public Person()
            {
                Name = RandomName();
                Age = rnd.Next(15, 70);
            }

            public string RandomName()
            {
                return (surnames[rnd.Next(surnames.Length)]) + " " + (inits[rnd.Next(inits.Length)]);
            }

            public virtual void Show()
            {
                Console.WriteLine($"ФИО: {Name} возраст: {Age}\n");
            }


            public virtual int CompareTo(object obj)
            {
                return String.Compare(this.Name, ((Person)obj).Name);
            }

            public virtual int Compare(object obj1, object obj2)
            {
                Person p1 = (Person)obj1;
                Person p2 = (Person)obj2;

                if (p1.Age < p2.Age)
                    return -1;

                else if (p1.Age == p2.Age)
                    return 0;

                else
                    return 1;
            }

            public override string ToString()
            {
                return $"{Name}, {Age}";
            }

            public override bool Equals(object obj)
            {
                Person p = obj as Person;
                if (p == null) return false;
                else return (this.Name == p.Name && this.Age == p.Age);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode() + Age.GetHashCode();
            }

            public object Clone()
            {
                return new Person(this.Name, this.Age);
            }
        }
    }
