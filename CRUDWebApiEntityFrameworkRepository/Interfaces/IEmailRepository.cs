using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkService.Interfaces
{
    public interface IEmailRepository
    {
        ValueTask<IEnumerable<Email>> Listar();
    }
}
