using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTable;
using System;
using System.Collections.Generic;
using System.IO;

namespace PrimeTableTests
{
    [TestClass]
    public class PrimeTable
    {
        [TestMethod]
        public void TestGeneratePrimeMultiplicationTable()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddTransient<CreateMultiplicationTable>()
                .AddTransient<CreateListofPrimeNumbers>()
                .AddTransient<DisplayPrimeTable>()
                .BuildServiceProvider();

            
            var calculatePrimeValues = new DisplayPrimeTable(serviceProvider.GetRequiredService<CreateMultiplicationTable>(), serviceProvider.GetRequiredService<CreateListofPrimeNumbers>());

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Simulate user input
                Console.SetIn(new StringReader("5"));

                calculatePrimeValues.GeneratePrimeMutliplicationTable(5);

                var result = sw.ToString().Trim();

                // Assert
                StringAssert.Contains(result, "Prime Multiplication Table:");
                StringAssert.Contains(result, "       2     3     5     7    11");
                StringAssert.Contains(result, " 2 |   4 |   6 |  10 |  14 |  22 |");
                StringAssert.Contains(result, " 3 |   6 |   9 |  15 |  21 |  33 |");
                StringAssert.Contains(result, " 5 |  10 |  15 |  25 |  35 |  55 |");
                StringAssert.Contains(result, " 7 |  14 |  21 |  35 |  49 |  77 |");
                StringAssert.Contains(result, "11 |  22 |  33 |  55 |  77 | 121 |");
            }
        }

        [TestMethod]
        [DataRow(2, new int[] { 2, 3 })]
        [DataRow(4, new int[] { 2, 3, 5, 7 })]
        [DataRow(5, new int[] { 2, 3, 5, 7, 11 })]
        [DataRow(11, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 })]
        public void TestGenerateListofPrimeNumbers(int number, int[] expected)
        {
            // Arrange
            var createListofPrimeNumbers = new CreateListofPrimeNumbers();

            // Act
            List<int> primes = createListofPrimeNumbers.GeListOfPrimeNumbers(number);

            // Assert
            CollectionAssert.AreEqual(expected, primes);
        }

        [TestMethod]
        public void TestGetMultiplicationTableForGivenList()
        {
            // Arrange
            var createMultiplicationTable = new CreateMultiplicationTable();
            var primeNumbers = new List<int> { 2, 3, 5 };

            // Act
            int[,] table = createMultiplicationTable.GetMultiplicationTableForGivenList(primeNumbers);

            // Assert
            CollectionAssert.AreEqual(new[,] { { 4, 6, 10 }, { 6, 9, 15 }, { 10, 15, 25 } }, table);
        }

        [TestMethod]
        [DataRow(13, true)]
        [DataRow(17, true)]
        [DataRow(23, true)]
        [DataRow(73, true)]
        [DataRow(97, true)]
        public void IsPrime_ReturnsTrueIfNumberIsPrime(int number, bool expected)
        {
            // Arrange
            var createListofPrimeNumbers = new CreateListofPrimeNumbers();

            // Act
            bool isPrime = createListofPrimeNumbers.IsPrime(number);

            // Assert
            Assert.AreEqual(isPrime, expected);

        }

        [TestMethod]
        [DataRow(12, false)]
        [DataRow(16, false)]
        [DataRow(24, false)]
        [DataRow(64, false)]
        [DataRow(88, false)]
        public void IsPrime_ReturnsFalseIfNumberIsNonPrime(int number, bool expected)
        {
            // Arrange
            var createListofPrimeNumbers = new CreateListofPrimeNumbers();

            // Act
            bool isPrime = createListofPrimeNumbers.IsPrime(number);

            // Assert
            Assert.AreEqual(isPrime, expected);

        }
    }
}
