using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб1_ООП
{
    partial class Program
    {
        static void Main()
        {
            C1 obj1 = new C1();
            C1 obj2 = new C1(1, 2, 3, 4, 'd', 5.0F);
            C1 obj3 = new C1(obj2);

            Console.Write(obj2.SumIntFields());
            Console.WriteLine();
            obj1.Show();
            Console.WriteLine();
            obj2.Show();
            Console.WriteLine();
            obj3.Show();
            Console.WriteLine();

            C2 obj4 = new C2();
            C2 obj5 = new C2(1, 2, 3, 4, 'd', 5.0F);
            obj5.Count();

            Worker worker1 = new Worker("Tom", 21, 600);
            worker1.Print();
            Console.WriteLine();
            worker1.PrintInfo();

            Console.WriteLine();

            Person person1 = new Person("Aki", 19);
            Worker worker2 = new Worker(person1.Name, person1.Age, 500);
            worker2.Print();
            Console.WriteLine();
            worker2.PrintInfo();
        }
    }
}