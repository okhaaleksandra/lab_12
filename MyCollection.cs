using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_12
{
    class MyCollection <T>:IEnumerable<T> 
        where T:Person
    {
        LinkedList<T> collection = new LinkedList<T>();

        public int Count
        {
            get { return collection.Count; }
        }

        public bool Empty
        {
            get { return collection.Count == 0; }
        }

        public MyCollection() { }

        public MyCollection(ICollection<T> col)
        {
            collection = new LinkedList<T>(col);
        }


        public void ShowCollection()
        {
            int i = 1;

            if (this.Empty)
                Console.WriteLine("Коллекция пустая.");
            else              
                foreach (var x in collection)
                {
                    Console.WriteLine($"{i++}) "+ x);
                }
        }


        public void Add (T obj)
        {
            collection.AddLast(obj);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Добавлен элемент " + obj.ToString());
            Console.ResetColor();
        }

        public void Remove(T obj)
        {
            if (this.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Перед удалением необходимо добавить элементы.");
                Console.ResetColor();
            }

            else
            {
                if (collection.Contains(obj))
                {
                    collection.Remove(obj);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Удален элемент " + obj.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Такого Элемента в коллекции нет. Удаление не выполнено.");
                    Console.ResetColor();
                }
            }
        }       

        public T this[int index]
        {
            get
            {
                if (this.Empty) return null;

                if (index < 0)
                    throw new ArgumentOutOfRangeException("Index: " + index);

                if (index >= this.Count)
                    index = this.Count - 1;

                return collection.ElementAt(index);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var x in collection)
                yield return x;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
