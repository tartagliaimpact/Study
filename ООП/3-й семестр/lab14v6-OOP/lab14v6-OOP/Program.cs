using System.IO;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;


namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            foreach (Process process in Process.GetProcesses())
            {

                try
                {
                    Console.WriteLine($"ID: {process.Id}");
                    Console.WriteLine($"Имя: { process.ProcessName} ");
                    Console.WriteLine($"Используемая физ память: {process.WorkingSet64}");
                    Console.WriteLine($"Базовый приоритет: {process.BasePriority}");
                    Console.WriteLine($"Размер виртуальной памяти: {process.VirtualMemorySize64}");
                    Console.WriteLine($"Время запуска: {process.StartTime}");
                    Console.WriteLine($"Получает пользовательское время процессора для этого процесса: {process.UserProcessorTime}");
                    Console.WriteLine($"Получает права доступа на время процессора для этого процесса: {process.PrivilegedProcessorTime}");
                    Console.WriteLine($"Полное время процессора для этого процесса: {process.TotalProcessorTime}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            //2
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName}");
            Console.WriteLine($"ID: {domain.Id}");
            Console.WriteLine($"представляет объект AppDomainSetup и хранит конфигурацию домена приложения: {domain.SetupInformation}");
            foreach (Assembly assembly in domain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);
            Console.WriteLine();

            //AppDomain newDomain = AppDomain.CreateDomain("NewDomain1");//новый домен приложения в текущем процессе
            //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            //    newDomain.Load(assembly.FullName);//Этот метод применяется для динамической загрузки сборки в текущий домен приложения
            //AppDomain.Unload(newDomain);//Этот статический метод позволяет выгрузить определенный домен приложения из конкретного процесса
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            //3
            ThreadingCounter();
            //4
            Thread OddThread = new Thread(odd);
            Thread EvenThread = new Thread(even);
            OddThread.Start();
            EvenThread.Start();

            Thread.Sleep(2200);
            Console.WriteLine();

            Thread OddThread1 = new Thread(odd);
            Thread EvenThread1 = new Thread(even);
            EvenThread1.Priority = ThreadPriority.Highest;
            OddThread1.Priority = ThreadPriority.Lowest;
            OddThread1.Start();
            EvenThread1.Start();

            Thread.Sleep(2200);
            Console.WriteLine();

            Thread OddThread2 = new Thread(odd);
            Thread EvenThread2 = new Thread(even);
            OddThread2.Start();
            OddThread2.Join();
            EvenThread2.Start();

            Thread.Sleep(2200);
            Console.WriteLine();

            Thread OddThread3 = new Thread(odd1);
            Thread EvenThread3 = new Thread(even1);
            OddThread3.Start();
            EvenThread3.Start();

            Thread.Sleep(2200);
            Console.WriteLine();

            //5

            Timer timer = new Timer((o) => Console.WriteLine(DateTime.Now), null, 0, 1000);
            Thread.Sleep(5000);
            timer.Dispose();
            Console.WriteLine();


        }

        //3
        private static Mutex mutex = new Mutex();
        public static void ThreadingCounter()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(Thread1));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Thread2));
            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            thread1.Start(n);
            thread2.Start(n);
        }
        private static void Thread1(object N)
        {
            for (int i = 1; i <= (int)N; i++)
            {
                mutex.WaitOne();
                Console.WriteLine("Поток 1 работает: " + i);
                Console.WriteLine($"Информация о потоке:\n{ThreadInfo(Thread.CurrentThread)}");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }
        private static void Thread2(object N)
        {
            for (int i = 1; i <= (int)N; i++)
            {
                mutex.WaitOne();
                Console.WriteLine("Поток 2 работает: " + i);
                Console.WriteLine($"Информация о потоке:\n{ThreadInfo(Thread.CurrentThread)}");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }
        private static string ThreadInfo(Thread thread)
        {
            return $"Статус: {thread.ThreadState}\n" +
                $"Имя: {thread.Name}\n" +
                $"Приоритет: {thread.Priority}\n" +
                $"ID: {thread.GetHashCode()}\n" +
                $"-------------------------------------------";
        }

        //4
        static AutoResetEvent AutoReset1 = new AutoResetEvent(true), AutoReset2 = new AutoResetEvent(true);
        public static void even1()
        {
            for (int i = 1; i <= 10; i++)
            {
                AutoReset2.WaitOne();
                Console.WriteLine(i * 2);
                Thread.Sleep(200);
                AutoReset1.Set();
            }
        }
        public static void odd1()
        {
            for (int i = 1; i <= 10; i++)
            {
                AutoReset1.WaitOne();
                Console.WriteLine(i * 2 - 1);
                Thread.Sleep(100);
                AutoReset2.Set();
            }
        }
        public static void even()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i * 2);
                Thread.Sleep(200);
            }
        }
        public static void odd()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i * 2 - 1);
                Thread.Sleep(100);
            }
        }




    }
}
