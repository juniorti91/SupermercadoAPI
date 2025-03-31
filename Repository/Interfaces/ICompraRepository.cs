using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraDTO>> ListarCompras();
        Task<CompraPorIdDTO> ObterCompraPorId(int id);
        Task<CompraDTO> CriarCompra(CompraDTO compra);
        Task<CompraDTO> AtualizarCompra(int id, CompraDTO compra);
        Task<bool> DeletarCompra(int id);
    }
}