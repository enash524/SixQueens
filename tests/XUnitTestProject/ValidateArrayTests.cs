using System;
using ConsoleApp;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using XUnitTestProject.Extensions;

namespace XUnitTestProject
{
    public class ValidateArrayTests
    {
        private readonly Mock<ILogger<ValidateArray>> _logger;
        //private readonly ILogger<ValidateArray> _logger;
        private readonly IValidateArray _validateArray;

        public ValidateArrayTests()
        {
            _logger = new Mock<ILogger<ValidateArray>>();
            _validateArray = new ValidateArray(_logger.Object);

            //_logger = new NullLogger<ValidateArray>();
            //_validateArray = new ValidateArray(_logger);

            //ServiceProvider services = new ServiceCollection()
            //    .AddLogging(config => config.AddConsole()) // can add any logger(s)
            //    .BuildServiceProvider();
        }

        [Fact]
        public void ValidateArrayInput_InvalidArrayLength_Test()
        {
            // Arrange
            int[] arr = new int[1] { 1 };

            // Act
            Action actual = () => _validateArray.ValidateArrayInput(arr);

            // Assert
            actual
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Input array must contain 6 elements (Parameter 'arr')");

            //loggerMock.VerifyLog(LogLevel.Error, "Input array must contain 6 elements (Parameter 'arr')", Times.Once());
            //loggerMock.Verify(x => x.LogError("Input array must contain 6 elements (Parameter 'arr')", It.IsAny<Exception>()), Times.Once);
            //_logger.Verify(x => x.LogError("Input array must contain 6 elements (Parameter 'arr')", It.IsAny<Exception>()), Times.Once);
            //_logger.VerifyLog(LogLevel.Error, "Input array must contain 6 elements (Parameter 'arr')");
            //_logger.Verify(x => x.LogError("Input array must contain 6 elements (Parameter 'arr')", It.IsAny<Exception>()), Times.Once());
        }

        [Fact]
        public void ValidateArrayInput_NullInput_Test()
        {
            // Arrange

            // Act
            Action actual = () => _validateArray.ValidateArrayInput(null);

            // Assert
            actual
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Input array cannot be null (Parameter 'arr')");

            //_logger.VerifyLog(LogLevel.Error, "Input array cannot be null (Parameter 'arr')");
        }

        [Theory]
        [InlineData(new int[6] { 1, 1, 1, 1, 1, 1 }, "false")]
        [InlineData(new int[6] { 2, 4, 6, 1, 3, 5 }, "true")]
        [InlineData(new int[6] { 3, 4, 2, 1, 6, 5 }, "false")]
        public void ValidateInputArray_ValidInputs(int[] arr, string expected)
        {
            // Arrange

            // Act
            string actual = _validateArray.ValidateArrayInput(arr);

            // Assert
            actual
                .Should()
                .NotBeNullOrWhiteSpace()
                .And
                .BeEquivalentTo(expected);
        }
    }
}