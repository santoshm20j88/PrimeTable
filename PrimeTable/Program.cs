using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeTable
{
    internal class Program
    {
        public static void Main()
        {
            // Create a DI container
            var serviceProvider = new ServiceCollection()
                .AddTransient<DisplayPrimeTable>() 
                .AddTransient<CreateListofPrimeNumbers>() 
                .AddTransient<CreateMultiplicationTable>()
                .BuildServiceProvider();

            var calculatePrimeValues = serviceProvider.GetRequiredService<DisplayPrimeTable>();

            Console.WriteLine("Enter a whole number (N):");
            bool isInputValid = int.TryParse(Console.ReadLine(), out int inputN);


            if (isInputValid && inputN >= 1)
            {
                calculatePrimeValues.GeneratePrimeMutliplicationTable(inputN);
            }
            else
            {
                Console.WriteLine("Please enter a valid input, a whole number greater than or equal to 1.");
            }
        }
    }
}