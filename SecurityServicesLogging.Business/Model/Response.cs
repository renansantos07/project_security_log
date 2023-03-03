using System.Net;

namespace SecurityServicesLogging.Business.Model
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string message { get; set; }
    }
}
