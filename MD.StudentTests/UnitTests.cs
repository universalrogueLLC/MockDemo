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
        private double _calculatorOperand1;
        private double _calculatorOperand2;

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
            calculatorMock.Verify(x => x.Add(operand1, operand2), Times.Exactly(1));
            Assert.AreEqual(operand1, this._calculatorOperand1, "unexpected OPERAND1 supplied to calculator");
            Assert.AreEqual(operand2, this._calculatorOperand2, "unexpected OPERAND2 supplied to calculator");

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(1));
            Assert.AreEqual(expectedOperation, this._loggedOperation, "unexpected OPERATION logged");
            Assert.AreEqual(operand1, this._loggedOperand1, "unexpected OPERAND1 logged");
            Assert.AreEqual(operand2, this._loggedOperand2, "unexpected OPERAND2 logged");
            Assert.AreEqual(expectedResult, this._loggedResult, "unexpected RESULT logged");

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
            calculatorMock.Verify(x => x.Subtract(operand1, operand2), Times.Exactly(1));
            Assert.AreEqual(operand1, this._calculatorOperand1, "unexpected OPERAND1 supplied to calculator");
            Assert.AreEqual(operand2, this._calculatorOperand2, "unexpected OPERAND2 supplied to calculator");

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(1));
            Assert.AreEqual(expectedOperation, this._loggedOperation, "unexpected OPERATION logged");
            Assert.AreEqual(operand1, this._loggedOperand1, "unexpected OPERAND1 logged");
            Assert.AreEqual(operand2, this._loggedOperand2, "unexpected OPERAND2 logged");
            Assert.AreEqual(expectedResult, this._loggedResult, "unexpected RESULT logged");

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never);
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
            calculatorMock.Verify(x => x.Multiply(operand1, operand2), Times.Exactly(1));
            Assert.AreEqual(operand1, this._calculatorOperand1, "unexpected OPERAND1 supplied to calculator");
            Assert.AreEqual(operand2, this._calculatorOperand2, "unexpected OPERAND2 supplied to calculator");

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(1));
            Assert.AreEqual(expectedOperation, this._loggedOperation, "unexpected OPERATION logged");
            Assert.AreEqual(operand1, this._loggedOperand1, "unexpected OPERAND1 logged");
            Assert.AreEqual(operand2, this._loggedOperand2, "unexpected OPERAND2 logged");
            Assert.AreEqual(expectedResult, this._loggedResult, "unexpected RESULT logged");

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never);
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
            calculatorMock.Verify(x => x.Divide(operand1, operand2), Times.Exactly(1));
            Assert.AreEqual(operand1, this._calculatorOperand1, "unexpected OPERAND1 supplied to calculator");
            Assert.AreEqual(operand2, this._calculatorOperand2, "unexpected OPERAND2 supplied to calculator");

            // verify that the result was logged correctly, exactly once
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(1));
            Assert.AreEqual(expectedOperation, this._loggedOperation, "unexpected OPERATION logged");
            Assert.AreEqual(operand1, this._loggedOperand1, "unexpected OPERAND1 logged");
            Assert.AreEqual(operand2, this._loggedOperand2, "unexpected OPERAND2 logged");
            Assert.AreEqual(expectedResult, this._loggedResult, "unexpected RESULT logged");

            // verify that no exception was ever logged
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void StudentsShouldDivideCorrectlyWhenDividingByZero()
        {
            var operand1 = 12.0;
            var operand2 = 0.0;

            var calculatorMock = BuildCalculatorMock();
            var resultServiceMock = BuildResultService();
            var student = BuildStudent(calculatorMock.Object, resultServiceMock.Object);

            student.DivideTwoNumbers(operand1, operand2);

            // verify that the correct calculator function was called, with the correct arguments, exactly once
            calculatorMock.Verify(x => x.Divide(operand1, operand2), Times.Exactly(1));
            Assert.AreEqual(operand1, this._calculatorOperand1, "unexpected OPERAND1 supplied to calculator");
            Assert.AreEqual(operand2, this._calculatorOperand2, "unexpected OPERAND2 supplied to calculator");

            // verify that no result was logged
            resultServiceMock.Verify(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Never());

            // verify that the exception was logged, exactly once.
            resultServiceMock.Verify(x => x.LogException(It.IsAny<string>()), Times.Exactly(1));
        }

        private IStudent BuildStudent(ICalculator calculator, IResultService resultService)
        {
            return new GoodStudent(calculator, resultService);
        }

        private Mock<ICalculator> BuildCalculatorMock()
        {
            var mock = new Mock<ICalculator>();

            mock.Setup(x => x.Add(It.IsAny<double>(), It.IsAny<double>()))
                .Callback((double op1, double op2) => { HandleCalculatorCallback(op1, op2); })
                .Returns((double x, double y) => x + y);

            mock.Setup(x => x.Subtract(It.IsAny<double>(), It.IsAny<double>()))
                .Callback((double op1, double op2) => { HandleCalculatorCallback(op1, op2); })
                .Returns((double x, double y) => x - y);

            mock.Setup(x => x.Multiply(It.IsAny<double>(), It.IsAny<double>()))
                .Callback((double op1, double op2) => { HandleCalculatorCallback(op1, op2); })
                .Returns((double x, double y) => x * y);

            mock.Setup(x => x.Divide(It.IsAny<double>(), 0.0))
                .Callback((double op1, double op2) => { HandleCalculatorCallback(op1, op2); })
                .Throws(new DivideByZeroException());
            mock.Setup(x => x.Divide(It.IsAny<double>(), It.IsNotIn<double>(0)))
                .Callback((double op1, double op2) => { HandleCalculatorCallback(op1, op2); })
                .Returns((double x, double y) => x / y);

            return mock;
        }

        private Mock<IResultService> BuildResultService()
        {
            var mock = new Mock<IResultService>();

            mock.Setup(x => x.LogResult(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Callback((string operation, double op1, double op2, double result) => { HandleResultServiceCallback(operation, op1, op2, result); });

            return mock;
        }

        private void HandleCalculatorCallback(double op1, double op2)
        {
            this._calculatorOperand1 = op1;
            this._calculatorOperand2 = op2;
        }

        private void HandleResultServiceCallback(string operation, double op1, double op2, double result)
        {
            this._loggedOperation = operation;
            this._loggedOperand1 = op1;
            this._loggedOperand2 = op2;
            this._loggedResult = result;
        }
    }
}
