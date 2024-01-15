using System.Collections.Generic;

namespace PrimeTable
{
    public class CreateMultiplicationTable
    {
       public int[,] GetMultiplicationTableForGivenList(List<int> primeNumbers)
        {
            int primeNumbersCount = primeNumbers.Count;
            int[,] table = new int[primeNumbersCount, primeNumbersCount];

            for (int i = 0; i < primeNumbersCount; i++)
            {
                for (int j = 0; j < primeNumbersCount; j++)
                {
                    table[i, j] = primeNumbers[i] * primeNumbers[j];
                }
            }

            return table;
        }
    }
}
