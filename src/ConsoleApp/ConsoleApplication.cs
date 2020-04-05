using System;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class ConsoleApplication
    {
        /// <summary>
        /// Defines the maximum length of the input array
        /// </summary>
        private const int MAX_LENGTH = 6;

        private readonly ILogger<ConsoleApplication> _logger;
        private readonly IValidateArray _validateArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleApplication`1"/> class.
        /// </summary>
        public ConsoleApplication(ILogger<ConsoleApplication> logger, IValidateArray validateArray)
        {
            _logger = logger;
            _validateArray = validateArray;
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            _logger.LogInformation("ConsoleApplication.Run");

            try
            {
                int[] arr1 = new int[MAX_LENGTH] { 2, 4, 6, 1, 3, 5 };
                int[] arr2 = new int[MAX_LENGTH] { 3, 4, 2, 1, 6, 5 };

                string result = _validateArray.ValidateArrayInput(arr1);
                Console.WriteLine($"Result: {result}");

                result = _validateArray.ValidateArrayInput(arr2);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
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