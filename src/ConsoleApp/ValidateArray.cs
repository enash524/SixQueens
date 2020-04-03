using System;
using System.Linq;

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

        /// <summary>
        /// Methods for validating the input array to verify that no two queens are in the same row or diagonal
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <returns>Returns true if the input array does not contain two queens in the same row or diagonal, false otherwise</returns>
        public string ValidateArrayInput(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr), "Input array cannot be null");
            }

            if (arr.Length != MAX_LENGTH)
            {
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