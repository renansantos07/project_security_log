using SecurityServicesLogging.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServicesLogging.Business.Interfaces
{
    public interface ISecurityLogService : IDisposable
    {
        Task<Response> ExtractFileLog();
        Task<List<SecurityLog>> GetQuery(DateTime initialDate, DateTime endDate, string message);
        Task<List<SecurityLog>> GetAll();
    }
}
