using App1.Data;
using App1.Infrastructure.Common;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Contracts;
public interface ILogService
{
    Task WriteAsync(LogType type, string source, string action, string message, string description);
    Task WriteAsync(LogType type, string source, string action, Exception ex);
    Task<AppLogModel> GetLogAsync(long id);
    Task<IList<AppLogModel>> GetLogsAsync(DataRequest<AppLog> request);
    Task<IList<AppLogModel>> GetLogsAsync(int skip, int take, DataRequest<AppLog> request);
    Task<int> GetLogsCountAsync(DataRequest<AppLog> request);

    Task<int> DeleteLogAsync(AppLogModel model);
    Task<int> DeleteLogRangeAsync(int index, int length, DataRequest<AppLog> request);

    Task MarkAllAsReadAsync();
}
