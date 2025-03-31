using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemCompraController : ControllerBase
    {
        private readonly IItemCompraService _itemCompraService;

        public ItemCompraController(IItemCompraService itemCompraService)
        {
            _itemCompraService = itemCompraService;
        }

        [HttpGet("ListarItensCompra")]
        public async Task<IActionResult> ListarItensCompra()
        {
            var itensCompra = await _itemCompraService.ListarItensCompra();
            return Ok(itensCompra);
        }

        [HttpGet("ListaItensCompraPorId")]
        public async Task<IActionResult> ListaItensCompraPorId(int id)
        {
            var itemCompra = await _itemCompraService.ObterItemCompraPorId(id);

            if (itemCompra == null)
            {
                return NotFound();
            }

            return Ok(itemCompra);
        }

        [HttpPost("CriarItemCompra")]
        public async Task<IActionResult> CriarItemCompra(ItemCompraDTO itemCompra)
        {
            var itemCompraCriado = await _itemCompraService.CriarItemCompra(itemCompra);
            return CreatedAtAction(nameof(ListaItensCompraPorId), new { id = itemCompraCriado.Id }, itemCompraCriado);
        }

        [HttpPut("AtualizarItemCompra")]
        public async Task<IActionResult> AtualizarItemCompra(int id, ItemCompraDTO itemCompra)
        {
            var itemCompraAtualizado = await _itemCompraService.AtualizarItemCompra(id, itemCompra);

            if (itemCompraAtualizado == null)
            {
                return NotFound();
            }

            return Ok(itemCompraAtualizado);
        }

        [HttpDelete("DeletarItemCompra")]
        public async Task<IActionResult> DeletarItemCompra(int id)
        {
            var itemCompraDeletado = await _itemCompraService.DeletarItemCompra(id);

            if (!itemCompraDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}