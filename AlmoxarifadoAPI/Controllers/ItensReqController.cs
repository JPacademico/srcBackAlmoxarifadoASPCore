using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensReqController : ControllerBase
    {
        private readonly ItensReqService _itensReqService;

        public ItensReqController(ItensReqService itensReqService)
        {
            _itensReqService = itensReqService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensReq = _itensReqService.ObterTodosItensReq();
                return Ok(itensReq);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var itemReq = _itensReqService.ObterItenReqPorId(id);
                if (itemReq == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID.");
                }
                return Ok(itemReq);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItenReq(ItensReqPostDTO itemReq)
        {
            try
            {
                var itemSalvo = _itensReqService.CriarItenReq(itemReq);
                return Ok(itemSalvo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o item. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut]
        public IActionResult Put(ItensReqPostDTO itensReqDTO, int idItenReq)
        {
            try
            {
                var itemReq = _itensReqService.AtualizarItenReq(itensReqDTO, idItenReq);
                if (itemReq == null)
                {
                    throw new Exception();
                }
                return Ok(itemReq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int idItenReq)
        {
            try
            {
                _itensReqService.DeletarItenReq(idItenReq);
                return Ok("Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
