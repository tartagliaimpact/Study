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
	partial class LibraryContainer
	{
        public void AddBook(Book bookn)
        {
            Libconteiner.Add(bookn);
            Size++;

        }
        public void AddJournal(Journal journaln)
        {
            Libconteiner.Add(journaln);
            Size++;
        }

        public void AddTextBook(TextBook textbookn)
        {
            Libconteiner.Add(textbookn);
            Size++;
        }

        public void AddEdition()
        {
            Console.WriteLine();
            Console.WriteLine("Введите название издания");
            string name = Console.ReadLine();
            Console.WriteLine("Введите автора");
            string aname = Console.ReadLine();
            Console.WriteLine("Ввведите авторский номер");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите название издательства");
            string pname = Console.ReadLine();
            Console.WriteLine("Введите год выхода издания");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите стоимость издания");
            int cost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Выберите тип издания :\n" +
                              $"1. Добавить книгу\n" +
                              $"2. Добавить журнал\n" +
                              $"3. Добавить учебник\n"
                );
            int variant = Convert.ToByte(Console.ReadLine());
            switch (variant)
            {
                case 1:
                    Book editionb = new Book(name, aname, num, pname, year, cost);
                    AddBook(editionb);
                    break;
                case 2:
                    Journal editionj = new Journal(name, aname, num, pname, year, cost);
                    AddJournal(editionj);
                    break;
                case 3:
                    TextBook editiontb = new TextBook(name, aname, num, pname, year, cost);
                    AddTextBook(editiontb);
                    break;
                default:
                    Console.WriteLine("Некорректно введенные данные!"); break;
            }
        }
    }
}
