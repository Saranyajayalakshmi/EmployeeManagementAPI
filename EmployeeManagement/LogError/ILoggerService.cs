namespace EmployeeManagementAPI.LogError
{
    public interface ILoggerService
    {
        void LogError(string message);
        void LogInfo(string message);
    }
}
