using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Program
    {

        static void Main(string[] args)
        {
           var array=CreateArray();
           InputData(ref array);
        }

        public static decimal[,] CreateArray()
        {
            Console.WriteLine("Введите количество строк в массиве");
            var rows = Console.ReadLine();
            Console.WriteLine("Введите количество столбцов в массиве");
            var columns = Console.ReadLine();

            if (!int.TryParse(rows, out int rowsResult) || !int.TryParse(columns, out int columnsResult) || rowsResult<=1 || columnsResult<=1)
            {
                Console.WriteLine("Ошибка, необходимо ввести число >=1");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine($"Создаем массив {rowsResult}х{columnsResult}");
            decimal[,] tmsArray = new decimal[rowsResult, columnsResult];

            return tmsArray;
        }
        public static void InputData(ref decimal[,] array)
        {
             int rows = array.GetUpperBound(0) + 1;

            for (int j = 0; j < array.Length / rows;)
            {
                for (int i = 0; i < rows;)
                {
                    Console.WriteLine($"Для строки {j + 1}, столбца {i + 1} введите число");

                    if (decimal.TryParse(Console.ReadLine(), out decimal inputRowsValue))
                    {
                        array[j, i] = inputRowsValue;
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, вввода данных.Попробуем еще раз.");
                    }
                }
                j++;
            }

            Console.ReadKey();
        }}
}
