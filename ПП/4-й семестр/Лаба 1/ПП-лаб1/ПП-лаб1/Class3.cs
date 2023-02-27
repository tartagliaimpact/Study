using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб1_ООП
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    partial class Program
    {
        public class Person
        {
            protected string name;
            protected int age;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public Person(string n, int a)
            {
                this.Name = n;
                this.Age = a;
            }

            public void Print()
            {
                Console.WriteLine($"Имя : {this.Name},  возраст: {this.Age}");
            }
        }

        public class Worker : Person
        {
            protected int salary;
            public int Salary
            {
                get { return salary; }
                set { salary = value; }
            }

            public Worker(string n, int a, int s) : base(n, a)
            {
                base.Name = n;
                this.Age = a;
                this.Salary = s;
            }

            public void PrintInfo()
            {
                base.Print();
                Console.WriteLine($"Зарплата: {this.Salary}");
            }

        }
    }
}