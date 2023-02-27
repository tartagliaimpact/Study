//События - https://metanit.com/sharp/tutorial/3.14.php
//Делегаты -  https://metanit.com/sharp/tutorial/3.13.php

using System;
using System.Text;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Персонаж 1");
            Game game = new();
            game.Attack += message => Console.WriteLine(message);
            game.attack();
            game.Heal += message => Console.Write(message);
            game.heal();
            Console.WriteLine();

            Console.WriteLine("\nПерсонаж 2");
            Game game1 = new();
            game1.Attack += message => Console.WriteLine(message);
            game1.attack();
            game1.attack();
            game1.Heal += message => Console.Write(message);
            game1.heal();
            Console.WriteLine();

            // Обработка строки
            //https://metanit.com/sharp/tutorial/3.33.php - про делегат func
            string String = " Строка     для обработки:!?";
            StringProcessing str = new StringProcessing();
            Func<string, string> StringDelegate = str => str.ToLower();
            //Здесь переменная StringDelegate представляет лямбда - выражение, которое принимает строку и возвращает строку, то есть представляет делегат Func<string, string>.
            String = StringDelegate(String);
            Console.WriteLine(String);
            StringDelegate += str => str.ToUpper();
            String = StringDelegate(String);
            Console.WriteLine(String);
            StringDelegate += str.RemovePunctuationMarks;
            String = StringDelegate(String);
            Console.WriteLine(String);
            StringDelegate += str.Trim;
            String = StringDelegate(String);
            Console.WriteLine(String);
            Func<string, char, string> StringDelegate1 = (str, ch) => str += ch;
            //Здесь переменная StringDelegate1 представляет лямбда - выражение, которое принимает строку и символ и возвращает строку, то есть представляет делегат Func<string, char, string>.
            String = StringDelegate1(String, 'l');
            Console.WriteLine(String);

        }
        class Game
        {
            public delegate void Event(string? game);
            public event Event? Attack;
            public event Event? Heal;
            public int HP = 100;
            public void attack()
            {
                Random rndd = new Random();
                if (HP > 0)
                {
                    int dmg = rndd.Next(0, 90);
                    HP = HP - dmg;
                    Attack?.Invoke($"Получен урон: {dmg}.");
                    if(HP < 0) 
                    { 
                        HP = 0;
                        Attack?.Invoke($"Персонаж повержен");
                    }
                    Attack?.Invoke($"Текущее здровье : {HP}");
                }
            }
            public void heal()
            {
                Random rndh = new Random();
                if (HP < 100) 
                {
                    if(HP == 0)
                    {
                        Heal?.Invoke($"Персонаж воскрешён :");
                    }
                    int hl = rndh.Next(10, 60);
                    HP = HP + hl;
                    Heal?.Invoke($"Здоровье повышено на {hl}");
                    if (HP > 100)
                    {
                        HP = 100;
                    }
                    Heal?.Invoke($". Текущее здровье : {HP}");
                }
            }
        }
        class StringProcessing
        {
            //Удаление знаков препинания
            public string RemovePunctuationMarks(string str)
            {
                string PunctuatinMarks = ",.;:-!?";
                for (int i = 0; i < str.Length; i++)
                {
                    foreach (char PunctuationMark in PunctuatinMarks)
                        if (str[i] == PunctuationMark)
                            str = str.Remove(i, 1);
                }
                return str;
            }
            public string Trim(string str)
            {
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == ' ' && str[i + 1] == ' ')
                        str = str.Remove(i + 1, 1);
                return str;
            }
        }
    }
}