using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ListarClientes();
        Task<ClientePorIdDTO> ObterClientePorId(int id);
        Task<ClienteDTO> CriarCliente(ClienteDTO cliente);
        Task<ClienteDTO> AtualizarCliente(int id, ClienteDTO cliente);
        Task<bool> DeletarCliente(int id);
    }
}