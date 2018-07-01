using System;
using MD.Implementations.Students;
using MD.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MD.StudentTests
{
    [TestClass]
    public class UnitTests
    {
        private string _loggedOperation;
        private double _loggedOperand1;
        private double _loggedOperand2;
        private double _loggedResult;

        [TestMethod]
        public void StudentsShouldAddCorrectly()
        {
            var operand1 = 12.0;
            var operand2 = 24.0;
            var expectedOperation = "SUM";
            var expectedResult = 36.0;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = BuildStudent(calculatorMock.Object, resultServiceMock.Object);

            student.AddTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Add(operand1, operand2), Times.AtMostOnce());

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(expectedOperation, operand1, operand2, expectedResult), Times.AtMostOnce);
            Assert.AreEqual(expectedOperation, this._loggedOperation);
            Assert.AreEqual(operand1, this._loggedOperand1);
            Assert.AreEqual(operand2, this._loggedOperand2);
            Assert.AreEqual(expectedResult, this._loggedResult);

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void StudentsShouldSubtractCorrectly()
        {
            var operand1 = 12.0;
            var operand2 = 24.0;
            var expectedOperation = "DIFFERENCE";
            var expectedResult = -12.0;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = BuildStudent(calculatorMock.Object, resultServiceMock.Object);

            student.SubtractTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Subtract(operand1, operand2), Times.AtMostOnce());

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(expectedOperation, operand1, operand2, expectedResult), Times.AtMostOnce());

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void StudentsShouldMultiplyCorrectly()
        {
            var operand1 = 12.0;
            var operand2 = 24.0;
            var expectedOperation = "PRODUCT";
            var expectedResult = 288.0;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = BuildStudent(calculatorMock.Object, resultServiceMock.Object);

            student.MultiplyTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Multiply(operand1, operand2), Times.AtMostOnce());

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(expectedOperation, operand1, operand2, expectedResult), Times.AtMostOnce());

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void StudentsShouldDivideCorrectly()
        {
            var operand1 = 12.0;
            var operand2 = 24.0;
            var expectedOperation = "DIVISION";
            var expectedResult = 0.5;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = BuildStudent(calculatorMock.Object, resultServiceMock.Object);

            student.DivideTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Divide(operand1, operand2), Times.AtMostOnce());

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(expectedOperation, operand1, operand2, expectedResult), Times.AtMostOnce());

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void StudentsShouldDivideCorrectlyWhenDividingByZero()
        {
            var operand1 = 12.0;
            var operand2 = 0.0;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = new GoodStudent(calculatorMock.Object, resultServiceMock.Object);

            student.DivideTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Divide(operand1, operand2), Times.AtMostOnce());

            // verify that no result was logged
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Never());

            // verify that the exception was logged, exactly once.
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.AtMostOnce());
        }

        private Mock<ICalculator> BuildCalculatorMock()
        {
            var mock = new Mock<ICalculator>();

            mock.Setup(x => x.Add(It.IsAny<double>(), It.IsAny<double>()))
                .Returns((double x, double y) => x + y);

            mock.Setup(x => x.Subtract(It.IsAny<double>(), It.IsAny<double>()))
                .Returns((double x, double y) => x - y);

            mock.Setup(x => x.Multiply(It.IsAny<double>(), It.IsAny<double>()))
                .Returns((double x, double y) => x * y);

            mock.Setup(x => x.Divide(It.IsAny<double>(), 0.0))
                .Throws(new DivideByZeroException());
            mock.Setup(x => x.Divide(It.IsAny<double>(), It.IsNotIn<double>(0)))
                .Returns((double x, double y) => x / y);

            return mock;
        }

        private Mock<IResultService> BuildResultService()
        {
            var mock = new Mock<IResultService>();

            mock.Setup(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Callback((string operation, double op1, double op2, double result) =>
                {
                    this._loggedOperation = operation;
                    this._loggedOperand1 = op1;
                    this._loggedOperand2 = op2;
                    this._loggedResult = result;
                });

            return mock;
        }

        private IStudent BuildStudent(ICalculator calculator, IResultService resultService)
        {
            return new GoodStudent(calculator, resultService);
        }
    }
}
