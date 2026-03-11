using System;
using System.IO;
using Xunit;
using Lab2CSharp; // Підключаємо основний проєкт

namespace Lab2CSharp.Tests
{
    public class ProgramTests
    {
        // Метод для перехоплення консолі
        private string RunWithConsoleMock(Action taskAction, string input)
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            using var stringWriter = new StringWriter();
            using var stringReader = new StringReader(input);
            
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            try
            {
                taskAction();
                return stringWriter.ToString();
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [Fact]
        public void Task1_ReplacesSmallerElementsWithTarget()
        {
            // Масив з 3 елементів: 5, 1, 8. Target = 4.
            // Очікуємо: 1 має замінитися на 4. Результат: "5 4 8"
            string input = "3\n5\n1\n8\n4\n";
            
            string output = RunWithConsoleMock(Program.Task1, input);

            Assert.Contains("Змінений масив:", output);
            Assert.Contains("5 4 8", output);
        }

        [Fact]
        public void Task2_FindsMultipleMinimumElements()
        {
            // Матриця 2x2: 
            // 5  2
            // 2  8
            // Мінімальний: 2. Індекси: [0, 1] та [1, 0]
            string input = "2\n2\n5\n2\n2\n8\n";
            
            string output = RunWithConsoleMock(Program.Task2, input);

            Assert.Contains("Мінімальний елемент: 2", output);
            Assert.Contains("[0, 1]", output);
            Assert.Contains("[1, 0]", output);
        }

        [Fact]
        public void Task3_SwapsRowsSuccessfully_ConsoleOutput()
        {
            // 4 рядки, 2 стовпці (парна кількість рядків)
            // Має переставити середні (рядок 1 та рядок 2)
            string input = "4\n2\n";
            
            string output = RunWithConsoleMock(Program.Task3, input);

            Assert.Contains("Переставлено середні рядки (1 та 2):", output);
        }

        [Fact]
        public void Task4_FindsFirstPositiveInJaggedArray()
        {
            // 2 рядки.
            // Рядок 0 має 2 ел: -1, 5
            // Рядок 1 має 3 ел: 3, -2, 7
            // Очікуємо по стовпцях:
            // Стовпець 0: перший додатний = 3 (з рядка 1)
            // Стовпець 1: перший додатний = 5 (з рядка 0)
            // Стовпець 2: перший додатний = 7 (з рядка 1)
            string input = "2\n2\n-1\n5\n3\n3\n-2\n7\n";
            
            string output = RunWithConsoleMock(Program.Task4, input);

            Assert.Contains("Стовпець 0: 3", output);
            Assert.Contains("Стовпець 1: 5", output);
            Assert.Contains("Стовпець 2: 7", output);
        }

        // === Прямі тести допоміжних методів ===
        // Оскільки ти винесла логіку перестановки в окремі методи, їх можна
        // тестувати напряму, взагалі без милиць з Console! Це найкраща практика.

        [Fact]
        public void SwapRows2D_SwapsCorrectly()
        {
            // Arrange (Підготовка)
            int[,] matrix = {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };

            // Act (Дія) - міняємо місцями рядок 0 та рядок 2
            Program.SwapRows2D(matrix, 0, 2, 2);

            // Assert (Перевірка)
            Assert.Equal(5, matrix[0, 0]);
            Assert.Equal(6, matrix[0, 1]);
            Assert.Equal(1, matrix[2, 0]);
            Assert.Equal(2, matrix[2, 1]);
        }

        [Fact]
        public void SwapRows1D_SwapsCorrectly()
        {
            // Матриця 3x2 у вигляді одновимірного масиву
            // Рядок 0: 1, 2 (індекси 0, 1)
            // Рядок 1: 3, 4 (індекси 2, 3)
            // Рядок 2: 5, 6 (індекси 4, 5)
            int[] array = { 1, 2, 3, 4, 5, 6 };

            // Міняємо місцями рядок 1 і рядок 2
            Program.SwapRows1D(array, 1, 2, 2);

            // Очікуємо: 1, 2, 5, 6, 3, 4
            int[] expected = { 1, 2, 5, 6, 3, 4 };
            Assert.Equal(expected, array);
        }
    }
}