using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkRepository.Interfaces
{
    public interface IPessoaRepository
    {
        ValueTask<Pessoa> ObterPorId(int id);
        ValueTask<IEnumerable<Pessoa>> Listar();
        ValueTask<Pessoa> Deletar(Pessoa pessoa);
        ValueTask<Pessoa> Inserir(Pessoa pessoa);
        ValueTask<Pessoa> Atualizar(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> ListarCompleto();
    }
}
