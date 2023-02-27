using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;

namespace lab4
{
    class Program
    {
        static void Main()
        {
            Book book = new Book("Гарри Поттер", "Роулинг", 859, "МАХАОН");
            Console.WriteLine(book.DoCheck());
            Console.WriteLine(((ICheck)book).DoCheck());
            Console.WriteLine(book is PrintedEdition);
            Console.WriteLine(book is IAuthor);
            Console.WriteLine(book is IPublisher);
            Console.WriteLine(book.ToString());
            Console.WriteLine(book.GetHashCode());

            Journal journal = new Journal("Маладосць", "", 0, "Издательский дом «Звязда»");
            Console.WriteLine(journal.DoCheck());
            Console.WriteLine(journal is PrintedEdition);
            Console.WriteLine(journal is IAuthor);
            Console.WriteLine(journal is IPublisher);
            Console.WriteLine(journal.ToString());
            Console.WriteLine(book.Equals(journal));

            TextBook textbook = new TextBook("Биология 11 класс", "Дашкоў М. Л., Песнякевіч А. Г., Галавач А. М.", 565, "Народная асвета");
            Console.WriteLine(textbook.DoCheck());
            Console.WriteLine(textbook is PrintedEdition);
            Console.WriteLine(textbook is IAuthor);
            Console.WriteLine(textbook is IPublisher);
            Console.WriteLine(textbook.ToString());
            Console.WriteLine();

            Printer printer = new Printer();
            PrintedEdition[] arr = {book as PrintedEdition, journal as PrintedEdition, textbook as PrintedEdition};
            foreach(PrintedEdition part in arr)
            {
                printer.IAmPrinting(part);
            }
            Console.WriteLine();

            Console.WriteLine($"Название: {book.EditionName}, Автор: {book.Name}, Авторский знак: R{book.Cutter},  Издатель: {book.PublisherName}");
            Console.WriteLine($"Название: {journal.EditionName},  Издатель: {journal.PublisherName}");
            Console.WriteLine($"Название: {textbook.EditionName}, Автор: {textbook.Name}, Авторский знак: R{textbook.Cutter},  Издатель: {textbook.PublisherName}");

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
        public PrintedEdition(string? n, string? a, int c, string? p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }
        public abstract bool DoCheck();
    }

    //-----------------------------------------------------------

    //Потомки класса PrintedEdition
    class Book : PrintedEdition, ICheck
    {
        public Book(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
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
        public Journal(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
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
        public TextBook(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
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


}