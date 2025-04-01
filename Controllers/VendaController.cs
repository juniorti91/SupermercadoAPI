using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet("ListarVendas")]
        public async Task<IActionResult> ListarVendas()
        {
            var vendas = await _vendaRepository.ListarVendas();
            return Ok(vendas);
        }

        [HttpGet("ObterVendaPorId/{id}")]
        public async Task<IActionResult> ObterVendaPorId(int id)
        {
            var venda = await _vendaRepository.ObterVendaPorId(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        [HttpPost("CriarVenda")]
        public async Task<IActionResult> CriarVenda([FromBody] VendaDTO venda)
        {
            if (venda == null)
            {
                return BadRequest("Venda não pode ser nula.");
            }

            var novaVenda = await _vendaRepository.CriarVenda(venda);
            return CreatedAtAction(nameof(ObterVendaPorId), new { id = novaVenda.Id }, novaVenda);
        }

        [HttpPut("AtualizarVenda/{id}")]
        public async Task<IActionResult> AtualizarVenda(int id, [FromBody] VendaDTO venda)
        {
            if (venda == null || id != venda.Id)
            {
                return BadRequest("Dados inválidos.");
            }

            var vendaAtualizada = await _vendaRepository.AtualizarVenda(id, venda);
            if (vendaAtualizada == null)
            {
                return NotFound();
            }
            return Ok(vendaAtualizada);
        }

        [HttpDelete("DeletarVenda/{id}")]
        public async Task<IActionResult> DeletarVenda(int id)
        {
            var vendaDeletada = await _vendaRepository.DeletarVenda(id);
            if (!vendaDeletada)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}