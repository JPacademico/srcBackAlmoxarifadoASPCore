using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;

        public RequisicaoController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var requisicoes = _requisicaoService.ObterTodasRequisicoes();
                return Ok(requisicoes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/Requisicao/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var requisicao = _requisicaoService.ObterRequisicaoPorId(id);
                if (requisicao == null)
                {
                    return StatusCode(404, "Nenhuma requisição encontrada com este ID.");
                }
                return Ok(requisicao);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            try
            {
                var requisicaoSalva = _requisicaoService.CriarRequisicao(requisicao);
                return Ok(requisicaoSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar a requisição. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut]
        public IActionResult Put(RequisicaoPostDTO requisicaoDTO, int idRequisicao)
        {
            try
            {
                var requisicao = _requisicaoService.AtualizarRequisicao(requisicaoDTO, idRequisicao);
                if (requisicao == null)
                {
                    throw new Exception();
                }
                return Ok(requisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int idRequisicao)
        {
            try
            {
                _requisicaoService.DeletarRequisicao(idRequisicao);
                return Ok("Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
