using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IItemVendaRepository
    {
        Task<IEnumerable<ItemVendaDTO>> ListarItensVenda();
        Task<ItemVendaPorIdDTO> ObterItemVendaPorId(int id);
        Task<ItemVendaDTO> CriarItemVenda(ItemVendaDTO itemVenda);
        Task<ItemVendaDTO> AtualizarItemVenda(int id, ItemVendaDTO itemVenda);
        Task<bool> DeletarItemVenda(int id);
    }
}