using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lesson5
{
    class Program
    {
        public static string InputString()
        {
            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите строку содержащую буквы латинского алфавита, знаки препинания и цифры : ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(userInput));
            return userInput;
        }

        static void Main(string[] args)
        {
            var userInput = InputString();
            const string infoText =
                "Спасибо за строку.\nВ строке мы должны :\n" +
                "1) Найти слова, содержащие максимальное количество цифр.\n" +
                "2) Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\n" +
                "3) Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».\n" +
                "4) Вывести на экран сначала вопросительные, а затем восклицательные предложения.\n" +
                "5) Вывести на экран только предложения, не содержащие запятых.\n" +
                "6) Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.\n\n"+
                "Введите цифру : ";

            Console.WriteLine(infoText);

            switch (Console.ReadLine())
            {
                case "1":
                    string[] arrWords = userInput.Split(new char[] { ' ', ':', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var arrSorted = arrWords.Where(x => double.TryParse(x, out double userInputResult)).OrderByDescending(s => s.Length).ToList();

                    if (arrSorted.Count > 0)
                    {
                        var maxLength = arrSorted[0].Length;
                        Console.WriteLine("Самые длинные числа: " + string.Join(", ", arrSorted.Where(x => x.Length == maxLength)));
                    }
                    else
                    {
                        Console.WriteLine("В строке нет чисел");
                    }
                    break;
                case "2":
                    string[] arrLongWord = userInput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var longWord = arrLongWord.OrderByDescending(x => x.Length).FirstOrDefault();
                    Console.WriteLine($"Самое длинное слово : {longWord} встретилось {arrLongWord?.Where(x => x.Contains(longWord)).Count()} раз.");
                    break;
                case "3":
                    Console.WriteLine(userInput
                        .Replace("1", "один")
                        .Replace("2", "два")
                        .Replace("3", "три")
                        .Replace("4", "четыре")
                        .Replace("5", "пять")
                        .Replace("6", "шесть")
                        .Replace("7", "семь")
                        .Replace("8", "восемь")
                        .Replace("9", "девять")
                        .Replace("0", "ноль"));
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
                    break;
                case "5":
                    string[] arraySentence = userInput.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
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
                    Console.WriteLine("Неверный выбор");
                    break;
            }

            Console.ReadLine();
        }
    }
}
