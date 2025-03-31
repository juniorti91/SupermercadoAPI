using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly IItemVendaService _itemVendaService;

        public ItemVendaRepository(IItemVendaService itemVendaService)
        {
            _itemVendaService = itemVendaService;
        }

        public Task<ItemVendaDTO> AtualizarItemVenda(int id, ItemVendaDTO itemVenda)
        {
            return _itemVendaService.AtualizarItemVenda(id, itemVenda);
        }

        public Task<ItemVendaDTO> CriarItemVenda(ItemVendaDTO itemVenda)
        {
            return  _itemVendaService.CriarItemVenda(itemVenda);
        }

        public Task<bool> DeletarItemVenda(int id)
        {
            return _itemVendaService.DeletarItemVenda(id);
        }

        public Task<IEnumerable<ItemVendaDTO>> ListarItensVenda()
        {
            return _itemVendaService.ListarItensVenda();
        }

        public Task<ItemVendaPorIdDTO> ObterItemVendaPorId(int id)
        {
            return _itemVendaService.ObterItemVendaPorId(id);
        }
    }
}