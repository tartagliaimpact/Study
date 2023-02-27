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
        class C1
        {
            private const char const1 = 'a';
            public const char const2 = 'l';
            protected const char const3 = 's';

            private int field1;
            public int field2;
            protected int field3;

            private int property1 { get; set; }
            public char property2 { get; set; }
            protected float property3 { get; set; }

            public C1()
            { }

            public C1(C1 obj)
            {
                field1 = obj.field1;
                field2 = obj.field2;
                field3 = obj.field3;
                property1 = obj.property1;
                property2 = obj.property2;
                property3 = obj.property3;
            }

            public C1(int f1, int f2, int f3, int p1, char p2, float p3)
            {
                field1 = f1;
                field2 = f2;
                field3 = f3;
                property1 = p1;
                property2 = p2;
                property3 = p3;
            }

            private int SumInt(int f1, int f2, int f3)
            {

                return f1 + f2 + f3;
            }

            public int SumIntFields()
            {
                return SumInt(field1, field2, field3);
            }

            protected void Print()
            {
                Console.WriteLine($"Const: {const1}, {const2}, {const3}");
                Console.WriteLine($"Fields: {field1}, {field2}, {field3}");
                Console.WriteLine($"Properties: {property1}, {property2},  {property3}");
            }

            public void Show()
            {
                Print();
            }
        }
    }
}
