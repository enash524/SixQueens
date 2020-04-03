using System;

namespace ConsoleApp
{
    /// <summary>
    /// Starts the console application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the maximum length of the input array
        /// </summary>
        private const int MAX_LENGTH = 6;

        /// <summary>
        /// Main entry point to ConsoleApp
        /// </summary>
        /// <param name="args">Collection of command line arguments. Currently unused.</param>
        private static void Main(string[] args)
        {
            try
            {
                IValidateArray valiadateArray = new ValidateArray();

                int[] arr1 = new int[MAX_LENGTH] { 2, 4, 6, 1, 3, 5 };
                int[] arr2 = new int[MAX_LENGTH] { 3, 4, 2, 1, 6, 5 };

                string result = valiadateArray.ValidateArrayInput(arr1);
                Console.WriteLine($"Result: {result}");

                result = valiadateArray.ValidateArrayInput(arr2);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            finally
            {
                Console.WriteLine("--- Press Any Key To Continue ---");
                Console.ReadKey(true);
            }
        }
    }
}