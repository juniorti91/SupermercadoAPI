using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVendaController : ControllerBase
    {
        private readonly IItemVendaService _itemVendaService;

        public ItemVendaController(IItemVendaService itemVendaService)
        {
            _itemVendaService = itemVendaService;
        }

        [HttpGet("ListarItensVenda")]
        public async Task<IActionResult> ListarItensVenda()
        {
            var itensVenda = await _itemVendaService.ListarItensVenda();
            return Ok(itensVenda);
        }

        [HttpGet("ListaItensVendaPorId")]
        public async Task<IActionResult> ListaItensVendaPorId(int id)
        {
            var itemVenda = await _itemVendaService.ObterItemVendaPorId(id);
            return Ok(itemVenda);
        }

        [HttpPost("CriarItemVenda")]
        public async Task<IActionResult> CriarItemVenda(ItemVendaDTO itemVenda)
        {
            var itemVendaCriado = await _itemVendaService.CriarItemVenda(itemVenda);
            return CreatedAtAction(nameof(ListaItensVendaPorId), new { id = itemVendaCriado.Id }, itemVendaCriado);
        }

        [HttpPut("AtualizarItemVenda")]
        public async Task<IActionResult> AtualizarItemVenda(int id, ItemVendaDTO itemVenda)
        {
            var itemVendaAtualizado = await _itemVendaService.AtualizarItemVenda(id, itemVenda);

            if (itemVendaAtualizado == null)
            {
                return NotFound();
            }

            return Ok(itemVendaAtualizado);
        }

        [HttpDelete("DeletarItemVenda")]
        public async Task<IActionResult> DeletarItemVenda(int id)
        {
            var itemVendaDeletado = await _itemVendaService.DeletarItemVenda(id);

            if (!itemVendaDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}