//https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/using-directive
//https://metanit.com/sharp/tutorial/2.15.php - очень полезный сайт по C#

//Программа
using Microsoft.VisualBasic.FileIO;//Содержит типы, которые поддерживают объект My file system в Visual Basic.
using System; //содержит фундоментальные и базовые платформы .NET
using System.Runtime.CompilerServices; //Предоставляет средства, позволяющие разработчикам компиляторов, использующим управляемый код, задавать в метаданных атрибуты, влияющие на поведение среды CLR во время выполнения.
using System.Text; //подключаем пространство имен, которое позволит работать с текстом

//Пространсво имён Lab1
namespace Lab1  //https://csharp.webdelphi.ru/prostranstva-imen-namespace-v-c/
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) Типы
            //---------------------------------------------------------------------------------------------------------
            //a) Инициализация перменных  https://metanit.com/sharp/tutorial/2.1.php
            bool check = true; //.NET тип - System.Boolean https://learn.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0
            byte a = 255; //.NET тип - 	System.Byte 
            sbyte b = 127; //.NET тип - System.SByte
            char c = 'L'; //.NET тип - System.Char
            decimal d = 2.1m; //.NET тип - System.Decimal
            double e = 1345452.9456421; //.NET тип - System.Double
            float f = 10.09f; //.NET тип - System.Single
            int i = 10; //.NET тип - System.Int32
            uint j = 10;//.NET тип - System.UInt32
            nint k = 42;//.NET тип - System.IntPtr
            nuint l = 19;//.NET тип - System.UIntPtr
            long m = 63256L;//.NET тип - System.Int64
            ulong n = 65431UL;//.NET тип - System.UInt64
            short o = 4000;//.NET тип - System.Int16
            ushort p = 100;//.NET тип - System.UInt16
            string q = "Hello";//.NET тип - System.String
            object r = "any type";//.NET тип - System.Object
            dynamic s = "Чур меня";//.NET тип - System.Object

            //Вывод в консоль
            Console.WriteLine($"bool: {check}\n" + $"byte: {a}\n" + $"sbyte: {b}\n" + $"char: {c}\n" + $"decimal: {d}\n" +$"double: {e}\n" +
                $"float: {f}\n" + $"int: {i}\n" + $"int: {j}\n" + $"uint: {j}\n" + $"nint: {k}\n" + $"nuint: {l}\n" + $"long: {m}\n" +
                $"ulong: {n}\n" + $"short: {o}\n" + $"ushort: {p}\n" + $"string: {q}\n" + $"object: {r}\n" + $"dynamic: {s}\n");

            // Ввод строковой переменной
            Console.Write("Введите Имя: ");
            string?  t = Console.ReadLine(); //знак вопроса ? указывает, что переменная также может хранить значение null
            Console.WriteLine($"Привет, {t}");

            // Ввод целочисленной переменной
            Console.Write("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());//Convert.ToInt32() преобразует к типу int
            Console.WriteLine($"Возраст: {age}");

            // Ввод переменной с плавающей точкой
            Console.Write("Введите рост: ");
            double height = Convert.ToDouble(Console.ReadLine());//Convert.ToDouble() преобразует к типу double
            Console.WriteLine($"Рост: {height}");

            Console.Write("Введите размер зарплаты: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());//Convert.ToDecimal() преобразует к типу decimal
            Console.WriteLine($"Размер зарплаты: {salary}");



            //b)Приведение типов https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/casting-and-type-conversions
            //https://metanit.com/sharp/tutorial/2.2.php

            //Неявные приведения
            //1
            int num = 2147483647;
            long bigNum = num;
            //2
            sbyte ty = 44;         
            short arf = ty;
            //3
            sbyte ui = -90;
            short et= ui;
            //4
            short tr = 5;
            int er = tr;
            //5
            float nn = 56.55f;
            double dd = nn;



            //Явные приведения (операция преобразования ( операция () ) )
            //1
            double xr = 1234.7;
            int it = (int)xr;
            //2
            double itf = 12.5432;
            decimal sf = (decimal)itf;
            //3
            float ff = 12.4f;
            long ll = (long)ff;
            //4
            int ii = 56;
            char cc = (char)ii;
            //5
            long li = 534;
            int il = (int)li;


            //c) Упаковка и распаковка значимых типов https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/boxing-and-unboxing

            //Упаковка(выполняется неявно, но можно и упаковать явно(это не обязательно)
            int itd = 910;
            object obb = itd;
            //Распаковка(выполняется явно)
            itd = (int)obb;

            //d)Неявно типизированные переменные  https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables
            var ab = 10;
            var stroka = "Чёрное солнце";
            var massiv = new[] { 0, 1, 2 };

            //e) Nullable https://metanit.com/sharp/tutorial/2.17.php
            int? val = null;
            Console.WriteLine(val);

            //f) var и ошибка
            var str = "Осень";
            //str = 55; //будет ошибкой, так как переменная str уже определена как string



            //2) Строки  https://metanit.com/sharp/tutorial/7.1.php 
            //https://metanit.com/sharp/tutorial/7.2.php
            //---------------------------------------------------------------------------------------------------------
            //a)Объявление строковых литералов и сравнение 
            string str1 = "Фантом";
            string str2 = "Солнечный свет";
            Console.WriteLine(str1 == str2); // - false
            //String.compare()
            string str3 = "Солнечный свет";
            Console.WriteLine(String.Compare(str1, str3)); // - 1



            //b)
            string stroka1 = "Звезда ";
            string stroka2 = "по имени";
            string stroka3 = " Солнце";
            string jp = "Давным-давно, в далекой-далекой Японии...";

            //Сцепление
            Console.WriteLine(String.Concat(stroka1, stroka2, stroka3));// метод String.Concat()
            Console.WriteLine(stroka1 + stroka2 + stroka3);

            //Копирование
            string strcopy1 = stroka1;

            //Выделение подстроки   https://www.geeksforgeeks.org/c-sharp-substring-method/
            Console.WriteLine("Срока    : " + jp);
            Console.WriteLine("Подстрока: " + jp.Substring(14));
            str.Substring(4, 0);
            Console.WriteLine("Подстрока 2: " + jp.Substring(7, 5));

            //Разделение строки на слова
            string[] words = jp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//Второй параметр StringSplitOptions.RemoveEmptyEntries говорит, что надо удалить все пустые подстроки.

            foreach (string st in words) //Цикл foreach предназначен для перебора набора или коллекции элементов. Его общее определение: foreach(тип_данных переменная in коллекция)
            {
                Console.WriteLine(st);// действия цикла
            }

            //Вставка подстроки в заданную позицию https://learn.microsoft.com/ru-ru/dotnet/api/system.string.insert?view=net-5.0
            string lll = "llll",
                   rrr = "rrrr";
            Console.WriteLine("Вставка подстроки в строку: " + lll.Insert(2, rrr));

            //Удаление заданной подстроки
            string? del;
             del = jp.Remove(16, 16);
            Console.WriteLine(del);

            //Интерполирование строк https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/tokens/interpolated
            int saturday = 6,
                friday = 5;
            Console.WriteLine($" Пятница - {friday}, суббота - {saturday}, воскресенье - 7");


            //c)null and empty   https://learn.microsoft.com/ru-ru/dotnet/api/system.string.isnullorempty?view=net-5.0
            //https://learn.microsoft.com/ru-ru/dotnet/api/system.string?view=net-5.0#null-strings-and-empty-strings
            string nl = null;
            string emp = "";// или string emp = String.Empty;
            string space = " ";
            Console.WriteLine("String s1 {0}.", Test(nl));
            Console.WriteLine("String s2 {0}.", Test(emp));
            Console.WriteLine("String s2 {0}.", Test(space));

            String Test(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "является null или empty";
                else
                    return String.Format("(\"{0}\") не является ни null, ни empty", s);
            }

            Console.WriteLine("String s1 {0}.", Test2(nl));
            Console.WriteLine("String s2 {0}.", Test2(emp));
            Console.WriteLine("String s2 {0}.", Test2(space));
            String Test2(string s)
            {
                if (String.IsNullOrWhiteSpace(s))
                    return "является null или empty или состоит из пробелов";
                else
                    return String.Format("(\"{0}\") не является ни null, ни empty, и не состоит из пробелов", s);
            }


            //Stringbuilder https://learn.microsoft.com/ru-ru/dotnet/api/system.text.stringbuilder?view=net-6.0#how-stringbuilder-works
            StringBuilder sb = new StringBuilder("Пускай круто меня заносит");
            Console.WriteLine(sb);
            sb.Remove(7, 6);
            sb.Insert(0, "Ну и ");
            sb.Append(", ...");     //https://www.techiedelight.com/ru/append-a-char-to-end-of-a-string-in-csharp/
            Console.WriteLine(sb);



            //3) Массивы   https://metanit.com/sharp/tutorial/2.4.php
            //---------------------------------------------------------------------------------------------------------
            //a)Двумерный массив, матрица.
            int[,] nums = { { 5, 9, 10, 12}, { 13, 19, 20, 23} };
            Console.WriteLine("Матрица:");
            for (int kk = 0; kk < 2; kk++)
            {
                for (int nnn = 0; nnn < 4; nnn++)
                    Console.Write(nums[kk, nnn] + "\t");
                Console.WriteLine();
            }

            //b)Массив строк
            string[] stroki = { "Ветер", "Рассвет", "Ночь", "Звёзды" };
            foreach (string trie in stroki)
                Console.WriteLine(trie);//Массив строк
            Console.WriteLine("Длина: " + stroki.Length);// Длина массива
            Console.Write("Выберете индекс: ");
            int indx = Convert.ToInt32((Console.ReadLine()));
            if (indx != 0 && indx != 1 && indx != 2 && indx != 3)//Проверка
                Console.WriteLine("Введены неверные данные!");
            else
            {
                Console.Write("Введите строку: ");
                stroki[indx] = Console.ReadLine();
                Console.Write("Полученная строка: ");
                foreach (string trie in stroki)
                    Console.WriteLine(trie);
            }

            //c)Ступенатый массив
            int[][] Massiv = new int[3][];
            Massiv[0] = new int[2];
            Massiv[1] = new int[3];
            Massiv[2] = new int[4];
            for (i = 0; i < Massiv.Length; i++)
                for (j = 0; j < Massiv[i].Length; j++)
                {
                    Console.Write($"Введите число в позиции ({i},{j}): ");
                    Massiv[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Полученный массив: ");
            for (i = 0; i < Massiv.Length; i++)
            {
                for (j = 0; j < Massiv[i].Length; j++)
                    Console.Write(Massiv[i][j] + "\t");
                Console.WriteLine();
            }

            //d) Неявно типизированные строки и массивы   https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables
            var neyavStr = "Привет!";
            var neyavMas = new[] { 10, 9, 12, 13, 23 };



            //4) Кортежи  https://metanit.com/sharp/tutorial/2.19.php
            //---------------------------------------------------------------------------------------------------------
            //a)Кортеж из 5 элементов
            (int, string, char, string, ulong) pn = (10, "Haruhi", 'L', "Fremder", 80);
            Console.WriteLine($"Кортеж: {pn.Item1}, {pn.Item2}, {pn.Item3}, {pn.Item4}, {pn.Item5}");

            //b)Вывод 1, 3 и 4 элементов кортежа
            Console.WriteLine($"1, 3 и 4 элементы кортежа: {pn.Item1}, {pn.Item3}, {pn.Item4}");

            //c)Распаковка(деконструкция) кортежа https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-assignment-and-deconstruction
            var kort = ("Type", 55);
            //1)явно
            (string tip, int chislo) = kort;
            Console.WriteLine($"tip: {tip}/ chislo: {chislo}");
            //2)неявно
            var (tp, chsl) = kort;
            Console.WriteLine($"tip: {tp}/ chislo: {chsl}");

            //3)используя существующие переменные
            (q, i) = kort;
            Console.WriteLine($"tip: {q}/ chislo: {i}");

            //Продемонстрируйте использование переменной ( _ ).

            //Переменная (_) - нашёл только про переменную (_) в С++, но я думаю, что и к С# это относится https://ru.stackoverflow.com/questions/553231/Нижнее-подчеркивание-в-c
            _ = 5; // пример
            _ = 7;

            //d)Сравнение кортежей
            if ((7, 67, 12) == (65, 88, 41))
                Console.WriteLine("Сравниваемые кортежи равны");
            else
                Console.WriteLine("Сравниваемые кортежи не равны");


            //5) Локальная функция https://metanit.com/sharp/tutorial/2.20.php
            //---------------------------------------------------------------------------------------------------------

            static (int, int, int, char) func(int[] arr, string str) // (int, int, int, char) - максимальный и минимальный элементы массива, сумму элементов массива и первую букву строки
            {
                int min = arr[0];
                int max = arr[0];
                int sum = 0;
                foreach (int i in arr)
                {
                    if (i > max)
                        max = i;
                    if (i < min)
                        min = i;
                    sum += i;
                }
                return (max, min, sum, str[0]);
            }

            var kortezh = func(new int[] { 7, 9, 8, 10, 4 }, "Время");

            //6) checked / uncheked https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/statements/checked-and-unchecked
            //---------------------------------------------------------------------------------------------------------
            //a) checked
            // checked/unchecked
            static void checkedFunc()
            {
                int x = checked(int.MaxValue);
            }
            //b) unchecked
            static void uncheckedFunc()
            {
                int x = unchecked(int.MaxValue);
            }
            //c) Результат
            checkedFunc();
            uncheckedFunc();

        }
    }
}