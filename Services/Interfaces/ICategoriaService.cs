using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> ListarCategorias();
        Task<CategoriaPorIdDTO> ObterCategoriaPorId(int id);
        Task<CategoriaDTO> CriarCategoria(CategoriaDTO categoria);
        Task<CategoriaDTO> AtualizarCategoria(int id, CategoriaDTO categoria);
        Task<bool> DeletarCategoria(int id);
    }
}