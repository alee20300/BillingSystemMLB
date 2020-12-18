using Domin.Common;
using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels.Infrastructure.Services
{
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
}
