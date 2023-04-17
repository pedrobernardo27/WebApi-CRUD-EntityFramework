using Microsoft.Extensions.Logging;
using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkService.Interfaces;

namespace CRUDWebApiEntityFrameworkService.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IEmailRepository _emailRepository;

        public EmailService(ILogger<EmailService> logger, IEmailRepository emailRepository)
        {
            _logger = logger;
            _emailRepository = emailRepository;
        }
        public async ValueTask<IEnumerable<EmailListarResponse>> ListarEmail()
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarEmail");

                var lstEmails = new List<EmailListarResponse>();
                var resultEmails = await _emailRepository.Listar();

                if (resultEmails.Count() > 0)
                {
                    foreach (var email in resultEmails)
                    {
                        var novovoEmail = new EmailListarResponse
                        {
                            Id = email.Id,
                            Pessoal = email.Pessoal,
                            Empresarial = email.Empresarial,  
                            Id_Pessoa = email.Id_Pessoa,
                        };

                        lstEmails.Add(novovoEmail);
                    }

                    return lstEmails;
                }

                _logger.LogInformation("Fim do método ListarEmail");

                return lstEmails;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarEmail {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarEmail {ex.Message}");
            }
        }
    }
}