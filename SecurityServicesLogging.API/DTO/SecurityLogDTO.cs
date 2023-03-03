using System.ComponentModel.DataAnnotations;

namespace SecurityServicesLogging.API.DTO
{
    public class SecurityLogDTO
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Message { get; set; }
    }
}
