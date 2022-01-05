using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите строку содержащую буквы латинского алфавита, знаки препинания и цифры : ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(userInput));

            Console.WriteLine("Спасибо за строку.\nВ строке мы должны :");
            Console.WriteLine("1) Найти слова, содержащие максимальное количество цифр.");
            Console.WriteLine("2) Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.");
            Console.WriteLine("3) Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».");
            Console.WriteLine("4) Вывести на экран сначала вопросительные, а затем восклицательные предложения.");
            Console.WriteLine("5) Вывести на экран только предложения, не содержащие запятых.");
            Console.WriteLine("6) Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.");
            Console.WriteLine("\nВведите цифру : ");

            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    string[] arrWords = userInput.Split(new char[] { ' ', ':', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var arrSorted = arrWords.Where(x => double.TryParse(x, out double userInputResult)).OrderByDescending(s => s.Length).ToList();

                    if (arrSorted.Count > 0)
                    {
                        var maxLength = arrSorted.FirstOrDefault().Length;
                        Console.WriteLine("Самые длинные числа :" + string.Join(", ", arrSorted.Where(x => x.Length == maxLength)));
                    }
                    else
                    {
                        Console.WriteLine("В строке нет чисел");
                    }
                    break;
                case "2":
                    string[] arrLongWord = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var longWord = arrLongWord.OrderByDescending(x => x.Length).FirstOrDefault();
                    if (longWord != null)
                    {
                        Console.WriteLine($"Самое длинное слово : {longWord} встретилось {arrLongWord?.Where(x => x.Contains(longWord)).Count()} раз.");
                    }
                    break;
                case "3":
                    Console.WriteLine(userInput
                        .Replace("1", "один ")
                        .Replace("2", "два ")
                        .Replace("3", "три ")
                        .Replace("4", "четыре ")
                        .Replace("5", "пять ")
                        .Replace("6", "шесть ")
                        .Replace("7", "семь ")
                        .Replace("8", "восемь ")
                        .Replace("9", "девять ")
                        .Replace("0", "ноль "));
                    break;
                case "4":
                    Regex re = new Regex(@"(\w+\s*)+[!?]");
                    List<string> strings = new List<string>();
                    foreach (Match item in re.Matches(userInput))
                    {
                        strings.Add(item.Value);
                    }
                    foreach (string item in strings.OrderBy((x) => !x.EndsWith("?")))
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadKey();
                    break;
                case "5":
                    string[] arraySentence = userInput.Split(new char[] { '.', '!', '?' });
                    foreach (string item in arraySentence)
                    {
                        if (!item.Contains(','))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "6":
                    string[] arrWord = userInput.Split(new char[] { '.', ',', '!', '?', ' ' });

                    foreach (var item in arrWord)
                    {
                        if (item[0] == item[item.Length - 1]) Console.WriteLine(item);
                    }

                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
