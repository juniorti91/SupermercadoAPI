using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _produtoRepository.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("ListaProdutosPorId")]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost("CriarProduto")]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produto)
        {
            var produtoCriado = await _produtoRepository.CriarProduto(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("AtualizarProduto")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoDTO produto)
        {
            var produtoAtualizado = await _produtoRepository.AtualizarProduto(id, produto);

            if (produtoAtualizado == null)
            {
                return NotFound();
            }

            return Ok(produtoAtualizado);
        }

        [HttpDelete("DeletarProduto")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            var produtoDeletado = await _produtoRepository.DeletarProduto(id);

            if (!produtoDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}