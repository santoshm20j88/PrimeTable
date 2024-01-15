using System.Collections.Generic;
using System.Linq;

namespace PrimeTable
{
    public class CreateListofPrimeNumbers
    {
        public List<int> GeListOfPrimeNumbers(int inputN)
        {
            int[] primeNumbers=new int[inputN];
            int count = 0;
            int num = 2;

            while (count < inputN)
            {
                if (IsPrime(num))
                {
                    primeNumbers[count++] = num;
                }
                num++;
            }

            return primeNumbers.ToList();
        }

        public bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
