using System;

namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tmsArray = CreateArray();
            InputData(ref tmsArray);
            Console.Clear();
            ViewArray(ref tmsArray);

            ShowMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    var tuple = CountPositiveOrNegative(ref tmsArray);
                    Console.WriteLine($"Положительных чисел {tuple.positive}. Отрицательных {tuple.negative}");
                    break;
                case "2":
                    SortArray(ref tmsArray, true);
                    Console.WriteLine("Вывожу отсортированный массив по возрастанию");
                    ViewArray(ref tmsArray);

                    SortArray(ref tmsArray, false);
                    Console.WriteLine("Вывожу отсортированный массив по убыванию");
                    ViewArray(ref tmsArray);
                    break;
                case "3":
                    InvertArray(ref tmsArray);
                    Console.WriteLine("Вывожу массив инвертированный построчно");
                    ViewArray(ref tmsArray);
                    break;
                case "4":
                    Console.WriteLine("Good Bye!");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            Console.ReadLine();
        }

        private static void ShowMenu()
        {
            const string textInfo =
                "Сделайте ваш выбор:\n" +
                "1) Найти количество положительных/отрицательных чисел в матрице\n" +
                "2) Сортировка по элементов матрицы построчно\n" +
                "3) Инверсия элементов матрицы построчно\n" +
                "4) Выход\n\n" +
                "Выберите действие: ";
            Console.Write(textInfo);
        }

        /// <summary>Метод инвертирования массива</summary>
        /// <param name="tmsArray">массив по ссылке</param>
        /// <returns></returns>
        private static void InvertArray(ref decimal[,] tmsArray)
        {
            int row = tmsArray.GetUpperBound(0) + 1;
            for (int i = 0; i < row; i++)
            {
                int l = tmsArray.Length / row; // длина массива
                int k = l / 2;          // середина массива
                for (int j = 0; j < k; j++)
                {
                    Swap(ref tmsArray[i, j], ref tmsArray[i, l - j - 1]);
                }
            }
        }

        /// <summary>Сортировка построчно массива</summary>
        /// <param name="tmsArray">массив по ссылке</param>
        /// <param name="direction">true - по возрастанию</param>
        /// <returns></returns>
        private static void SortArray(ref decimal[,] tmsArray, bool direction = true)
        {
            int rows = tmsArray.GetUpperBound(0) + 1;

            //Сортировка 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < tmsArray.Length / rows; j++)
                {
                    for (var g = 0; g < tmsArray.Length / rows - j - 1; g++)
                    {
                        if (direction) //true - по возрастанию
                        {
                            if (tmsArray[i, g] > tmsArray[i, g + 1])
                            {
                                Swap(ref tmsArray[i, g], ref tmsArray[i, g + 1]);
                            }
                        }
                        else
                        {
                            if (tmsArray[i, g] < tmsArray[i, g + 1])
                            {
                                Swap(ref tmsArray[i, g], ref tmsArray[i, g + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Метод обмена элементов </summary>
        /// <param name="e1">первый элемент</param>
        /// <param name="e2">второй элемент</param>
        static void Swap(ref decimal e1, ref decimal e2)
        {
            var temp = e1; // вспомогательный элемент для обмена значениями
            e1 = e2;
            e2 = temp;
        }

        public static (int positive, int negative) CountPositiveOrNegative(ref decimal[,] tmsArray)
        {
            int positive = 0;
            int negative = 0;
            int rows = tmsArray.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < tmsArray.Length / rows; j++)
                {
                    var result = Math.Sign(tmsArray[i, j]);

                    if (result > 0)
                    {
                        positive++;
                    }
                    else
                    {
                        if (result < 0)
                        {
                            negative++;
                        }
                    }
                }
            }
            return (positive, negative);
        }

        public static void ViewArray(ref decimal[,] tmsArray)
        {
            int rows = tmsArray.GetUpperBound(0) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < tmsArray.Length / rows; j++)
                {
                    Console.Write($"{tmsArray[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static decimal[,] CreateArray()
        {
            Console.WriteLine("Введите количество строк в массиве");
            var rows = Console.ReadLine();
            Console.WriteLine("Введите количество столбцов в массиве");
            var columns = Console.ReadLine();

            if (!int.TryParse(rows, out int rowsResult) || !int.TryParse(columns, out int columnsResult) || rowsResult <= 1 || columnsResult <= 1)
            {
                Console.WriteLine("Ошибка, необходимо ввести число >=1");
                Console.ReadKey();
                return null;
            }

            return new decimal[rowsResult, columnsResult];
        }
        public static void InputData(ref decimal[,] tmsArray)
        {
            int rows = tmsArray.GetUpperBound(0) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < tmsArray.Length / rows;)
                {
                    Console.Clear();
                    ViewArray(ref tmsArray);
                    Console.WriteLine($"Для строки {i + 1}, столбца {j + 1} введите число");

                    if (decimal.TryParse(Console.ReadLine(), out decimal inputRowsValue))
                    {
                        tmsArray[i, j] = inputRowsValue;
                        j++;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода данных.Попробуем еще раз.");
                        Console.ReadKey();
                    }
                }
            }
        }

    }
}