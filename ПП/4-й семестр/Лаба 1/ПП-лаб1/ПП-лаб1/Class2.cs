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
        public class C2 : I1
        {
            public event Delegat Event;
            private int field1;
            public int field2;
            protected int field3;

            int c;
            private int property1 { get; set; }
            public char property2 { get; set; }
            protected float property3 { get; set; }


            public C2()
            {
                c = 0;
            }

            public C2(int f1, int f2, int f3, int p1, char p2, float p3)
            {
                field1 = f1;
                field2 = f2;
                field3 = f3;
                property1 = p1;
                property2 = p2;
                property3 = p3;
            }

            public void Count()
            {
                Console.WriteLine("Счётчик");
            }

            public int count
            {
                get { return c; }
            }

            public int this[int i]
            {
                get { return c; }
                set { c = value; }
            }

        }
    }
}