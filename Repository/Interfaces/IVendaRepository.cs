using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IVendaRepository
    {
        Task<IEnumerable<VendaDTO>> ListarVendas();
        Task<VendaPorIdDTO> ObterVendaPorId(int id);
        Task<VendaDTO> CriarVenda(VendaDTO venda);
        Task<VendaDTO> AtualizarVenda(int id, VendaDTO venda);
        Task<bool> DeletarVenda(int id);
    }
}