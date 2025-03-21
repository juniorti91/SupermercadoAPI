using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDTO>> ListarClientes();
        Task<ClientePorIdDTO> ObterClientePorId(int id);
        Task<ClienteDTO> CriarCliente(ClienteDTO cliente);
        Task<ClienteDTO> AtualizarCliente(int id, ClienteDTO cliente);
        Task<bool> DeletarCliente(int id);
    }
}