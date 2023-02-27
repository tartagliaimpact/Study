// Про обобщения - https://metanit.com/sharp/tutorial/3.12.php
//Про обобщённые интерфейы - https://metanit.com/sharp/tutorial/3.40.php / https://professorweb.ru/my/csharp/charp_theory/level11/11_12.php

using System;
using System.Collections.Generic; 
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Text;

namespace Lab7
{

    class Program
    {
        static void Main(string[] args)
        {
            //4-я лаба
            CollectionType<int> ListInt = new CollectionType<int>();
            ListInt.Add(1);
            ListInt.Add(2);
            ListInt.Add(3);
            ListInt.Add(4);
            ListInt.Add(5);
            ListInt.Show();
            CollectionType<PrintedEdition> ListPE = new ();
            ListPE.Add(new PrintedEdition("Название1", "Имя1", 1, "Издание1"));
            ListPE.Add(new PrintedEdition("Название2", "Имя2", 2, "Издание2"));
            ListPE.Add(new PrintedEdition("Название3", "Имя3", 3, "Издание3"));
            ListPE.Show();

            string path = "file.txt";
            string path2 = "file2.txt";
            ListInt.WriteInTxt(path);
            ListInt.ReadFromTxt(path);
            ListPE.WriteInTxt(path2);
            ListPE.ReadFromTxt(path2);
            try
            {
                ListPE.ReadFromTxt(path2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Чтение из файла прошло успешно");
            }
        }

    }

    //
    interface IMenu<T> where T : new()
    {
        public bool Add(T data);
        public bool Delete(T data);
        public void Show();
    }

    //------------------------------------------------------------------------------
    //Класс - односвязный список List

    public class CollectionType<T> : IMenu<T> where T : new()//Ограничение обобщения where T : new() означает, что тип, которым будет закрыто это обобщение, должен иметь конструктор без параметров, тобишь конструктор по-умолчанию.
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
        Developer developer = new Developer { FIO = "Карпин Александр", id = 1, otdel = "отдел ИТ" };

        public List<T> items = new();
        public bool Add(T data)
        {
            if (!items.Contains(data))
            {
                items.Add(data);
                return true;
            }
            else
                return false;
        }
        public bool Delete(T item)
        {
            return items.Remove(item);
        }
        public void Show()

        {
            foreach (T t in items)
            {
                Console.WriteLine(t);
            }
        }
        public async void WriteInTxt(string? path) // async - ассинхронные методы https://metanit.com/sharp/tutorial/13.3.php
        {
            string Message = "";
            using (StreamWriter f = new StreamWriter(path, true))
            foreach(var item in items)
            {
                    Message = "" + item;
                await f.WriteLineAsync(Message);
            }

        }
        public void ReadFromTxt(string? path)
        {
            using (StreamReader f = new StreamReader(path, Encoding.Default))
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    if( s == null)
                    {
                        throw new Exception("строка пуста!");
                    }
                    Console.WriteLine(s);
                }

        }
    }
    //------------------------------------------------------------------------------
    //Пользовательски класс PrintedEdition из 4-лабы
    class PrintedEdition
    {
        public string? EditionName { get; set; }
        public string? PublisherName { get; set; }
        public string? Name { get; set; }

        public int Cutter { get; set; }
        public PrintedEdition()
        {
        }
        public PrintedEdition(string? n, string? a, int c, string? p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }
    }


}
