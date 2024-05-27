using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;

        public NotaFiscalController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notasFiscais = _notaFiscalService.ObterTodasNotas();
                return Ok(notasFiscais);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            try
            {
                var notaFiscalSalva = _notaFiscalService.CriarNotaFiscal(notaFiscal);
                return Ok(notaFiscalSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar a nota fiscal. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/NotaFiscal/{id}")]
        public IActionResult ObterNotaFiscalPorID(int id)
        {
            try
            {
                var notaFiscalSalva = _notaFiscalService.ObterNotaFiscalId(id);
                return Ok(notaFiscalSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar a nota fiscal. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut]
        public IActionResult Put(NotaFiscalPostDTO notaFiscalDTO, int idNota)
        {
            try
            {
                var nota = _notaFiscalService.AtualizarNota(notaFiscalDTO, idNota);
                if (nota == null)
                {
                    throw new Exception();
                }
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int idNota) 
        {
            try
            {
                _notaFiscalService.DeletarNota(idNota);
                return Ok("Sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
