using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> ListarCategorias();
        Task<CategoriaPorIdDTO> ObterCategoriaPorId(int id);
        Task<CategoriaCreateDTO> CriarCategoria(CategoriaCreateDTO categoria);
        Task<CategoriaDTO> AtualizarCategoria(int id, CategoriaDTO categoria);
        Task<bool> DeletarCategoria(int id);
    }
}