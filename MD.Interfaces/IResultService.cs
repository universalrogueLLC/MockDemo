namespace MD.Interfaces
{
    public interface IResultService
    {
        void LogResult(string operation, double a, double b, double result);
        void LogException(string message);
    }
}
