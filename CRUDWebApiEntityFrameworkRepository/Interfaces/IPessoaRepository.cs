using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkRepository.Interfaces
{
    public interface IPessoaRepository
    {
        ValueTask<Pessoa> ObterPessoaId(int id);
        ValueTask<IEnumerable<Pessoa>> Listar();
        ValueTask<Pessoa> Deletar(Pessoa pessoa);
        ValueTask<Pessoa> Atualizar(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> ListarCompleto();
        ValueTask<Pessoa> Inserir(Pessoa pessoa);
    }
}
