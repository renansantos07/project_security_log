using AutoMapper;
using SecurityServicesLogging.API.DTO;
using SecurityServicesLogging.Business.Model;

namespace SecurityServicesLogging.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Response, ResponseDTO>().ReverseMap();
            CreateMap<SecurityLog, SecurityLogDTO>().ReverseMap();
        }
    }
}
