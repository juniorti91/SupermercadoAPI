using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet("ListarFornecedores")]
        public async Task<IActionResult> ListarFornecedores()
        {
            var fornecedores = await _fornecedorRepository.ListarFornecedores();
            return Ok(fornecedores);
        }

        [HttpGet("ListaFornecedoresPorId")]
        public async Task<IActionResult> ObterFornecedorPorId(int id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorPorId(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPost("CriarFornecedor")]
        public async Task<IActionResult> CriarFornecedor([FromBody] FornecedorDTO fornecedor)
        {
            var fornecedorCriado = await _fornecedorRepository.CriarFornecedor(fornecedor);
            return CreatedAtAction(nameof(ObterFornecedorPorId), new { id = fornecedorCriado.Id }, fornecedorCriado);
        }

        [HttpPut("AtualizarFornecedor")]
        public async Task<IActionResult> AtualizarFornecedor(int id, [FromBody] FornecedorDTO fornecedor)
        {
            var fornecedorAtualizado = await _fornecedorRepository.AtualizarFornecedor(id, fornecedor);

            if (fornecedorAtualizado == null)
            {
                return NotFound();
            }

            return Ok(fornecedorAtualizado);
        }

        [HttpDelete("DeletarFornecedor")]
        public async Task<IActionResult> DeletarFornecedor(int id)
        {
            var fornecedorDeletado = await _fornecedorRepository.DeletarFornecedor(id);

            if (!fornecedorDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}