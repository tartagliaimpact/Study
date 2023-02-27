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
        public delegate void Delegat(string s);

        interface I1
        {
            public int count { get; }
            public void Count();

            public event Delegat Event;

            public int this[int i] { get; set; }
        }

    }
}
