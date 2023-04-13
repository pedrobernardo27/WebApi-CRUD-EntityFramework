using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkRepository.Context;
using CRUDWebApiEntityFrameworkRepository.Interfaces;

namespace CRUDWebApiEntityFrameworkRepository.Repository
{
    public class PessoaRepository : IPessoaRepository
    { 
        public async ValueTask<IEnumerable<Pessoa>> Listar()
        {
            try
            {
                var lstPessoa = new List<Pessoa>();

                using (var db = new EfExercicioModelContext())
                {
                    var query = from pes in db.Pessoa                                
                                select new
                                {
                                    Id = pes.Id,
                                    Nome = pes.Nome,
                                    Sobrenome = pes.Sobrenome,
                                    Idade = pes.Idade,
                                    Cpf = pes.Cpf,
                                };

                    lstPessoa = query.ToList().Select(x => new Pessoa
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Sobrenome = x.Sobrenome,
                        Idade = x.Idade,
                        Cpf = x.Cpf,
                    }).ToList();
                }

                return lstPessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro.{ex.Message}");
            }
        }
        public async Task<IEnumerable<Pessoa>> ListarCompleto()
        {
            try
            {
                var lstPessoa = new List<Pessoa>();

                using (var db = new EfExercicioModelContext())
                {
                    var lstPessoaResult = db.Pessoa.ToList();

                    foreach (var pessoa in lstPessoaResult)
                    {
                        var novaPessoa = new Pessoa
                        {
                            Id = pessoa.Id,
                            Cpf = pessoa.Cpf,
                            Idade = pessoa.Idade,
                            Nome = pessoa.Nome,
                            Sobrenome = pessoa.Sobrenome,
                            Email = new List<Email>()
                        };

                        if (pessoa.Email != null)
                        {
                            foreach (var email in pessoa.Email)
                            {
                                var newEmail = new Email
                                {
                                    Id = email.Id,
                                    Id_Pessoa = email.Id_Pessoa,
                                    Pessoal = email.Pessoal,
                                    Empresarial = email.Empresarial
                                };

                                novaPessoa.Email.Add(newEmail);
                            }
                        }

                        lstPessoa.Add(novaPessoa);
                    }
                }

                return lstPessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro.{ex.Message}");
            }
        }

        public async ValueTask<Pessoa> Inserir(Pessoa pessoa)
        {
            using (var db = new EfExercicioModelContext())
            {
                db.Pessoa.Add(pessoa);
                await db.SaveChangesAsync();
            }

            return pessoa;
        }

        public async ValueTask<Pessoa> ObterPorId(int id)
        {
            var pessoa = new Pessoa();

            using (var db = new EfExercicioModelContext())
            {
                pessoa = await db.Pessoa.FindAsync(id);
            }

            return pessoa;
        }

        public async ValueTask<Pessoa> Atualizar(Pessoa pessoa)
        {
            using (var db = new EfExercicioModelContext())
            {
                db.Entry(pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                await db.SaveChangesAsync();
            }

            return pessoa;
        }

        public async ValueTask<Pessoa> Deletar(Pessoa pessoa)
        {
            using (var db = new EfExercicioModelContext())
            {
                db.Entry(pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                await db.SaveChangesAsync();
            }

            return pessoa;
        }
    }
}
