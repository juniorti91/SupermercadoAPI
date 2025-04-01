using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IVendaService _vendaService;

        public VendaRepository(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        public Task<VendaDTO> AtualizarVenda(int id, VendaDTO venda)
        {
            return _vendaService.AtualizarVenda(id, venda);
        }

        public Task<VendaDTO> CriarVenda(VendaDTO venda)
        {
            return _vendaService.CriarVenda(venda);
        }

        public Task<bool> DeletarVenda(int id)
        {
            return _vendaService.DeletarVenda(id);
        }

        public Task<IEnumerable<VendaDTO>> ListarVendas()
        {
            return _vendaService.ListarVendas();
        }

        public Task<VendaPorIdDTO> ObterVendaPorId(int id)
        {
            return _vendaService.ObterVendaPorId(id);
        }
    }
}