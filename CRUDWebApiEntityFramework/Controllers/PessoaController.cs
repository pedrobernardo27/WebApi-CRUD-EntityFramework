using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using CRUDWebApiEntityFrameworkRepository.Models;
using CRUDWebApiEntityFrameworkService.Interfaces;

namespace CRUDWebApiEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]

    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("listarPessoa")] 
        public async ValueTask<IActionResult> BuscarPessoa()
        {
            try
            {
                var pessoas = await _pessoaService.ListarPessoas();
                return pessoas.Any() ? Ok(pessoas) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpGet("listarPessoaCompleto")]
        public async Task<IActionResult> ListarPessoa()
        {
            try
            {
                var pessoas = await _pessoaService.ListarPessoasCompleto();
                return pessoas.Any() ? Ok(pessoas) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpPost("criarPessoa")]
        public async ValueTask<IActionResult> CriarPessoa([FromBody] PessoaRequest pessoaRequest)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoaRequest.Nome))
                    return BadRequest();
                if (String.IsNullOrEmpty(pessoaRequest.Sobrenome))
                    return BadRequest();
                if (pessoaRequest.Idade <= 0)
                    return BadRequest();
                if (String.IsNullOrEmpty(pessoaRequest.Cpf))
                    return BadRequest();

                var pessoas = await _pessoaService.InserirPessoa(pessoaRequest);
                return pessoas != null ? Ok($"Pessoa cadastrada com sucesso") : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpPut("atualizarPessoa")]
        public async ValueTask<IActionResult> AtualizarPessoa([FromBody] PessoaAtualizarRequest pessoarRequest)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoarRequest.Nome))
                    return BadRequest();
                if (String.IsNullOrEmpty(pessoarRequest.Sobrenome))
                    return BadRequest();
                if (pessoarRequest.Idade <= 0)
                    return BadRequest();
                if (String.IsNullOrEmpty(pessoarRequest.Cpf))
                    return BadRequest();

                var retorno = await _pessoaService.AlterarPessoa(pessoarRequest);
                return retorno != null ? Ok(retorno) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpDelete("deletarPessoa")]
        public async ValueTask<IActionResult> DeletarPessoa(int id)
        {
            try
            {
                if(id <= 0)
                    return BadRequest();

                var pessoa = await _pessoaService.ExcluirPessoa(id);
                return pessoa != null ? Ok("Pessoa removida com sucesso.") : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }
    }
}
