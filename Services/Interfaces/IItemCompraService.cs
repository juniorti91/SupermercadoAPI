using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface IItemCompraService
    {
        Task<IEnumerable<ItemCompraDTO>> ListarItensCompra();
        Task<ItemCompraPorIdDTO> ObterItemCompraPorId(int id);
        Task<ItemCompraDTO> CriarItemCompra(ItemCompraDTO itemCompra);
        Task<ItemCompraDTO> AtualizarItemCompra(int id, ItemCompraDTO itemCompra);
        Task<bool> DeletarItemCompra(int id);
    }
}