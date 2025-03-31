using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet("ListarCompras")]
        public async Task<IActionResult> ListarCompras()
        {
            var compras = await _compraRepository.ListarCompras();
            return Ok(compras);
        }

        [HttpGet("ListaComprasPorId")]
        public async Task<IActionResult> ObterCompraPorId(int id)
        {
            var compra = await _compraRepository.ObterCompraPorId(id);

            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        [HttpPost("CriarCompra")]
        public async Task<IActionResult> CriarCompra([FromBody] CompraDTO compra)
        {
            var compraCriada = await _compraRepository.CriarCompra(compra);
            return CreatedAtAction(nameof(ObterCompraPorId), new { id = compraCriada.Id }, compraCriada);
        }

        [HttpPut("AtualizarCompra")]
        public async Task<IActionResult> AtualizarCompra(int id, [FromBody] CompraDTO compra)
        {
            var compraAtualizada = await _compraRepository.AtualizarCompra(id, compra);

            if (compraAtualizada == null)
            {
                return NotFound();
            }

            return Ok(compraAtualizada);
        }

        [HttpDelete("DeletarCompra")]
        public async Task<IActionResult> DeletarCompra(int id)
        {
            var compraDeletada = await _compraRepository.DeletarCompra(id);

            if (!compraDeletada)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}