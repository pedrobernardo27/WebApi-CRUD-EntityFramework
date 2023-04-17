using Microsoft.Extensions.Logging;
using CRUDWebApiEntityFramework.Validação;
using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkService.Interfaces;
using CRUDWebApiEntityFrameworkRepository.Interfaces;

namespace CRUDWebApiEntityFrameworkService.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ILogger<PessoaService> _logger;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(ILogger<PessoaService> logger, CRUDWebApiEntityFrameworkRepository.Interfaces.IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async ValueTask<IEnumerable<PessoaListarResponse>> ListarPessoas()
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarPessoas");

                var lstPessoas = new List<PessoaListarResponse>();
                var resultPessoas = await _pessoaRepository.Listar();

                if (resultPessoas.Count() > 0)
                {
                    foreach (var pessoa in resultPessoas)
                    {
                        var novaPessoa = new PessoaListarResponse
                        {
                            Id = pessoa.Id,
                            Cpf = pessoa.Cpf,
                            Idade = pessoa.Idade,
                            Nome = pessoa.Nome,
                            Sobrenome = pessoa.Sobrenome,
                        };

                        lstPessoas.Add(novaPessoa);
                    }

                    return lstPessoas;
                }

                _logger.LogInformation("Fim do método ListarPessoas");

                return lstPessoas;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarPessoas {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarPessoas {ex.Message}");
            }
        }

        public async Task<IEnumerable<PessoaResponse>> ListarPessoasCompleto()
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarPessoasCompleto");

                var lstPessoas = new List<PessoaResponse>();
                var lstResultPessoas = await _pessoaRepository.ListarCompleto();

                if (lstResultPessoas.Count() > 0)
                {
                    foreach (var pessoa in lstResultPessoas)
                    {
                        var novaPessoa = new PessoaResponse
                        {
                            Id = pessoa.Id,
                            Cpf = pessoa.Cpf,
                            Idade = pessoa.Idade,
                            Nome = pessoa.Nome,
                            Sobrenome = pessoa.Sobrenome,
                            EmailResponse = new List<EmailResponse>()
                        };

                        if (pessoa.Email != null)
                        {
                            foreach (var email in pessoa.Email)
                            {
                                var newEmail = new EmailResponse
                                {
                                    Pessoal = email.Pessoal,
                                    Empresarial = email.Empresarial
                                };

                                novaPessoa.EmailResponse.Add(newEmail);
                            }
                        }

                        lstPessoas.Add(novaPessoa);
                    }

                    return lstPessoas;
                }

                _logger.LogInformation("Fim do método ListarPessoasCompleto");

                return lstPessoas;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarPessoasCompleto {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarPessoasCompleto {ex.Message}");
            }
        }

        public async ValueTask<Pessoa> InserirPessoa(PessoaRequest pessoa)
        {
            try
            {
                _logger.LogInformation("Inicio do método InserirPessoa");

                var cpf = new ValidaCpf();
                var novaPessoa = new Pessoa();
                novaPessoa.Nome = pessoa.Nome;
                novaPessoa.Sobrenome = pessoa.Sobrenome;
                novaPessoa.Idade = pessoa.Idade;
                novaPessoa.Cpf = pessoa.Cpf;
                                
                if (cpf.ValCpf(pessoa.Cpf))
                {
                    var resultPessoa = await _pessoaRepository.Inserir(novaPessoa);

                    if (resultPessoa != null)
                    {
                        novaPessoa = (Pessoa)resultPessoa;
                    }
                }
                else
                {
                    _logger.LogInformation("Cpf Inválido.");
                    throw new Exception("Cpf Inválido.");
                }

                _logger.LogInformation("Fim do método InserirPessoa");

                return novaPessoa;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao afetuar método InserirPessoa. {ex.Message}");
                throw new Exception($"Erro ao afetuar método InserirPessoa. {ex.Message}");
            }
        }
        public async ValueTask<Pessoa> AlterarPessoa(PessoaAtualizarRequest pessoaAtualizarRequest)
        {
            try
            {
                _logger.LogInformation("Inicio do método AlterarPessoa");

                var pessoaResult = new Pessoa();
                var pessoaValidado = await _pessoaRepository.ObterPorId(pessoaAtualizarRequest.Id);

                if (pessoaValidado != null)
                {
                    pessoaValidado.Id = pessoaAtualizarRequest.Id;
                    pessoaValidado.Nome = pessoaAtualizarRequest.Nome;
                    pessoaValidado.Sobrenome = pessoaAtualizarRequest.Sobrenome;
                    pessoaValidado.Idade = pessoaAtualizarRequest.Idade;
                    pessoaValidado.Cpf = pessoaAtualizarRequest.Cpf;

                    var resultPessoa = await _pessoaRepository.Atualizar(pessoaValidado);

                    if (resultPessoa != null)
                    {
                        pessoaResult = resultPessoa;
                    }
                }

                _logger.LogInformation("Fim do método AlterarEndereco");

                return pessoaResult;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar AlterarEndereco. {ex.Message}");
                throw new Exception($"Erro ao efetuar AlterarEndereco. {ex.Message}");
            }
        }

        public async ValueTask<Pessoa> ExcluirPessoa(int id)
        {
            try
            {
                _logger.LogInformation("Inicio do método ExcluirPessoa");

                var pessoaResult = new Pessoa();
                var pessoaValidado = await _pessoaRepository.ObterPorId(id);

                if (pessoaValidado != null)
                {
                    var resultPessoa = await _pessoaRepository.Deletar(pessoaValidado);

                    if (resultPessoa != null)
                    {
                        pessoaResult = resultPessoa;
                    }
                }

                else
                {
                    pessoaResult = pessoaValidado;
                }

                _logger.LogInformation("Fim do método ExcluirPessoa");

                return pessoaResult;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ExcluirPessoa. {ex.Message}");
                throw new Exception($"Erro ao efetuar ExcluirPessoa. {ex.Message}");
            }
        }        
    }
}

