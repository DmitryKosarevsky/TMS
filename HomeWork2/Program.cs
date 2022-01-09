using System;

namespace TMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите день недели (от 1 до 7)");
            var inputUser = Console.ReadLine();
            var result = -1;

            if (inputUser != null && int.TryParse(inputUser, out result)) ;
            switch (result)
            {
                case 1:
                    Console.WriteLine("Понедельник");
                    break;
                case 2:
                    Console.WriteLine("Вторник");
                    break;
                case 3:
                    Console.WriteLine("Среда");
                    break;
                case 4:
                    Console.WriteLine("Четверг");
                    break;
                case 5:
                    Console.WriteLine("Пятница");
                    break;
                case 6:
                    Console.WriteLine("Суббота");
                    break;
                case 7:
                    Console.WriteLine("Воскресенье");
                    break;
                default:
                    Console.WriteLine("Необходимо ввести цифру в диапазоне от 1 до 7");
                    break;
            }

            Console.ReadKey();
        }
    }
}
