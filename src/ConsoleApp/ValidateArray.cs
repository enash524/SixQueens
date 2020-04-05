using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    /// <summary>
    /// Contains methods for validating the input array to verify that no two queens are in the same row or diagonal
    /// </summary>
    /// <seealso cref="IValidateArray"/>
    public class ValidateArray : IValidateArray
    {
        /// <summary>
        /// Defines the maximum length of the input array
        /// </summary>
        private const int MAX_LENGTH = 6;

        private readonly ILogger<ValidateArray> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateArray`1"/> class.
        /// </summary>
        /// <param name="logger">DI injected logger</param>
        public ValidateArray(ILogger<ValidateArray> logger)
        {
            _logger = logger;
            _logger.LogInformation("ValidateArray Constructor");
        }

        /// <summary>
        /// Methods for validating the input array to verify that no two queens are in the same row or diagonal
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <returns>Returns true if the input array does not contain two queens in the same row or diagonal, false otherwise</returns>
        public string ValidateArrayInput(int[] arr)
        {
            _logger.LogInformation("Entering ValidateArrayInput");

            if (arr == null)
            {
                _logger.LogError($"Input array cannot be null (Parameter '{nameof(arr)}')");
                throw new ArgumentNullException(nameof(arr), "Input array cannot be null");
            }

            if (arr.Length != MAX_LENGTH)
            {
                _logger.LogError($"Input array must contain 6 elements (Parameter '{nameof(arr)}')");
                throw new ArgumentException("Input array must contain 6 elements", nameof(arr));
            }

            if (arr.Distinct().Count() != MAX_LENGTH)
            {
                return "false";
            }

            for (int i = 0; i < MAX_LENGTH; i++)
            {
                int current = arr[i];

                for (int j = i + 1; j < (MAX_LENGTH - i); j++)
                {
                    int next = arr[i + j];
                    int min = current - j;
                    int max = current + j;

                    if (min >= 1 && next == min)
                    {
                        return "false";
                    }

                    if (max <= MAX_LENGTH && next == max)
                    {
                        return "false";
                    }
                }
            }

            return "true";
        }
    }
}