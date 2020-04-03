using System;
using ConsoleApp;
using FluentAssertions;
using Xunit;

namespace XUnitTestProject
{
    public class ValiadateArrayTests
    {
        [Fact]
        public void ValidateArrayInput_InvalidArrayLength_Test()
        {
            // Arrange
            IValidateArray validateArray = new ValidateArray();
            int[] arr = new int[1] { 1 };

            // Act
            Action actual = () => validateArray.ValidateArrayInput(arr);

            // Assert
            actual
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Input array must contain 6 elements (Parameter 'arr')");
        }

        [Fact]
        public void ValidateArrayInput_NullInput_Test()
        {
            // Arrange
            IValidateArray validateArray = new ValidateArray();

            // Act
            Action actual = () => validateArray.ValidateArrayInput(null);

            // Assert
            actual
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Input array cannot be null (Parameter 'arr')");
        }

        [Theory]
        [InlineData(new int[6] { 1, 1, 1, 1, 1, 1 }, "false")]
        [InlineData(new int[6] { 2, 4, 6, 1, 3, 5 }, "true")]
        [InlineData(new int[6] { 3, 4, 2, 1, 6, 5 }, "false")]
        public void ValidateInputArray_ValidInputs(int[] arr, string expected)
        {
            // Arrange
            IValidateArray validateArray = new ValidateArray();

            // Act
            var actual = validateArray.ValidateArrayInput(arr);

            // Assert
            actual
                .Should()
                .NotBeNullOrWhiteSpace()
                .And
                .BeEquivalentTo(expected);
        }
    }
}