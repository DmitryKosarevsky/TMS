using System;

namespace Lesson4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var tmsArray = CreateArray();
            InputData(ref tmsArray);
            Console.Clear();
            ViewArray(ref tmsArray);

            Console.WriteLine("Сделайте ваш выбор:");
            Console.WriteLine("1) Найти количество положительных/отрицательных чисел в матрице");
            Console.WriteLine("2) Сортировка по элементов матрицы построчно");
            Console.WriteLine("3) Инверсия элементов матрицы построчно");
            Console.WriteLine("4) Выход");
            Console.Write("\r\n Выберите действие : ");


            switch (Console.ReadLine())
            {
                case "1":
                    CountPositiveOrNegative(ref tmsArray);

                    break;
                case "2":
                    int rows = tmsArray.GetUpperBound(0) + 1;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < tmsArray.Length / rows; j++)
                        {
                            for (var g= 0; g < tmsArray.Length / rows - j -1; g++)
                            {
                                if (tmsArray[i, g] > tmsArray[i, g+1])
                                {
                                    Swap(ref tmsArray[i, g], ref tmsArray[i, g + 1]);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Вывожу отсортированный массив по возрастанию");
                    ViewArray(ref tmsArray);

                    //Сортировка по убыванию 
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < tmsArray.Length / rows; j++)
                        {
                            for (var g = 0; g < tmsArray.Length / rows - j - 1; g++)
                            {
                                if (tmsArray[i, g] < tmsArray[i, g + 1])
                                {
                                    Swap(ref tmsArray[i, g], ref tmsArray[i, g + 1]);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Вывожу отсортированный массив по убыванию");
                    ViewArray(ref tmsArray);
                    Console.ReadLine();
                    break;
                case "3":
                    int row = tmsArray.GetUpperBound(0) + 1;
                    for (int i = 0; i < row; i++)
                    {
                        int l = tmsArray.Length / row; // длина массива
                        int k = l / 2;          // середина массива
                        decimal temp;               // вспомогательный элемент для обмена значениями
                        for (int z = 0; z < k; z++)
                        {
                            temp = tmsArray[i,z];
                            tmsArray[i, z] = tmsArray[i, l - z -1];
                            tmsArray[i, l - z- 1] = temp;
                        }
                    }
                    Console.WriteLine("Вывожу массив инвертированный построчно");
                    ViewArray(ref tmsArray);
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        //метод обмена элементов
        static void Swap(ref decimal e1, ref decimal e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public static void CountPositiveOrNegative(ref decimal[,] tmsArray)
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
            Console.WriteLine($"Положительных чисел {positive}. Отрицательных {negative}");
            Console.ReadLine();
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
                        Console.WriteLine("Ошибка, вввода данных.Попробуем еще раз.");
                        Console.ReadKey();
                    }
                }
            }
        }
     
    }
}
