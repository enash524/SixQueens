using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace XUnitTestProject.Extensions
{
    public static class MockLoggerExtensions
    {
        public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, LogLevel level, string message, string failMessage = null)
        {
            loggerMock.VerifyLog(level, message, Times.Once(), failMessage);
        }

        public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, LogLevel level, string message, Times times, string failMessage = null)
        {
            loggerMock.Verify(l => l.Log(level, It.IsAny<EventId>(), It.Is<It.IsAnyType>(o => o.ToString() == message), null,
                    It.IsAny<Func<object, Exception, string>>()), times, failMessage);
        }
    }
}