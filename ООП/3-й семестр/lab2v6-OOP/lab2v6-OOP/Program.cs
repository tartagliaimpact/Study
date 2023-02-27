using System;
using System.Text;


namespace Lab2
{
    class Program
    {
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
            public Book(int Id, string _Name, string _Author, string _Publish,int _Year, int _Num_p, int _Price, string _Binding_type)
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
            public Book(string _Name, string _Author,int Num_P = 341, int _Price = 51)
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
                ID  = GetHashCode();
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
            Console.WriteLine($"{book.id}\t{book.Name}\t{book.Author}\t{book.Publish}\t{book.Year}\t{book.NumP}\t{book.Price}\t{book.BindingType}\t"); 
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

        //Main
        static void Main(string[] args)
        {
            //массив экземпляров класса Book
            Book[] books = new Book[5];
            books[0] = new Book();
            books[1] = new Book("Гарри Поттер Тайная комната", "Джоан Роулинг");
            books[2] = new Book(3, "Мёртвые души", "Гоголь", "Эксмо", 1842, 448, 43, "составной");
            books[3] = new Book(4, "Преступление и наказание", "Достоевский", "Эксмо", 1865, 351, 39, "составной");
            books[4] = new Book(5, "Братство Кольца", "Руэл Толкин", "АСТ", 1954, 480, 20, "цельный");


            //анонимный тип
            var book = new{ID = 7, Name = "Гарри Поттер и Тайная комната", Author = "Джоан Роулинг", Publish = "Махаон", Year = 1998, NumP = 480, Price = 46, BindingType = "цельный"};

            int number = 5;
            int result;
            Increment(ref number);//использование ref в методе
            Console.WriteLine();
            SumPage(1137, 480, out result);//использование out в методе
            Console.WriteLine("Суммарное количество страниц в книгах Властелин колец и Братсво кольца");
            Console.WriteLine(result);
            Console.WriteLine();
            GetInfo();//Вывод информации о классе
            Console.WriteLine();
            find(books, "Руэл Толкин");//Поиск книг по автору
            Console.WriteLine();
            findY(books, 1930);//Поиск книг, выпущенных после этого года
            Console.WriteLine();

            //Вывод анонимного типа
            Console.WriteLine($"{book.ID}\t{book.Name}\t{book.Author}\t{book.Publish}\t{book.Year}\t{book.NumP}\t{book.Price}\t{book.BindingType}\t");

            //Console.WriteLine(books[0].ID); //недопустимый уровень защиты
            //Console.WriteLine(books[0].forSet);
        }


    }
}