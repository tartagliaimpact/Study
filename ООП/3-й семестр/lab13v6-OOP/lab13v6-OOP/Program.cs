
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Text;

namespace lab13
{
    class Program
    {
        static void Main()
        {


            //1-2
            List<Journal> journals = new List<Journal>();
            journals.Add(new Journal("a", "", 1, "d"));
            journals.Add(new Journal("b", "", 2, "e"));
            journals.Add(new Journal("c", "", 3, "f"));
            journals.Add(new Journal("a", "", 4, "d"));
            journals.Add(new Journal("b", "", 5, "e"));
            CustomSerializer.XMLSerializer(journals);
            CustomSerializer.BinSerializer(journals);
            CustomSerializer.JSONSerializer(journals);
            CustomSerializer.SOAPSerializer(journals);
            List<Journal> retjournals = CustomSerializer.XMLDeserializer();
            List<Journal> retjournals1 = CustomSerializer.JSONDeserializer();
            List<Journal> retjournals2 = CustomSerializer.BinDeserializer();
            List<Journal> retjournals3 = CustomSerializer.SOAPDeserializer();

            //3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Journal.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList? nodes = xRoot?.SelectNodes("*");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }
            Console.WriteLine();
            XmlNodeList? nodes1 = xRoot?.SelectNodes("//Journal/EditionName");
            if (nodes1 is not null)
            {
                foreach (XmlNode node in nodes1)
                    Console.WriteLine(node.InnerText);
            }
            //4
            Console.WriteLine();
            string? CValue = "";
            XDocument xdoc = XDocument.Load("Jl.xml");
            //XElement elem = new XElement("ArrayOfJournal");
            XElement elem = xdoc.Element("ArrayOfJournal");
            foreach (XElement journal in elem.Elements("Journal"))
            {
                CValue = journal.Element("Cutter")?.Value;
                Console.WriteLine($"{CValue}");
            }

            Console.WriteLine();

            string? NValue = "";
            XDocument xdoc1 = XDocument.Load("Jl.xml");
            //XElement elem = new XElement("ArrayOfJournal");
            XElement Elem = xdoc.Element("ArrayOfJournal");
            foreach (XElement journal in elem.Elements("Journal"))
            {
               NValue = journal.Element("EditionName")?.Value;
                Console.WriteLine($"{NValue}");
            }
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------------------

    //Интерфейс Издатель
    interface IPublisher
    {
        string? Publisher { get; set; }
    }
    //Интерфейс ICheck для реализации одноимённых методов
    interface ICheck
    {
        public bool DoCheck();
    }

    //Абстрактный класс Печатное Издание
    [Serializable]
    abstract public class PrintedEdition : IPublisher
    {
        public string? EditionName { get; set; }
        public string? PublisherName { get; set; }

        public string? Publisher
        {
            set
            {
                PublisherName = value;
            }
            get
            {
                return PublisherName;
            }
        }
        private string? PersonName { get; set; }

        [NonSerialized]
        public string? Name;
        private int CutterNumber { get; set; }
        public int Cutter
        {
            set
            {
                CutterNumber = value;
            }
            get
            {
                return CutterNumber;
            }
        }
        public PrintedEdition(string? n, string? a, int c, string? p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }
        public PrintedEdition()
        {

        }
        public abstract bool DoCheck();
    }

    //-----------------------------------------------------------

    //Потомки класса PrintedEdition
    [Serializable]
    public class Book : PrintedEdition, ICheck
    {
        public Book(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }

        bool ICheck.DoCheck()
        {
            if (Char.IsUpper(Name[0]))
                return true;
            else return false;
        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        //Переопределение ToString
        public override string ToString()
        {
            Type info = typeof(Book);

            return info.ToString();
        }
        //переопределение Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Book m = obj as Book; // возвращает null если объект нельзя привести к типу Book
            if (m as Book == null)
                return false;

            return m.Name == this.Name && m.Cutter == this.Cutter;
        }
        //переопределение GetHashCode
        public override int GetHashCode()
        {
            return Cutter.GetHashCode();
        }
    }
    [Serializable]
    public class Journal : PrintedEdition
    {
        public Journal(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }
        public Journal() : base()
        {

        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        public override string ToString()
        {
            Type info = typeof(Journal);

            return info.ToString();
        }

    }
    //sealed class Учебник  - При применении к классу модификатор sealed запрещает другим классам наследовать от этого класса.
    [Serializable]
    sealed class TextBook : PrintedEdition
    {
        public TextBook(string? n, string? a, int c, string? p) : base(n, a, c, p)
        {
            EditionName = n;
            Name = a;
            Cutter = c;
            PublisherName = p;
        }
        public override bool DoCheck()
        {
            if (String.IsNullOrEmpty(EditionName) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(PublisherName))
                return false;
            else return true;
        }
        public override string ToString()
        {
            Type info = typeof(TextBook);

            return info.ToString();
        }
    }

    [Serializable]
    class Printer
    {
        //Витруальный метод - https://metanit.com/sharp/tutorial/3.19.php
        public virtual void IAmPrinting(IPublisher obj)
        {
            Console.WriteLine(obj.GetType().ToString() + ' ' + obj.ToString());
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------
    //Лаба 13
    //----------------------------------------------------------------------------------------------------------------------------------------
    static class CustomSerializer
    {
        public static void XMLSerializer(List<Journal> journal)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("Journal.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, journal);
            }
        }
        public static void BinSerializer(List<Journal> journal)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Journal.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, journal);
            }
        }
        public static void JSONSerializer(List<Journal> journal)
        {
            using (FileStream fs = new FileStream("Journal.json", FileMode.OpenOrCreate))
            {
                var json = Encoding.Default.GetBytes(JsonSerializer.Serialize(journal));
                fs.Write(json, 0, json.Length);
            }
        }
        public static void SOAPSerializer(List<Journal> journal)
        {
            XmlSerializer soap = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("Journal.soap", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, journal);
            }
        }


        //---------------------------------------------------------------

        public static List<Journal> JSONDeserializer()
        {
            using (FileStream fs = File.OpenRead("Journal.json"))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string journal = Encoding.Default.GetString(array);
                return JsonSerializer.Deserialize<List<Journal>>(journal);
            }
        }
        public static List<Journal> XMLDeserializer()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = File.OpenRead("Journal.xml"))
            {
                return xml.Deserialize(fs) as List<Journal>;

            }
        }
        public static List<Journal> BinDeserializer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.OpenRead("Journal.bin"))
            {
                return formatter.Deserialize(fs) as List<Journal>;
            }
        }
        public static List<Journal> SOAPDeserializer()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = File.OpenRead("Journal.soap"))
            {
                return xml.Deserialize(fs) as List<Journal>;

            }
        }

    }


}