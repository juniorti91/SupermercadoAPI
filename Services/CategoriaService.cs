using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly string _connectionString;

        public CategoriaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<List<CategoriaDTO>> ListarCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaPorIdDTO> ObterCategoriaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaCreateDTO> CriarCategoria(CategoriaCreateDTO categoria)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaDTO> AtualizarCategoria(int id, CategoriaDTO categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}