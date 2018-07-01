using MD.Interfaces;
using System;

namespace MD.Implementations.Students
{
    public class GoodStudent : IStudent
    {
        private ICalculator _calculator;
        private IResultService _resultService;

        public GoodStudent(ICalculator calculator, IResultService resultService)
        {
            this._calculator = calculator;
            this._resultService = resultService;
        }

        public void AddTwoNumbers(double a, double b)
        {
            var result = this._calculator.Add(a, b);
            this._resultService.LogResult("SUM", a, b, result);
        }

        public void SubtractTwoNumbers(double a, double b)
        {
            var result = this._calculator.Subtract(a, b);
            this._resultService.LogResult("DIFFERENCE", a, b, result);
        }

        public void MultiplyTwoNumbers(double a, double b)
        {
            var result = this._calculator.Multiply(a, b);
            this._resultService.LogResult("PRODUCT", a, b, result);
        }

        public void DivideTwoNumbers(double a, double b)
        {
            try
            {
                var result = this._calculator.Divide(a, b);
                this._resultService.LogResult("DIVISION", a, b, result);
            }
            catch (Exception ex)
            {
                this._resultService.LogException(ex.Message);
            }
        }
    }
}
