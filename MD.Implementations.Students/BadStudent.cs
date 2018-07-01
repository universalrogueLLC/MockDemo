using MD.Interfaces;

namespace MD.Implementations.Students
{
    public class BadStudent : IStudent
    {
        private ICalculator _calculator;
        private IResultService _resultService;

        public BadStudent(ICalculator calculator, IResultService resultService)
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
            this._resultService.LogResult("SUM", a, b, result);
        }

        public void MultiplyTwoNumbers(double a, double b)
        {
            var result = this._calculator.Multiply(a, b);
            this._resultService.LogResult("SUM", a, b, result);
        }

        public void DivideTwoNumbers(double a, double b)
        {
            var result = this._calculator.Divide(a, b);
            this._resultService.LogResult("SUM", a, b, result);
        }
    }
}
