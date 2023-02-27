using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab11
{
    public static class Reflector
    {
        public async static void WriteInTxt(object item) // async - ассинхронные методы https://metanit.com/sharp/tutorial/13.3.php
        {
            string Message = "";
            using (StreamWriter f = new StreamWriter("reflector.txt", true))
            {
                Message = "" + item;
                await f.WriteLineAsync(Message);
            }
        }


        //a. Определение имени сборки, в которой определен класс;
        public static void AssemblyName(Object obj)
        {
            Console.WriteLine("a. Определение имени сборки, в которой определен класс : ");
            Type type = obj.GetType();
            Console.WriteLine(Assembly.GetAssembly(type).GetName().FullName);
            Console.WriteLine();
            WriteInTxt(Assembly.GetAssembly(type).GetName().FullName);
            WriteInTxt("\n");

        }
        //b.есть ли публичные конструкторы;
        public static void PublicConstructors(Object obj)
        {
            Console.WriteLine("b.есть ли публичные конструкторы : ");
            Type type = obj.GetType();
            ConstructorInfo[] constr = type.GetConstructors(); //Метод GetConstructors() возвращает все конструкторы данного типа в виде набора объектов ConstructorInfo
            if (constr != null)
            {
                foreach (ConstructorInfo c in constr)
                {
                    Console.WriteLine(c); //выводит Void .ctor() - конструктор по умолчанию
                    WriteInTxt(c);
                }
            }
            else
            {
                Console.WriteLine("");
            }
            Console.WriteLine();
            WriteInTxt("\n");
        }
        //c. извлекает все общедоступные публичные методы класса(возвращает IEnumerable<string>);
        public static List<string> PublicMethods(Object obj)
        {
            Console.WriteLine("c. извлекает все общедоступные публичные методы класса(возвращает IEnumerable<string>) : ");
            Type type = obj.GetType();
            List<string> PublicMethodsList = new List<string>();

            var AllMethods = type.GetMethods();
            foreach (var MI in AllMethods)
            {
                if (MI.IsPublic)
                {
                    PublicMethodsList.Add(MI.Name);
                    WriteInTxt(MI.Name);
                }
            }
            WriteInTxt("\n");
            Console.WriteLine();
            return PublicMethodsList;
        }

        //d.получает информацию о полях и свойствах класса(возвращает IEnumerable<string>);
        public static List<string> FieldsAndProperties(Object obj)
        {
            Console.WriteLine("d.получает информацию о полях и свойствах класса(возвращает IEnumerable<string>) : ");
            Type type = obj.GetType();
            List<string> FieldsAndPropertiesList = new List<string>();

            var AllFields = type.GetFields();

            var AllProperties = type.GetProperties();

            Console.WriteLine("Поля : ");
            WriteInTxt("Поля : ");
            foreach (var FP in AllFields)
            {
                FieldsAndPropertiesList.Add(FP.Name);
                Console.WriteLine(FP.Name);
                WriteInTxt(FP.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Свойства : ");
            WriteInTxt("Свойства : ");
            foreach (var FP in AllProperties)
            {
                FieldsAndPropertiesList.Add(FP.Name);
                Console.WriteLine(FP.Name);
                WriteInTxt(FP.Name);
            }
            Console.WriteLine();
            WriteInTxt("\n");

            return FieldsAndPropertiesList;
        }

        //e. получает все реализованные классом интерфейсы (возвращает  IEnumerable<string>); 
        public static List<string> ClassInterfaces(Object obj)
        {
            Console.WriteLine("e. получает все реализованные классом интерфейсы (возвращает  IEnumerable<string>) : ");
            Type type = obj.GetType();
            List<string> InterfacesList = new List<string>();

            var AllInterfaces = type.GetInterfaces();

            foreach (var I in AllInterfaces)
            {
                InterfacesList.Add(I.Name);
                Console.WriteLine(I.Name);
                WriteInTxt(I.Name);
            }
            Console.WriteLine();
            WriteInTxt("\n");
            return InterfacesList;
        }

        //f. выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра(имя класса передается в качестве аргумента);
        public static void MethodsByParameter(object obj, Type Parameter)
        {
            Console.WriteLine($"f. выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра {Parameter.Name} (имя класса передается в качестве аргумента) : ");

            Type type = obj.GetType();

            var AllMethods = type.GetMethods();
            foreach (var MI in AllMethods)
            {
                var MIP = MI.GetParameters();
                foreach (var Pa in MIP)
                {
                    if (Pa.ParameterType == Parameter)
                    {
                        Console.WriteLine(Pa);
                        WriteInTxt(Pa);
                        break;
                    }
                }
            }
            Console.WriteLine();
            WriteInTxt("\n");
        }

        //g.метод Invoke, который вызывает метод класса, ну, в нё нет чтения из файла и генерации значений, так как я не совсем понял как именно это реализовать
        public static object? Invoke(object obj, string MethodName, object?[]? Parameters)
        {
            Type type = obj.GetType();
            var Method = type.GetMethod(MethodName);
            var Result = Method.Invoke(obj, Parameters);
            return Result;
        }

        //обобщенный метод Create
        static public T Create<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

    }
}