using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaRepository(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public Task<IEnumerable<CategoriaDTO>> ListarCategorias()
        {
            return _categoriaService.ListarCategorias();
        }

        public Task<CategoriaPorIdDTO> ObterCategoriaPorId(int id)
        {
            return _categoriaService.ObterCategoriaPorId(id);
        }

        public Task<CategoriaDTO> CriarCategoria(CategoriaDTO categoria)
        {
            return _categoriaService.CriarCategoria(categoria);
        }

        public Task<CategoriaDTO> AtualizarCategoria(int id, CategoriaDTO categoria)
        {
            return _categoriaService.AtualizarCategoria(id, categoria);
        }               

        public Task<bool> DeletarCategoria(int id)
        {
            return _categoriaService.DeletarCategoria(id);
        }
    }
}
