using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkService.Interfaces
{
    public interface IEmailService
    {
        ValueTask<IEnumerable<EmailListarResponse>> ListarEmail();
    }
}
