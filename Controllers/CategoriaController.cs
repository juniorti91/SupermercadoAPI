using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("ListarCategorias")]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _categoriaRepository.ListarCategorias();
            return Ok(categorias);
        }

        [HttpGet("ListaCategoriasPorId")]
        public async Task<IActionResult> ObterCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepository.ObterCategoriaPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost("CriarCategoria")]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaDTO categoria)
        {
            var categoriaCriada = await _categoriaRepository.CriarCategoria(categoria);
            return CreatedAtAction(nameof(ObterCategoriaPorId), new { id = categoriaCriada.Id }, categoriaCriada);
        }

        [HttpPut("AtualizarCategoria")]
        public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] CategoriaDTO categoria)
        {
            var categoriaAtualizada = await _categoriaRepository.AtualizarCategoria(id, categoria);

            if (categoriaAtualizada == null)
            {
                return NotFound();
            }

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("DeletarCategoria")]
        public async Task<IActionResult> DeletarCategoria(int id)
        {
            var categoriaDeletada = await _categoriaRepository.DeletarCategoria(id);

            if (!categoriaDeletada)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}