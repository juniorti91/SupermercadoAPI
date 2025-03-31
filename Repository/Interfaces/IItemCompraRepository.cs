using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IItemCompraRepository
    {
        Task<IEnumerable<ItemCompraDTO>> ListarItensCompra();
        Task<ItemCompraPorIdDTO> ObterItemCompraPorId(int id);
        Task<ItemCompraDTO> CriarItemCompra(ItemCompraDTO itemCompra);
        Task<ItemCompraDTO> AtualizarItemCompra(int id, ItemCompraDTO itemCompra);
        Task<bool> DeletarItemCompra(int id);
    }
}