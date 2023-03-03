using SecurityServicesLogging.Business.Interfaces;
using SecurityServicesLogging.Business.Model;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;

namespace SecurityServicesLogging.Business.Service
{
    public class SecurityLogService : ISecurityLogService
    {

        private readonly ISecurityLogRepository _securityLogRepository;

        public SecurityLogService(ISecurityLogRepository securityLogRepository)
        {
            _securityLogRepository = securityLogRepository;
        }

        public Task<List<SecurityLog>> GetQuery(DateTime initialDate, DateTime endDate, string? message)
        {
            Expression<Func<SecurityLog, bool>> query;

            if (String.IsNullOrEmpty(message))
            {
                query = x => x.Date > initialDate & x.Date < endDate;
            }
            else
            {
                query = x => x.Date > initialDate & x.Date < endDate & x.Message.Contains(message);
            }

            return _securityLogRepository.GetQuery(query);
        }

        public Task<List<SecurityLog>> GetAll()
        {
            return _securityLogRepository.GetAll();
        }

        public async Task<Response> ExtractFileLog()
        {
            try
            {
                List<SecurityLog> securityLogList = new List<SecurityLog>();
                
                using (var sr = new StreamReader("arquivolog.log"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        var arrayLine = line.Split("ip-");

                        DateTime dateTimeLog = ConvertDate(arrayLine[0]);
                        string messageLog = arrayLine[1];

                        SecurityLog securityLog = new SecurityLog()
                        {
                            Date = dateTimeLog,
                            Message = messageLog
                        };

                        securityLogList.Add(securityLog);
                    }

                    List<List<SecurityLog>> securityLogsPartitions = securityLogList.Select((x, i) => new { Index = i, Value = x })
                                                                                    .GroupBy(x => x.Index / 5000)
                                                                                    .Select(x => x.Select(v => v.Value).ToList()).ToList();

                    foreach (List<SecurityLog> securityLogs in securityLogsPartitions)
                    {
                        await _securityLogRepository.InsertRange(securityLogs);
                    }
                }

                Response response = new Response()
                {
                    StatusCode = HttpStatusCode.OK,
                    message = "Arquivo de Log Extraido com sucesso. " + securityLogList.Count.ToString() + " linhas salvas"
                };

                return response;
            }
            catch (IOException e)
            {
                Response response = new Response()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    message = "Estamos com problemas para extrair os dados do arquivo. - " + e.Message
                };

                return response;
            }
        }

        private DateTime ConvertDate(string date)
        {
            string[] dateTime = date.Split(' ').Where(val => val != "").ToArray();
            int month = DateTime.ParseExact(dateTime[0], "MMM", CultureInfo.InvariantCulture).Month;
            int day = int.Parse(dateTime[1].Trim());
            string[] hoursAux = dateTime[2].Split(':');
            int hour = int.Parse(hoursAux[0]);
            int minute = int.Parse(hoursAux[1]);
            int second = int.Parse(hoursAux[2]);

            DateTime returnDate = new DateTime(DateTime.Now.Year, month, day, hour, minute, second);

            return returnDate;
        }

        public void Dispose()
        {
            _securityLogRepository?.Dispose();
        }
    }
}
