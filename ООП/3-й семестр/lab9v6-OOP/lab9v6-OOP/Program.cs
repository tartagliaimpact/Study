using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer<char> computer = new Computer<char>();
            computer.Add('L');
            computer.Add('s');
            computer.Add('a');
            computer.Add('i');
            computer.Add('k');
            computer.Add('r');
            computer.Add('s');//Элемент будет автоматически удалён, т.к. такой элемент уже есть
            computer.Add('t');

            computer.Print();

            computer.Remove('k');
            computer.Remove('r');

            Console.WriteLine();
            computer.Print();

            Console.WriteLine();
            bool f  = computer.Find('L');
            Console.WriteLine($"{f}");

            Console.WriteLine();

            List<char> complist = new List<char>(computer);
            Console.WriteLine(String.Join(",", complist));

            Console.WriteLine();

            Console.WriteLine();
            var find = complist.Find(x => x == 'L');
            Console.WriteLine($"{find}");

            ObservableCollection<Computer<char>> oc = new ObservableCollection<Computer<char>>();
            {
                new Computer<char> { 'a', 'g', 'h' };
                new Computer<char> { 'h', '5', 'i', 't' };
                new Computer<char> { 'g', 'b', 'v' };
            };
            oc.CollectionChanged += Computer<char>.Computers_CollectionChanged;
            oc.Add(new Computer<char> { 'd', 'c' });
            oc.Add(new Computer<char> { 'g', 'r', 't','e', 'm', 'k'}) ;
            oc.RemoveAt(1);
            oc[0] = new Computer<char> { 'a' };


        }


        public class Computer<T> : HashSet<T>, ISet<T>
        {
            private HashSet<T> Hashset = new HashSet<T>();
            public void Print()
            {
                string s = " ";
                foreach (T item in this)
                {
                    s += item;
                    s += ", ";
                }
                Console.WriteLine(s);
            }
            
            public bool Find(T item)
            {
                return Contains(item);
            }

            // - https://metanit.com/sharp/tutorial/3.11.php
            public static void Computers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        Computer<T> newComputer = e.NewItems[0] as Computer<T>;
                        Console.WriteLine($"Добавлен новый объект: {newComputer}");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        Computer<T> oldComputer = e.OldItems[0] as Computer<T>;
                        Console.WriteLine($"Удален объект: {oldComputer}");
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        Computer<T> replacedComputer = e.OldItems[0] as Computer<T>;
                        Computer<T> replacingComputer = e.NewItems[0] as Computer<T>;
                        Console.WriteLine($"Объект {replacedComputer} заменен объектом {replacingComputer}");
                        break;
                }
            }
        }
    }
}
