using Microsoft.EntityFrameworkCore;
using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkRepository.Context;
using CRUDWebApiEntityFrameworkRepository.Interfaces;

namespace CRUDWebApiEntityFrameworkRepository.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public async ValueTask<Endereco> ObterEnderecoPorIdPessoa(int id)
        {
            var endereco = new Endereco();

            using (var db = new EfExercicioModelContext())
            {
                endereco = await db.Endereco.FirstOrDefaultAsync(x => x.Id_Pessoa == id);
            }

            return endereco;
        }

        public async ValueTask<Endereco> AtualizarEndereco(Endereco endereco)
        {
            try
            {
                using (var db = new EfExercicioModelContext())
                {
                    db.Entry(endereco).State = EntityState.Modified;

                    await db.SaveChangesAsync();
                }

                return endereco;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro.{ex.Message}");
            }

        }
    }
}
