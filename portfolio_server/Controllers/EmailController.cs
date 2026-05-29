using Microsoft.AspNetCore.Mvc;
using portfolio_server.Interfaces;
using portfolio_server.Models;

namespace portfolio_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;

        public EmailController(IEmailService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> Send([FromBody] SendEmailDto dto)
        {
            await _service.Send(dto);
            return Ok();
        }
    }
}
