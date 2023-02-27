// Про класс List - https://metanit.com/sharp/tutorial/4.5.php

using System;
using System.Collections.Generic;  //Для использования List<T>
using System.Collections;//Для списков
using System.Linq;//для IEnumerable<T>

namespace Lab3
{

    class Program
    {
        //Программа тестирования, в которой проверяется использование перегруженных операций.

        static void Main(string[] args)
        {
            List<int> List1 = new List<int>();
            List1.Add(1);
            List1.Add(2);
            List1.Add(3);
            List1.Add(4);
            List1.Add(5);
            List<int> List2 = new List<int>();
            List2.Add(1);
            List2.Add(2);
            List2.Add(3);
            List2.Add(4);
            List2.Add(5);

            Console.WriteLine($"Элементы 1-го списка: ");
            foreach (var item in List1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine($"Удалён элемент 1 из 1-го списка: {List1 >> 3}");
            Console.WriteLine($"Добавлен элемент 9 в 1-й список: {9 + List1}");
            Console.WriteLine($"Не равны ли списки: {List1 != List2}");
            Console.WriteLine($"Равны ли списки: {List1 == List2}");
            Console.WriteLine($"Размер 1-го списка: {List1.Size()}");
            Console.WriteLine($"Размер 2-го списка: {List2.Size()}");
            Console.WriteLine();

            Console.WriteLine($"Элементы 1-го списка после добавления  и удаления элемента: ");
            foreach (var item in List1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Элементы 2-го списка: ");
            foreach (var item in List2)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Сумма элементов 1-го списка: {List1.Sum()}");
            Console.WriteLine($"Сумма элементов 2-го списка: {List2.Sum()}");

            Console.WriteLine($"Разница между максимальным и минимальным элементами в List1: {List1.Equ()}");
            Console.WriteLine($"Разница между максимальным и минимальным элементами в List2: {List2.Equ()}");

            Console.WriteLine($"Удалён последний элмент из 2-го списка: {List2.DelLast()}");
            Console.WriteLine($"Элементы 2-го списка после удаления последнего элемента: ");
            foreach (var item in List2)
            {
                Console.WriteLine(item);
            }

            Console.Write("Введите строку: ");
            string? input = Console.ReadLine();
            input?.Word();
        }

    }

        //------------------------------------------------------------------------------
        //Класс узла в списке List
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }



        //------------------------------------------------------------------------------
        //Класс - односвязный список List
        
        public class List<T> : IEnumerable<T>
        {
            //Вложенный класс Production
            public class Production
            {
                public int Id;
                public string? Organization_name;
            }
            //Вложенный класс Developer
            class Developer
            {
                public string? FIO;
                public int id;
                public string? otdel;
            }

            //Инициализация вложенных классов
            Production product = new Production { Id = 1, Organization_name = "BSTU" };
            Developer developer = new Developer { FIO = "Карпин Александр", id = 1, otdel = "отдел ИТ"};



            //Реализация односвязного списка List<T> : IEnumerable<T> https://metanit.com/sharp/algoritm/2.1.php


            Node<T>? head; // головной/первый элемент
            Node<T>? tail; // последний/хвостовой элемент
            public int count;  // количество элементов в списке


            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;

                count++;
            }

            // удаление элемента
            
            public bool Remove(T data)
            {
                Node<T>? current = head;
                Node<T>? previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;

                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            // если удаляется первый элемент
                            // переустанавливаем значение head
                            head = head.Next;

                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            // очистка списка
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            // содержит ли список элемент
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            // добвление в начало
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }

        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                //Console.WriteLine(current.ToString());
                Console.WriteLine("My numbers: ", String.Join(", ", current));
                current = current.Next;
            }

        }
        //- Для того, чтобы список можно было бы перебрать во внешней прграмме с помощью цикла for-each, класс списка реализует интерфейс IEnumerable:
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        //Перегрузка операторов
        //https://learn.microsoft.com/ru-Ru/dotnet/csharp/language-reference/operators/operator-overloading
        //https://translated.turbopages.org/proxy_u/en-ru.ru.a7d5dd95-633cb3c0-bcf434ec-74722d776562/https/www.c-sharpcorner.com/article/operator-overloading-in-c-sharp2/
        //https://professorweb.ru/my/csharp/charp_theory/level6/6_4.php

        //>> - удалить элемент в заданной позиции
            public static List<T> operator  >> (List<T> List, int a)
            {
                foreach(var item in List)
                {
                    if(a == Convert.ToInt32(item))
                    {
                    List.Remove(item);
                    }
                }
                return List;
            }

        // + - добавить элемент в заданную позицию(без заданной позиции, просто добавление элемента)
            public static List<T> operator +(T a, List<T> List)
            {
            List.Add(a);
            return List;
            
            }


            // != - проверка на неравенство множеств - работает в паре с перегрузкой  == 
            public static bool operator !=(List<T> List1, List<T> List2)
            {
              bool Eq = List1.Equals(List2);//.Equals сравнивает два объекта
                if (Eq == true)
                {
                    return false;
                }
                    return true;    
            }
            //перегрузка == - проверка на равенство
            public static bool operator ==(List<T> List1, List<T> List2)
            {
                bool Eq = List1.Equals(List2);
                return Eq;
            }

        }
        //------------------------------------------------------------------------------
        //Статический класс StatisticOperation
        
        static class StatisticOperation
        {
            //Метод - 1 сумма
            static public int Sum(List<int> List)
            {
            int sum = 0;
            foreach (var item in List)
            {
                sum = sum + item;
            }
            return sum;
            }

            //Метод - 2 разница между максимальным и минимальным элементами 
            static public int Equ(this List<int> List)
            {
            int differ = 0;
            int max = 0;
            int min = 999;

            //Поиск максимального элмента
            foreach (var item in List)
            {
                if(item > max)
                {
                    max = item;
                }
            }
            //Поиск минимального элемента
            foreach (var item in List)
            {
                if(item < min)
                {
                    min = item;
                }
            }
            //Получение разницы
            differ = max - min;
            //Возвращение результата
            return differ;
            }

            //Метод - 3 подсчет количества элементов
            static public int Size(this List<int> List)
            {
                return List.count;
            }

        // Методы расширения - https://metanit.com/sharp/tutorial/3.18.php
        //https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

        //Метод расширения - Поиск самого длинного слова (для типа string)
        static public void Word(this string a)
        {
            // String.Split() Возвращает строковый массив, содержащий подстроки данного экземпляра, разделенные элементами заданной строки или массива знаков Юникода.
            //                     (массив символов, разделяющих основную строку на подстроки)
            string[] str = a.Split(new Char[] { ' ', ',', '.', ':', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);
            // StringSplitOptions.RemoveEmptyEntries); Указывает параметры для применимых перегрузок метода Split, например, следует ли опускать пустые подстроки из возвращаемого массива или обрезать пробелы в подстроках.
            int maxlen = 0, index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length > maxlen)
                {
                    maxlen = str[i].Length;
                    index = i;
                }
            }
             Console.Write("Самое длинное слово: {0}", str[index]);
        }

        //Метод расширения - Удаление последнего элемента из списка(для списка List)
        static public List<int> DelLast(this List<int> List)
        {
            foreach (var item in List)
            {
                if (item == List.Last())
                {
                    List.Remove(item);
                }
            }
            return List;
        }
    }
        //------------------------------------------------------------------------------
}