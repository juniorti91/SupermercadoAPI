using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ListarProdutos();
        Task<ProdutoPorIdDTO> ObterProdutoPorId(int id);
        Task<ProdutoDTO> CriarProduto(ProdutoDTO produto);
        Task<ProdutoDTO> AtualizarProduto(int id, ProdutoDTO produto);
        Task<bool> DeletarProduto(int id);
    }
}