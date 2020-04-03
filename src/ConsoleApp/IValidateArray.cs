namespace ConsoleApp
{
    /// <summary>
    /// Defines the methods for validating the input array to verify that no two queens are in the same row or diagonal
    /// </summary>
    public interface IValidateArray
    {
        /// <summary>
        /// Methods for validating the input array to verify that no two queens are in the same row or diagonal
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <returns>Returns true if the input array does not contain two queens in the same row or diagonal, false otherwise</returns>
        string ValidateArrayInput(int[] arr);
    }
}