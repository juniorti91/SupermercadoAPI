using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteService _clienteService;

        public ClienteRepository(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }   
        
        public Task<IEnumerable<ClienteDTO>> ListarClientes()
        {
            return _clienteService.ListarClientes();
        }

        public Task<ClientePorIdDTO> ObterClientePorId(int id)
        {
            return _clienteService.ObterClientePorId(id);
        }

        public Task<ClienteDTO> CriarCliente(ClienteDTO cliente)
        {
            return _clienteService.CriarCliente(cliente);
        }

        public Task<ClienteDTO> AtualizarCliente(int id, ClienteDTO cliente)
        {
            return _clienteService.AtualizarCliente(id, cliente);
        }        

        public Task<bool> DeletarCliente(int id)
        {
            return _clienteService.DeletarCliente(id);
        }
    }
}