using MD.Implementations.Calculators;
using MD.Implementations.ResultServices;
using MD.Implementations.Students;

namespace MD.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new RealCalculator();
            var resultService = new ConsoleResultService();

            var student = new GoodStudent(calculator, resultService);

            student.AddTwoNumbers(12, 34);
            student.SubtractTwoNumbers(12, 34);
            student.MultiplyTwoNumbers(12, 34);
            student.DivideTwoNumbers(12, 34);
            student.DivideTwoNumbers(12, 0);
        }
    }
}
