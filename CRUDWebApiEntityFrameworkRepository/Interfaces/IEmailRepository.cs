using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkService.Interfaces
{
    public interface IEmailRepository
    {
        ValueTask<IEnumerable<Email>> Listar();
        ValueTask<Email> ObterEmailPorIdPessoa(int id);
        ValueTask<Email> AtualizarEmail(Email email);
    }
}
