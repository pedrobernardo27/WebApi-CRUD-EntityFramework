using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkRepository.Interfaces
{
    public interface IEnderecoRepository
    {
        ValueTask<Endereco> ObterEnderecoPorIdPessoa(int id);
        ValueTask<Endereco> AtualizarEndereco(Endereco endereco);
    }
}
