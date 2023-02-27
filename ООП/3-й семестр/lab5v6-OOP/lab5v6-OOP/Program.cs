using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace lab5
{
    class Program
    {
        static void Main()
        {
            //4-я лаба
            Book book = new Book("Гарри Поттер", "Роулинг", 859, "МАХАОН", 2012, 145);
            Console.WriteLine(book.DoCheck());
            Console.WriteLine(((ICheck)book).DoCheck());
            Console.WriteLine(book is PrintedEdition);
            Console.WriteLine(book is IAuthor);
            Console.WriteLine(book is IPublisher);
            Console.WriteLine(book.ToString());
            Console.WriteLine(book.GetHashCode());

            Journal journal = new Journal("Маладосць", "", 0, "Издательский дом «Звязда»", 2003, 132);
            Console.WriteLine(journal.DoCheck());
            Console.WriteLine(journal is PrintedEdition);
            Console.WriteLine(journal is IAuthor);
            Console.WriteLine(journal is IPublisher);
            Console.WriteLine(journal.ToString());
            Console.WriteLine(book.Equals(journal));

            TextBook textbook = new TextBook("Биология 11 класс", "Дашкоў М. Л., Песнякевiч А. Г., Галавач А. М.", 565, "Народная асвета", 2015, 113);
            Console.WriteLine(textbook.DoCheck());
            Console.WriteLine(textbook is PrintedEdition);
            Console.WriteLine(textbook is IAuthor);
            Console.WriteLine(textbook is IPublisher);
            Console.WriteLine(textbook.ToString());
            Console.WriteLine();

            Printer printer = new Printer();
            PrintedEdition[] arr = { book as PrintedEdition, journal as PrintedEdition, textbook as PrintedEdition };
            foreach (PrintedEdition part in arr)
            {
                printer.IAmPrinting(part);
            }
            Console.WriteLine();

            Console.WriteLine($"Название: {book.EditionName}, Автор: {book.Name}, Авторский знак: R{book.Cutter},  Издатель: {book.PublisherName}, Год : {book.Year} ");
            Console.WriteLine($"Название: {journal.EditionName},  Издатель: {journal.PublisherName}, Год : {journal.Year} ");
            Console.WriteLine($"Название: {textbook.EditionName}, Автор: {textbook.Name}, Авторский знак: R{textbook.Cutter},  Издатель: {textbook.PublisherName}, Год : {textbook.Year} ");

            //5-я лаба
            LibraryContainer container = new LibraryContainer();
            Book book1 = new Book("Книга1", "Автор1", 859, "Издательство1", 2010, 19);
            Book book2 = new Book("Книга2", "Автор2", 674, "Издательство3", 2015, 50);
            Book book3 = new Book("Книга3", "Автор3", 538, "Издательство3", 2019, 33);
            container.AddBook(book1);
            container.AddBook(book2);
            container.AddBook(book3);
            Journal journal1 = new Journal("Журнал1", "Авторы1", 755, "Издательство2", 2019, 20);
            Journal journal2 = new Journal("Журнал2", "Авторы1", 755, "Издательство2", 2016, 17);
            container.AddJournal(journal1);
            container.AddJournal(journal2);
            TextBook textbook1 = new TextBook("Биология 11 класс", "Дашкоў М. Л., Песнякевiч А. Г., Галавач А. М.", 565, "Народная асвета", 2020, 24);
            TextBook textbook2 = new TextBook("Биология 10 класс", "Дашкоў М. Л., Песнякевiч А. Г., Галавач А. М.", 565, "Народная асвета", 2019, 21);
            TextBook textbook3 = new TextBook("Биология 9 класс", "Дашкоў М. Л., Песнякевiч А. Г., Галавач А. М.", 565, "Народная асвета", 2017, 20);
            container.AddTextBook(textbook1);
            container.AddTextBook(textbook2);
            container.AddTextBook(textbook3);



            int n;
            bool process = true;
            do
            {
                switch (container.menu())
                {
                    case 1: container.PrintList(); break;
                    case 2: container.AddEdition(); break;
                    case 3:
                        Console.WriteLine("Введите год : \n");
                        n = Convert.ToInt32(Console.ReadLine());
                        container.BookNameofYear(n); break;
                    case 4: Console.WriteLine($"Всего учебников в библиотеке : " + container.AllTextBooks()); break;
                    case 5: Console.WriteLine($"Общая стоимость изданий : " + container.FullPECost()); break;
                    case 6: container.ReadFromTxt(); break;
                    case 7: process = false; break;
                    default: Console.WriteLine("Некорректно введенные данные!"); break;
                }
            } while (process);

        }
    }

    //Интерфейс Персона
    interface IPerson
    {
        string? Name { get; set; }
    }
    //Интерфейс Автор
    interface IAuthor : IPerson
    {
        int Cutter { get; set; }
    }
    //Интерфейс Издатель
    interface IPublisher
    {
        string? Publisher { get; set; }
    }
    //Интерфейс ICheck для реализации одноимённых методов
    interface ICheck
    {
        public bool DoCheck();
    }

    //Абстрактный класс Печатное Издание
    abstract class PrintedEdition : IAuthor, IPublisher
    {
        public string? EditionName { get; set; }
        public int Year { get; set; }
        public int Cost { get; set; }
        public string? PublisherName { get; set; }

        public string? Publisher
        {
            set
            {
                PublisherName = value;
            }
            get
            {
                return PublisherName;
            }
        }
        private string? PersonName { get; set; }
        public string? Name
        {
            set
            {
                PersonName = value;
            }

            get
            {
                return PersonName;
            }
        }
        private int CutterNumber { get; set; }
        public int Cutter
        {
            set
            {
                CutterNumber = value;
            }
            get
            {
                return CutterNumber;
            }
        }
        public PrintedEdition(string? n, string? a, int c, string? p, int y, int co)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
            Year = y;
            Cost = co;
        }
        public abstract bool DoCheck();
    }

    //-----------------------------------------------------------

    //Потомки класса PrintedEdition
    class Book : PrintedEdition, ICheck
    {
        public Book(string? n, string? a, int c, string? p, int y, int co) : base(n, a, c, p, y, co)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
            Year = y;
            Cost = co;
        }

        bool ICheck.DoCheck()
        {
            if (Char.IsUpper(Name[0]))
                return true;
            else return false;
        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        //Переопределение ToString
        public override string ToString()
        {
            Type info = typeof(Book);

            return info.ToString();
        }
        //переопределение Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Book m = obj as Book; // возвращает null если объект нельзя привести к типу Book
            if (m as Book == null)
                return false;

            return m.Name == this.Name && m.Cutter == this.Cutter;
        }
        //переопределение GetHashCode
        public override int GetHashCode()
        {
            return Cutter.GetHashCode();
        }
    }

    class Journal : PrintedEdition
    {
        public Journal(string? n, string? a, int c, string? p, int y, int co) : base(n, a, c, p, y, co)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
            Year = y;
            Cost = co;
        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        public override string ToString()
        {
            Type info = typeof(Journal);

            return info.ToString();
        }

    }
    //sealed class Учебник  - При применении к классу модификатор sealed запрещает другим классам наследовать от этого класса.
    sealed class TextBook : PrintedEdition
    {
        public TextBook(string? n, string? a, int c, string? p, int y, int co) : base(n, a, c, p, y, co)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
            Year = y;
            Cost = co;
        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        public override string ToString()
        {
            Type info = typeof(TextBook);

            return info.ToString();
        }
    }


    class Printer
    {
        //Витруальный метод - https://metanit.com/sharp/tutorial/3.19.php
        public virtual void IAmPrinting(IPerson obj)
        {
            Console.WriteLine(obj.GetType().ToString() + ' ' + obj.ToString());
        }
    }

    //Класс-Контейнер Библиотека - разделён на 2 части, 2-я часть в файле Class1.cs
    partial class LibraryContainer 
    {
        private List<PrintedEdition> Libconteiner = new List<PrintedEdition>();
        public List<PrintedEdition> Lib
        {
            get { return Libconteiner; }
            set { Libconteiner = value; }
        }

        //Переменная размера библотеки, на всякий случай
        public int Size = 0;

        //метод, реализующий меню операций над библиотекой
        public byte menu()
        {
            Console.WriteLine();
            Console.Write($"1. Вывести список всех изданий\n" +
                          $"2. Добавить издание\n" +
                          $"3. Вывести книги, вышедшие не ранее указанного года\n" +
                          $"4. Вывести суммарное количество учебников в библиотеке\n" +
                          $"5. Подсчитать стоимость изданий, находящихся в библиотеке\n" +
                          $"6. Прочитать из txt файла\n" +
                          $"7. Выход\n" +
                          $"$ ");
            return Convert.ToByte(Console.ReadLine());
        }
        //Метод удаления объекта - в меню не реализован
        public bool Remove(PrintedEdition item)
        {
            return Libconteiner.Remove(item);
        }
        //Метод вывода издания в консоль
        public void PrintList()
        {
            foreach (var item in Lib)
            {
                
                Console.WriteLine($"Название: {item.EditionName}, Автор: {item.Name}, Авторский знак: R{item.Cutter},  Издатель: {item.PublisherName}, Год : {item.Year} ");
            }
        }
    }
    //Класс контроллер
    static class LibController
    {
        //Вывести книги, вышедшие не ранее указанного года
        public static void BookNameofYear(this LibraryContainer lib, int year)
        {
            foreach (PrintedEdition item in lib.Lib)
                //foreach (var item in Lib)
            {
                if (item.ToString() == "lab5.Book")
                {
                    if (item.Year >= year)
                    {
                        Console.WriteLine($"Название: {item.EditionName}, Автор: {item.Name}, Авторский знак: R{item.Cutter},  Издатель: {item.PublisherName}, Год : {item.Year} ");
                    }
                }
            }
        }

        //Вывести суммарное количество учебников в библиотеке
        public static int AllTextBooks(this LibraryContainer lib)
        {
            int tbcolich = 0;
            TextBook textbook = new TextBook("", "", 0, "", 2000, 0);
            foreach (PrintedEdition tb in lib.Lib)
            {
                if (tb.ToString() == textbook.ToString())
                {
                    tbcolich ++;
                }
            }
            return tbcolich;
        }

        //Подсчитать стоимость изданий, находящихся в библиотеке
        public static int FullPECost(this LibraryContainer lib)
        {

            int fullcost = 0;
            foreach (PrintedEdition item in lib.Lib)
                //foreach (object item in Lib)
            {
                    fullcost = fullcost + item.Cost;
            }
            return fullcost;
        }

        //Метод чтения из txt файла, обязательно нужно выбрать путь по котрому лежит txt файл!
        //https://metanit.com/sharp/tutorial/5.5.php
        //
        //https://codernotes.ru/articles/c-c/chtenie-tekstovogo-fajla-postrochno-na-c.html
        public static void ReadFromTxt(this LibraryContainer lib)
        {
            string path = "lib.txt";
            using (StreamReader f = new StreamReader(path, Encoding.Default))
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    string name = f.ReadLine();
                    string aname = f.ReadLine();
                    int num = Convert.ToInt32(f.ReadLine());
                    string pname = f.ReadLine();
                    int year = Convert.ToInt32(f.ReadLine());
                    int cost = Convert.ToInt32(f.ReadLine());
                    if (s == "Book")
                    {
                        Book editionb = new Book(name, aname, num, pname, year, cost);
                        lib.AddBook(editionb);
                    }
                    if (s == "Journal")
                    {
                        Journal editionj = new Journal(name, aname, num, pname, year, cost);
                        lib.AddJournal(editionj);
                    }
                    if (s == "TextBook")
                    {
                        TextBook editiontb = new TextBook(name, aname, num, pname, year, cost);
                        lib.AddTextBook(editiontb);
                    }
                }

        }

    }

    //перечисление
    enum PrintEditType { Book, Journal, TextBook };

    //структура
    struct PETypes 
    {
        public Book Book;
        public Journal Journal;
        public TextBook TextBook;
    }

}