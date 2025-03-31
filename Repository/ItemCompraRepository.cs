using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class ItemCompraRepository : IItemCompraRepository
    {
        private readonly IItemCompraService _itemCompraService;

        public ItemCompraRepository(IItemCompraService itemCompraService)
        {
            _itemCompraService = itemCompraService;
        }

        public Task<ItemCompraDTO> AtualizarItemCompra(int id, ItemCompraDTO itemCompra)
        {
            return _itemCompraService.AtualizarItemCompra(id, itemCompra);
        }

        public Task<ItemCompraDTO> CriarItemCompra(ItemCompraDTO itemCompra)
        {
            return _itemCompraService.CriarItemCompra(itemCompra);
        }

        public Task<bool> DeletarItemCompra(int id)
        {
            return _itemCompraService.DeletarItemCompra(id);
        }

        public Task<IEnumerable<ItemCompraDTO>> ListarItensCompra()
        {
            return _itemCompraService.ListarItensCompra();
        }

        public Task<ItemCompraPorIdDTO> ObterItemCompraPorId(int id)
        {
            return _itemCompraService.ObterItemCompraPorId(id);
        }
    }
}