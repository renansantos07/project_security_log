using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServicesLogging.Business.Model
{
    public class SecurityLog : Entity
    {
        public DateTime Date { get; set; }
        public string? Message { get; set; }
    }
}
