using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using CRUDWebApiEntityFrameworkService.Interfaces;

namespace CRUDWebApiEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("listarEmail")]
        public async ValueTask<IActionResult> BuscarEmail()
        {
            try
            {
                var emails = await _emailService.ListarEmail();
                return emails.Any() ? Ok(emails) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }        
    }
}
