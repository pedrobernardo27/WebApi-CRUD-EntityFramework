using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkRepository.Context;
using CRUDWebApiEntityFrameworkService.Interfaces;

namespace CRUDWebApiEntityFrameworkRepository.Repository
{
    public class EmailRepository : IEmailRepository
    {
        public async ValueTask<IEnumerable<Email>> Listar()
        {
            try
            {
                var lstEmail = new List<Email>();

                using (var db = new EfExercicioModelContext())
                {
                    var query = from ema in db.Email
                                select new
                                {
                                    Id = ema.Id,
                                    Pessoal = ema.Pessoal,
                                    Empresarial = ema.Empresarial,
                                    Id_Pessoa = ema.Id_Pessoa,
                                };

                    lstEmail = query.ToList().Select(x => new Email
                    {
                        Id = x.Id,
                        Pessoal = x.Pessoal,
                        Empresarial = x.Empresarial,
                        Id_Pessoa = x.Id_Pessoa,
                    }).ToList();
                }

                return lstEmail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro.{ex.Message}");
            }
        }
    }
}
