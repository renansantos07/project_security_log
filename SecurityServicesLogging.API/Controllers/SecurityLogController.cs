using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecurityServicesLogging.API.DTO;
using SecurityServicesLogging.Business.Interfaces;
using SecurityServicesLogging.Business.Model;
using System.Net;

namespace SecurityServicesLogging.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityLogController : ControllerBase
    {
        private readonly ISecurityLogService _securityLogService;
        
        private readonly IMapper _mapper;

        public SecurityLogController(ISecurityLogService securityLogService, IMapper mapper)
        {
            _securityLogService= securityLogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<SecurityLogDTO>> Get() {

            List<SecurityLog> securityLogs = await _securityLogService.GetAll();

            IEnumerable<SecurityLogDTO> result = _mapper.Map<IEnumerable<SecurityLogDTO>>(securityLogs);

            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetQuery")]
        public async Task<ActionResult<IEnumerable<SecurityLogDTO>>> GetQuery(DateTime initialDate, DateTime endDate, string? message)
        {
            List<SecurityLog> securityLogs = await _securityLogService.GetQuery(initialDate, endDate, message);

            IEnumerable<SecurityLogDTO> result = _mapper.Map<IEnumerable<SecurityLogDTO>>(securityLogs);
            
            if(result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ExtractFileLog")]
        public async Task<ActionResult> ExtractFileLog()
        {
            Response response = await _securityLogService.ExtractFileLog();
            ResponseDTO responseDTO = _mapper.Map<ResponseDTO>(response);

            if(responseDTO.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(responseDTO);
            }
            else
            {
                return Ok(responseDTO);
            }
        }
    }
}
