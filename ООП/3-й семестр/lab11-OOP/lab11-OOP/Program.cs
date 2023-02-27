using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = Reflector.Create<Book>();
            Reflector.AssemblyName(book);
            Reflector.PublicConstructors(book);
            Reflector.PublicMethods(book);
            Reflector.FieldsAndProperties(book);
            Reflector.ClassInterfaces(book);
            Reflector.MethodsByParameter(book, typeof(int));
            Reflector.Invoke(book, "ToString", null);



            Computer<int> comp = Reflector.Create<Computer<int>>();
            Reflector.AssemblyName(comp);
            Reflector.PublicConstructors(comp);
            Reflector.PublicMethods(comp);
            Reflector.FieldsAndProperties(comp);
            Reflector.ClassInterfaces(comp);
            Reflector.MethodsByParameter(comp, typeof(int));
            Reflector.Invoke(comp, "Add", new object[] {5});

            List<int> list = Reflector.Create<List<int>>();
            Reflector.AssemblyName(list);
            Reflector.PublicConstructors(list);
            Reflector.PublicMethods(list);
            Reflector.FieldsAndProperties(list);
            Reflector.ClassInterfaces(list);
            Reflector.MethodsByParameter(list, typeof(int));
            Reflector.Invoke(list, "Add", new object[] { 5 });

        }

        public partial class Book
        {
            //Объявление свойств - https://www.bestprog.net/ru/2019/07/26/c-properties-accessors-get-set-examples-of-classes-containing-properties-ru/
            static int count { get; set; }// счётчик

            private string? name { get; set; }// название
            public string? Name
            {
                get
                {
                    return name;    // возвращаем значение свойства
                }
                set
                {
                    name = value;   // устанавливаем новое значение свойства
                }
            }

            private string? author { get; set; }// автор
            public string? Author
            {
                get
                {
                    return author;
                }
                set
                {
                    author = value;
                }
            }


            private string? publish { get; set; }// издательство
            public string? Publish
            {
                get
                {
                    return publish;
                }
                set
                {
                    publish = value;
                }
            }

            private int year { get; set; }// год издания
            public int Year
            {
                get
                {
                    return year;
                }
                set
                {
                    year = value;
                }
            }


            private int num_p { get; set; }//количество страниц
            public int NumP
            {
                get
                {
                    return num_p;
                }
                set
                {
                    num_p = value;
                }
            }


            private int price { get; set; }//цена
            public int Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }


            private string? binding_type { get; set; }//тип переплёта
            public string? BindingType
            {
                get
                {
                    return binding_type;
                }
                set
                {
                    binding_type = value;
                }
            }

            private readonly int ID;//id
            public int id { get { return ID; } }  //только для чтения

            //свойство, ограниченное по set
            private int _forSet { get; set; }
            public int forSet
            {
                get
                {
                    return _forSet;
                }
                protected set //ограничение
                {
                    _forSet = value;
                }
            }


            const int number = 9999;//поле константа

            static int fcnst;//для статического конструктора
            public override string ToString()
            {
                return name.ToString();
            }
            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj is Book books) return name == books.name;
                return false;
            }


            //Конструктор с параметрами и проверкой полей
            public Book(int Id, string _Name, string _Author, string _Publish, int _Year, int _Num_p, int _Price, string _Binding_type)
            {
                if (_Num_p > 0 && _Price > 0 && _Name.Length > 3 && _Author.Length > 3)
                {
                    ID = Id;
                    Name = _Name;
                    Author = _Author;
                    Publish = _Publish;
                    Year = _Year;
                    NumP = _Num_p;
                    Price = _Price;
                    BindingType = _Binding_type;

                }
                else
                {
                    Console.WriteLine("НЕ проходит валидацию"); return;
                }
                count++;

            }

            // Конструктор с параметрами по умолчанию
            public Book(string _Name, string _Author, int Num_P = 341, int _Price = 51)
            {
                ID = 2;
                Name = _Name;
                Author = _Author;
                Publish = "АСТ";
                Year = 1997;
                NumP = Num_P;
                Price = _Price;
                BindingType = "составной";
                count++;
            }

            // Конструктор без параметров
            public Book()
            {
                ID = 1;
                Name = "Властелин колец";
                Author = "Руэл Толкин";
                Publish = "АСТ";
                Year = 1954;
                NumP = 1137;
                Price = 55;
                BindingType = "составной";
                count++;
            }

            // Статический конструктор
            static Book()
            {
                fcnst = 10;
                count++;
            }

            // Закрытый конструктор
            private Book(int Num)
            {
                ID = GetHashCode();
                count++;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------
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
