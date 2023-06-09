﻿using NLog;

namespace EmployeeManagementAPI.LogError
{
    public class LoggerService : ILoggerService
    {
      private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        public void LogError(string message)
        {
         _logger.Error(message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }
    }
}
