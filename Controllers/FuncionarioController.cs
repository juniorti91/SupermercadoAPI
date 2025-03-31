using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet("ListarFuncionarios")]
        public async Task<IActionResult> ListarFuncionarios()
        {
            var funcionarios = await _funcionarioRepository.ListarFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("ListarFuncionariosPorId")]
        public async Task<IActionResult> ObterFuncionarioPorId(int id)
        {
            var funcionario = await _funcionarioRepository.ObterFuncionarioPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPost("CriarFuncionario")]
        public async Task<IActionResult> CriarFuncionario([FromBody] FuncionarioDTO funcionario)
        {
            var funcionarioCriado = await _funcionarioRepository.CriarFuncionario(funcionario);
            return CreatedAtAction(nameof(ObterFuncionarioPorId), new { id = funcionarioCriado.Id }, funcionarioCriado);
        }

        [HttpPut("AtualizarFuncionario")]
        public async Task<IActionResult> AtualizarFuncionario(int id, [FromBody] FuncionarioDTO funcionario)
        {
            var funcionarioAtualizado = await _funcionarioRepository.AtualizarFuncionario(id, funcionario);

            if (funcionarioAtualizado == null)
            {
                return NotFound();
            }

            return Ok(funcionarioAtualizado);
        }

        [HttpDelete("DeletarFuncionario")]
        public async Task<IActionResult> DeletarFuncionario(int id)
        {
            var funcionarioDeletado = await _funcionarioRepository.DeletarFuncionario(id);

            if (!funcionarioDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}