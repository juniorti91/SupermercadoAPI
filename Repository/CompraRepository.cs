using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ICompraService _compraService;

        public CompraRepository(ICompraService compraService)
        {
            _compraService = compraService;
        }

        public async Task<IEnumerable<CompraDTO>> ListarCompras()
        {
            return await _compraService.ListarCompras();
        }

        public async Task<CompraPorIdDTO> ObterCompraPorId(int id)
        {
            return await _compraService.ObterCompraPorId(id);
        }        

        public async Task<CompraDTO> CriarCompra(CompraDTO compra)
        {
            return await _compraService.CriarCompra(compra);
        }

        public async Task<CompraDTO> AtualizarCompra(int id, CompraDTO compra)
        {
            return await _compraService.AtualizarCompra(id, compra);
        }

        public async Task<bool> DeletarCompra(int id)
        {
            return await _compraService.DeletarCompra(id);
        }
    }
}