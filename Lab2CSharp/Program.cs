using System;
using System.Linq;

namespace Lab2CSharp
{
    public class Program // Додано public
    {
        public static void Main(string[] args) // Додано public
        {
            while (true)
            {
                Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Завдання 1.1 (Заміна елементів)");
                Console.WriteLine("2. Завдання 2.1 (Номери мінімальних елементів)");
                Console.WriteLine("3. Завдання 3.6 (Перестановка рядків матриці)");
                Console.WriteLine("4. Завдання 4.6 (Східчастий масив: перший додатний у стовпці)");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Будь ласка, введіть число.");
                    continue;
                }

                switch (choice)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    case 0: 
                        Console.WriteLine("Завершення роботи..."); 
                        return;
                    default: 
                        Console.WriteLine("Невірний вибір."); 
                        break;
                }
            }
        }

        // Завдання 1.1: Замінити всі елементи, менші заданого числа, цим числом.
        public static void Task1() // Додано public
        {
            Console.WriteLine("\n--- Завдання 1.1 ---");
            Console.Write("Введіть розмірність одновимірного масиву (n): ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"arr[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Введіть задане число для порівняння: ");
            int target = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < target)
                {
                    arr[i] = target;
                }
            }

            Console.WriteLine("Змінений масив:");
            Console.WriteLine(string.Join(" ", arr));
        }

        // Завдання 2.1: Вивести на екран номери всіх мінімальних елементів.
        public static void Task2() // Додано public
        {
            Console.WriteLine("\n--- Завдання 2.1 ---");
            Console.Write("Кількість рядків: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Кількість стовпців: ");
            int cols = int.Parse(Console.ReadLine());

            double[,] arr = new double[rows, cols];
            double min = double.MaxValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"arr[{i},{j}] = ");
                    arr[i, j] = double.Parse(Console.ReadLine());
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }
            }

            Console.WriteLine($"Мінімальний елемент: {min}");
            Console.WriteLine("Індекси мінімальних елементів (рядок, стовпець):");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[i, j] == min)
                    {
                        Console.WriteLine($"[{i}, {j}]");
                    }
                }
            }
        }

        // Завдання 3.6: Поміняти місцями рядки.
        public static void Task3() // Додано public
        {
            Console.WriteLine("\n--- Завдання 3.6 ---");
            Console.Write("Введіть кількість рядків (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість стовпців (m): ");
            int m = int.Parse(Console.ReadLine());

            // Спосіб 1: Двовимірний масив
            Console.WriteLine("\n--- Вирішення двовимірним масивом ---");
            int[,] matrix2D = new int[n, m];
            FillMatrix(matrix2D, n, m);
            Console.WriteLine("Початкова матриця:");
            PrintMatrix(matrix2D, n, m);

            if (n % 2 == 0) // Парна кількість рядків
            {
                int mid1 = n / 2 - 1;
                int mid2 = n / 2;
                SwapRows2D(matrix2D, mid1, mid2, m);
                Console.WriteLine($"Переставлено середні рядки ({mid1} та {mid2}):");
            }
            else // Непарна кількість рядків
            {
                int mid = n / 2;
                SwapRows2D(matrix2D, 0, mid, m);
                Console.WriteLine($"Переставлено перший (0) та середній ({mid}) рядки:");
            }
            PrintMatrix(matrix2D, n, m);

            // Спосіб 2: Одновимірний масив
            Console.WriteLine("\n--- Вирішення одновимірним масивом ---");
            int[] matrix1D = new int[n * m];
            int count = 1;
            for (int i = 0; i < n * m; i++) matrix1D[i] = count++;

            Console.WriteLine("Початковий одновимірний масив (як матриця):");
            PrintMatrix1D(matrix1D, n, m);

            if (n % 2 == 0)
            {
                SwapRows1D(matrix1D, n / 2 - 1, n / 2, m);
            }
            else
            {
                SwapRows1D(matrix1D, 0, n / 2, m);
            }
            Console.WriteLine("Змінений одновимірний масив:");
            PrintMatrix1D(matrix1D, n, m);
        }

        // Завдання 4.6: Перший додатній елемент у стовпці східчастого масиву.
        public static void Task4() // Додано public
        {
            Console.WriteLine("\n--- Завдання 4.6 ---");
            Console.Write("Введіть кількість рядків східчастого масиву: ");
            int n = int.Parse(Console.ReadLine());
            
            int[][] jaggedArr = new int[n][];
            int maxCols = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Скільки елементів у рядку {i}?: ");
                int m = int.Parse(Console.ReadLine());
                jaggedArr[i] = new int[m];
                
                if (m > maxCols) maxCols = m;

                for (int j = 0; j < m; j++)
                {
                    Console.Write($"jaggedArr[{i}][{j}] = ");
                    jaggedArr[i][j] = int.Parse(Console.ReadLine());
                }
            }

            int?[] result = new int?[maxCols];

            for (int col = 0; col < maxCols; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    if (col < jaggedArr[row].Length && jaggedArr[row][col] > 0)
                    {
                        result[col] = jaggedArr[row][col];
                        break; 
                    }
                }
            }

            Console.WriteLine("\nМасив перших додатних елементів стовпців (порожньо, якщо не знайдено):");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Стовпець {i}: {(result[i].HasValue ? result[i].ToString() : "Немає додатних")}");
            }
        }

        // --- Допоміжні методи ---
        public static void FillMatrix(int[,] arr, int n, int m) // Додано public
        {
            int val = 1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = val++; 
        }

        public static void PrintMatrix(int[,] arr, int n, int m) // Додано public
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{arr[i, j], 4}");
                Console.WriteLine();
            }
        }

        public static void SwapRows2D(int[,] arr, int row1, int row2, int cols) // Додано public
        {
            for (int j = 0; j < cols; j++)
            {
                int temp = arr[row1, j];
                arr[row1, j] = arr[row2, j];
                arr[row2, j] = temp;
            }
        }

        public static void PrintMatrix1D(int[] arr, int n, int m) // Додано public
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{arr[i * m + j], 4}");
                Console.WriteLine();
            }
        }

        public static void SwapRows1D(int[] arr, int row1, int row2, int cols) // Додано public
        {
            for (int j = 0; j < cols; j++)
            {
                int temp = arr[row1 * cols + j];
                arr[row1 * cols + j] = arr[row2 * cols + j];
                arr[row2 * cols + j] = temp;
            }
        }
    }
}