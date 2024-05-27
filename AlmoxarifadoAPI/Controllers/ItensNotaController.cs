using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;

        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var itemNota = _itensNotaService.ObterItensNotaPorId(id);
                if (itemNota == null)
                {
                    return NotFound("Nenhum item de nota encontrado com este ID.");
                }
                return Ok(itemNota);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItenNota(ItensNotaPostDTO itenNota)
        {
            try
            {
                var newItemNota = _itensNotaService.CriarItenNota(itenNota);
                return Ok(newItemNota);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o item de nota. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
