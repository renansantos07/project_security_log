using System.Net;

namespace SecurityServicesLogging.API.DTO
{
    public class ResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string message { get; set; }
    }
}
