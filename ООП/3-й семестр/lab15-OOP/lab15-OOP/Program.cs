using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace lab15
{
    public class Program
    {
        static void Main(string[] args)
        {
            TPL.ParallelVectorByNumber();

            TPL.ParallelVectorByNumberWithTocken();
            TPL.Continuation();
            TPL.ParallelFor();

            TPL.Shop();
            TPL.AsyncDemonstration();




        }
    }
    public static class TPL
    {
        //1
        //Умножениевектора размера 100000 на число
        public static void ParallelVectorByNumber()
        {
            Stopwatch stopwatch = new Stopwatch();//Предоставляет набор методов и свойств, которые можно использовать для точного измерения затраченного времени.
            Random rnd = new Random();
            int SomeNumber = rnd.Next(20,200);
            List<Task> Tasks = new List<Task>();
            BlockingCollection<int> Vector = new BlockingCollection<int>();
            for (int i = 0; i < 10; i++)
            {
                Tasks.Add(new Task(() =>
                {
                    for (int i = 0; i < 100000; i++)
                        Vector.Add(rnd.Next(1, 10000) * SomeNumber);
                }));
            }
            Console.WriteLine(Tasks[0].Status);
            stopwatch.Start();//Останавливает измерение затраченного времени для интервала.
            foreach (var task in Tasks)
                task.Start();
            Task.WaitAll(Tasks.ToArray());
            stopwatch.Stop();
            Console.WriteLine(Tasks[0].Status);

            Console.WriteLine("Количество тактов при использовании Task: " + stopwatch.ElapsedTicks);//Получает общее затраченное время в тактах таймера, измеренное текущим экземпляром.
        }
        //2
        public static void ParallelVectorByNumberWithTocken()
        {
            Random rnd = new Random();
            int SomeNumber = rnd.Next(20, 200);
            List<Task> Tasks = new List<Task>();
            List<int> Vector = new List<int>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();//Отправляет токену CancellationToken сигнал отмены. - этот токен Распространяет уведомление о том, что операции следует отменить.

            for (int i = 0; i < 10; i++)
            {
                Tasks.Add(new Task(() =>
                {
                    for (int i = 0; i < 1000000; i++) {
                        //Vector.Add(rnd.Next(1, 10) * SomeNumber);
                        }
                }, tokenSource.Token)); //Возвращает объект CancellationToken, связанный с этим объектом CancellationTokenSource.

            }


            foreach (var task in Tasks)
                task.Start(); //Запускает задачу Task, планируя ее выполнение в текущем планировщике TaskScheduler.
            tokenSource.Cancel();//Передает запрос на отмену.
            Console.WriteLine("Status: " + Tasks[5].Status);//Получает состояние TaskStatus данной задачи.
        }

        //3-4
        public static void Continuation()
        {
            Task<double> task1 = Task.Run(() => { return Math.Pow(2, 16); }); //Ставит в очередь заданную работу для запуска в пуле потоков и возвращает объект Task, представляющий эту работу.
            Task<double> task2 = task1.ContinueWith(x => { return Math.Pow(264, 5) * x.Result; });//Создает продолжение, которое выполняется асинхронно после завершения выполнения целевой задачи Task.
            Task task3 = task2.ContinueWith(x => { Console.WriteLine("Ответ: " + x.Result * 12); });
            task3.GetAwaiter().GetResult();//GetAwaiter().GetResult(); — возврат результата / выброс оригинального исключения — служебный метод компилятора, поэтому использовать его не рекомендуется. Используется механизмом async/await.
        }

        //5
        public static void ParallelFor()
        {
            BlockingCollection<int> Arr = new BlockingCollection<int>();
            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //       For(int, int,          Action<int>)   Первый параметр метода задает начальный индекс элемента в цикле, а второй параметр - конечный индекс.Третий параметр -делегат Action - указывает на метод, который будет выполняться один раз за итерацию:
            Parallel.For(0, 1000000, i => { Arr.Add(rnd.Next(1, 1000)); }); //Метод Parallel.For позволяет выполнять итерации цикла параллельно. Он имеет следующее определение:
            stopwatch.Stop();

            Console.WriteLine("Parallel.For: \t" + stopwatch.ElapsedTicks + " тактов");

            stopwatch.Reset();//Останавливает измерение интервала времени и обнуляет затраченное время.
            stopwatch.Start();//Запускает или возобновляет измерение затраченного времени для интервала.
            List<int> Array = new List<int>();
            for (int i = 0; i < 1000000; i++)
                Array.Add(rnd.Next(1, 1000));
            stopwatch.Stop();

            Console.WriteLine("For:\t\t" + stopwatch.ElapsedTicks + " тактов");
        }
        //6
        public static void ParallelInvoke()//Выполняет все предоставленные действия, по возможности в параллельном режиме.
        {
            Parallel.Invoke(() => { Console.WriteLine("First function"); }, () => { Console.WriteLine("Second function"); }, () => { Console.WriteLine("Third function"); });
            //Метод Parallel.Invoke в качестве параметра принимает массив объектов Action, то есть мы можем передать в данный метод набор методов, которые будут вызываться при его выполнении.
        }

        //7
        public static void Shop()
        {
            Dictionary<int?, string> Product = new Dictionary<int?, string>();
            Product.Add(0, "Диван");
            Product.Add(1, "Стул");
            Product.Add(2, "Стол");
            Product.Add(3, "Постер");
            Product.Add(4, "Табурет");
            Product.Add(5, "Ленолиум");
            Product.Add(6, "Кровать");
            Product.Add(7, "Обои");
            Product.Add(8, "Люстра");
            Product.Add(9, "Окно");

            BlockingCollection<int> Warehouse = new BlockingCollection<int>();
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        Thread.Sleep(rnd.Next(1000, 5000));

                        int Counter = 0;
                        Warehouse.Add(rnd.Next(0, 9));
                        Console.WriteLine("Склад: ");
                        foreach (var product in Warehouse)
                        {
                            Console.WriteLine(Product[product]);
                            Counter++;
                        }
                        if (Counter == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Ничего");
                            Console.ResetColor();
                        }

                        Console.WriteLine("-------------------");
                        Thread.Sleep(rnd.Next(1000, 5000));
                    }
                });
            }
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        Thread.Sleep(rnd.Next(1000, 5000));
                        foreach (var product in Warehouse)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Product[product] + " куплен");
                            Console.ResetColor();
                            Console.WriteLine("-------------------");

                            int i = product;
                            int Counter = 0;
                            Warehouse.TryTake(out i);
                            Console.WriteLine("Склад: ");
                            foreach (var productt in Warehouse)
                            {
                                Console.WriteLine(Product[productt]);
                                Counter++;
                            }
                            if (Counter == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Ничего");
                                Console.ResetColor();

                            }
                            else
                                Counter = 0;
                            Console.WriteLine("-------------------");
                            break;
                        }
                    }
                });
            }
            Thread.Sleep(5000);
        }

        //8
        public static void Print()
        {
           // Thread.Sleep(3000);     // имитация продолжительной работы
            Console.WriteLine("Hello METANIT.COM");
        }
        //оператор await можно применять только в методе, который имеет модификатор async.
        public static async void AsyncDemonstration()
        {
            await Task.Run(() => Print());
        }
    }
}