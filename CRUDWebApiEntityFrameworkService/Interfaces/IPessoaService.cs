using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkService.Interfaces
{
    public interface IPessoaService
    {
        ValueTask<Pessoa> ExcluirPessoa(int id);
        ValueTask<Pessoa> InserirPessoa(PessoaRequest pessoaRequest);
        ValueTask<Pessoa> AlterarPessoa(PessoaAtualizarRequest pessoaRequest);
        ValueTask<IEnumerable<PessoaListarResponse>> ListarPessoas();
        Task<IEnumerable<PessoaResponse>> ListarPessoasCompleto();
    }
}
