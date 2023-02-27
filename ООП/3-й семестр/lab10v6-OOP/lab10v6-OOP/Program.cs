//https://metanit.com/sharp/tutorial/15.1.php - LINQ

//https://metanit.com/sharp/tutorial/15.3.php - сортировка в LINQ


using System;
using System.Text;
using System.Linq;


namespace Lab10
{
    class Program
    {
        //Main
        static void Main(string[] args)
        {
            string[] Months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            int n;
            Console.WriteLine("Введите лину строки : ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Строки из {n} символов:");
            var strleng = from mon in Months
                          where mon.Length == n
                          select mon;
            foreach (string m in  strleng)
                Console.WriteLine(m);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Летние месяцы:");
            var summermonth = from mon in Months
                              where mon == "June" || mon == "July" || mon == "August"
                              select mon;
            foreach (string m in summermonth)
                Console.WriteLine(m);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Зимние месяцы:");
            var wintermonth = from mon in Months
                              where mon == "January" || mon == "February" || mon == "December"
                              select mon;
            foreach (string m in wintermonth)
                Console.WriteLine(m);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Месяцы в алфавитном порядке:");
            var sortmonth = from mon in Months
                              orderby mon
                              select mon;
            foreach (string m in sortmonth)
                Console.WriteLine(m);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Месяцы, содержащие букву \"u\" и размером не менее 4-х символов:");
            var mont = from mon in Months
                       where mon.Contains('u') && mon.Length >= 4
                       select mon;
            foreach (var a in mont)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            List<Book> books = new List<Book>();
            books.Add(new Book(2,"Гарри Поттер и Тайная комната", "Джоан Роулинг", "АСТ", 1997, 341, 51, "составной"));
            books.Add(new Book(3, "Мёртвые души", "Гоголь", "Эксмо", 1842, 448, 43, "составной"));
            books.Add(new Book(4, "Преступление и наказание", "Достоевский", "Эксмо", 1865, 351, 39, "составной"));
            books.Add(new Book(5, "Братство Кольца", "Руэл Толкин", "АСТ", 1954, 480, 20, "цельный"));

            books.Add(new Book(6, "Гарри Поттер и Философский Камень", "Джоан Роулинг", "АСТ", 1997, 432, 65, "составной"));
            books.Add(new Book(7, "Гарри Поттер и Узник Азкабана", "Джоан Роулинг", "АСТ", 1999, 528, 62, "составной"));

            books.Add(new Book(8, "Некий Магический Индекс: Новый Завет том 1-11", "Камати Кадзума", " РуРанобэ", 2011, 200, 82, "цельный"));
            books.Add(new Book(9, "Муму", "Иван Тургенев", "Азбука", 2018, 352, 24, "цельный"));

            books.Add(new Book(10, "Кто смеётся последним", "Кондрат Крапива", "Эксмо", 1939, 188, 28, "твёрдый"));
            books.Add(new Book(11, "Человек в футляре", "Антон Чехов", "Азбука", 1898, 576, 30, "твёрдый"));



            Console.WriteLine("Cписок книг заданного автора и года:");
            var ftd = from b in books
                              where b.Author == "Джоан Роулинг" && b.Year == 1997
                              select b;
            foreach (Book m in ftd)
                print(m);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Список книг, выпущенных после заданного года:");
            var by = from b in books
                              where b.Year > 1950
                              select b;
            foreach (Book m in by)
                print(m);

            Console.WriteLine("----------------------------------------");
            int min = 5000;
            Console.WriteLine("Самая тонкая книга:");
            var MinPage = books.Min(x => x.NumP);
            var MinPageObject = books.FirstOrDefault(a => a.NumP == MinPage);
                print(MinPageObject);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("5 первых самых толстых книг по низкой цене:");
            var sort = from b in books
                          orderby b.NumP descending, b.Price ascending
                       select b;
            var topfive = sort.Take(5);

            foreach (Book m in topfive)
                print(m);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Список книг отсортированных по цене:");
            var sortbyprice = from b in books
                       orderby b.Price 
                       select b;

            foreach (Book m in sortbyprice)
                print(m);
            Console.WriteLine("--------------------------------------");


            //Запрос, в котором 5 операторов разных категорий https://studfile.net/preview/7077131/page:15/ страницы 15-19
            Console.WriteLine("Запрос, в котором 5 операторов разных категорий:");
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 50, 100 };
            Console.WriteLine(Numbers.Where(x => x > 1).Select(x => x).OrderBy(x => x).Aggregate((x, y) => x + y));
            Console.WriteLine(Numbers.GroupBy(x => x).Any());
            Console.WriteLine(Numbers.Take(5));
            Console.WriteLine("--------------------------------------");

            //Запрос с оператором Join https://metanit.com/sharp/tutorial/15.7.php
            Console.WriteLine("Запрос с оператором Join:");
            Person[] people = { new Person("Елисей", 1), new Person("Юля", 2) };
            Group[] groups = { new Group(1, "Группа1"), new Group(2, "Группа2") };
            var members = from p in people
                          join g in groups on p.GroupNumber equals g.Number
                          select new { Name = p.Name, GroupNumber = g.Number, GroupName = g.GroupName };
            foreach (var member in members)
            {
                Console.WriteLine($"{ member.Name} - {member.GroupNumber} - {member.GroupName}");
            }

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
        }
        //---------------------------------------------------------------

        // Вывод информации о классе в статическом методе
        static void GetInfo()
        {
            Type myType = typeof(Book);
            Console.WriteLine($"Тип объекта Book: {typeof(Book)}");
            Console.WriteLine($"Имя: {myType.Name}");
            Console.WriteLine($"Полное имя: {myType.FullName}");
            Console.WriteLine($"Пространство имён: {myType.Namespace}");
            Console.WriteLine($"Является ли структурой: {myType.IsValueType}");
            Console.WriteLine($"Является ли классом: {myType.IsClass}");
        }


        //метод с использованием ref
        static void Increment(ref int count)
        {

            Console.WriteLine($"Число в методе Increment: {count}");
        }

        //Метод с использованием out
        static void SumPage(int v, int b, out int result)
        {
            result = v + b;
        }

        //Вывод экземмпляра в консоль
        static void print(Book book)
        {
            Console.WriteLine($"\t{book.id}\t{book.Name}\t\t{book.Author}\n\t{book.Publish}\t{book.Year}\t{book.NumP}\t{book.Price}\t{book.BindingType}\t");
            Console.WriteLine();
        }

        //Метод вывода книг одного автора
        static void find(Book[] books, string author)
        {

            foreach (Book book in books)
            {
                if (author.ToString() == book.Author)
                    print(book);
            }
        }

        //Метод вывода книг полсе определённого года
        static void findY(Book[] books, int year)
        {

            foreach (Book book in books)
            {
                if (book.Year > year)
                    print(book);
            }
        }
        

        class Person
        {
            public string Name { get; set; }
            public int GroupNumber { get; set; }

            public Person(String nm, int gn)
            {
                Name = nm;
                GroupNumber = gn;
            }
        }

        class Group
        {
            public int Number { get; set; }
            public string GroupName { get; set; }

            public Group(int n, string gn)
            {
                Number = n;
                GroupName = gn;
            }
        }
    }
}