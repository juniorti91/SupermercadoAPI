using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("ListarClientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _clienteRepository.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("ObterClientePorId")]
        public async Task<IActionResult> ObterClientePorId(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost("CriarCliente")]
        public async Task<IActionResult> CriarCliente([FromBody] ClienteDTO cliente)
        {
            var clienteCriado = await _clienteRepository.CriarCliente(cliente);
            return CreatedAtAction(nameof(ObterClientePorId), new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpPut("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody] ClienteDTO cliente)
        {
            var clienteAtualizado = await _clienteRepository.AtualizarCliente(id, cliente);

            if (clienteAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clienteAtualizado);
        }

        [HttpDelete("DeletarCliente")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            var sucesso = await _clienteRepository.DeletarCliente(id);

            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}