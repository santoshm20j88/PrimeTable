using System;
using System.Collections.Generic;

namespace PrimeTable
{
    public class DisplayPrimeTable
    {
        private readonly CreateMultiplicationTable createMultiplicationTable;
        private readonly CreateListofPrimeNumbers createListofPrimeNumbers;

        public DisplayPrimeTable(CreateMultiplicationTable createMultiplicationTable, 
            CreateListofPrimeNumbers createListofPrimeNumbers)
        {
            this.createMultiplicationTable = createMultiplicationTable;
            this.createListofPrimeNumbers = createListofPrimeNumbers;
        }
        public void GeneratePrimeMutliplicationTable(int n)
        {
            List<int> primes = createListofPrimeNumbers.GeListOfPrimeNumbers(n);
            int[,] multiplicationTable = createMultiplicationTable.GetMultiplicationTableForGivenList(primes);

            Console.WriteLine("Prime Multiplication Table:");
            Console.Write("   ");
            for (int i = 0; i < primes.Count; i++)
            {
                Console.Write($" {primes[i],4} ");
            }
            Console.WriteLine();

            for (int i = 0; i < primes.Count; i++)
            {
                Console.Write($"{primes[i],2} |");
                for (int j = 0; j < primes.Count; j++)
                {
                    Console.Write($"{multiplicationTable[i, j],4} |");
                }
                Console.WriteLine();
            }
        }
    }
}
