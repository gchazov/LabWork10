﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //класс для работы с пользовательским интерфейсом и вводом-выводом
    //класс создан только для упрощения ввода-вывода, не больше
    public class Dialog
    {
        public static int EnterNumber(string welcomeString, int left, int right)
        {
            int number = 0;
            bool isParsed = false;
            do
            {
                Console.WriteLine(welcomeString);
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number >= left && number <= right)
                    {
                        isParsed = true;
                    }
                    else
                    {
                        ColorText("Вы ввели некорректное значение! Попробуйте ещё раз...");
                    }
                }

                catch (OverflowException)
                {
                    ColorText("Вы ввели слишком большое значение! Попробуйте ещё раз...");
                }

                catch (FormatException)
                {
                    ColorText("Введённое значение имеет неверный фор-мат данных! Попробуйте ещё раз...");
                }
            } while (!isParsed);
            return number;
        }

        public static string EnterString(string welcomeString, bool containsNum, bool notEmpty)
        {
            Console.WriteLine(welcomeString);
            string str = "";
            bool isParsed = false;
            do
            {
                bool isNumeric = false;
                bool isNotEmpty = true;
                str = Console.ReadLine();
                foreach (char symbol in str)
                {
                    if (char.IsDigit(symbol))
                    {
                        isNumeric = true;
                        break;
                    }
                }
                if (str == "")
                {
                    isNotEmpty = false;
                }

                if (containsNum == isNumeric && notEmpty == isNotEmpty)
                {
                    isParsed = true;
                }
                else
                {
                    ColorText("Строка введена некорректно!");
                }
            } while (!isParsed);
            return str;
        }

        public static bool EnterBool(string welcomeString)
        {
            bool result = false;
            bool isParsed = false;
            do
            {
                isParsed = bool.TryParse(Console.ReadLine(), out result);
                if (!isParsed)
                {
                    ColorText("Введённое значение не является логическим! Попробуйте ещё раз...");
                }
            } while (!isParsed);
            return result;
        }
        
        public static void PrintHeader(string header)
        {
            Console.Clear();
            ColorText("_________/" + header.ToUpper() + @"\_________" + "\n", "cyan");
        }

        public static void ColorText(string text, string colorizing = "red")
        {
            string color = colorizing.ToLower();
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void BackMessage()
        {
            Console.WriteLine("\nНажмите Enter для возвращения в предыдущее меню...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
