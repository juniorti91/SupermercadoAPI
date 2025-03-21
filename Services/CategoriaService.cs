using Dapper;
using MySql.Data.MySqlClient;
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

        public async Task<IEnumerable<CategoriaDTO>> ListarCategorias()
        {
            var query = "SELECT * FROM Categoria";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<CategoriaDTO>(query);
                return result;
            }
        }

        public async Task<CategoriaPorIdDTO> ObterCategoriaPorId(int id)
        {
            var query = "SELECT * FROM Categoria WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<CategoriaPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<CategoriaDTO> CriarCategoria(CategoriaDTO categoria)
        {
            var query = "INSERT INTO Categoria (Nome, Descricao) VALUES (@Nome, @Descricao)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, categoria);
                return categoria;
            }
        }

        public async Task<CategoriaDTO> AtualizarCategoria(int id, CategoriaDTO categoria)
        {
            var query = "UPDATE Categoria SET Nome = @Nome, Descricao = @Descricao WHERE Id = @Id";
            
            categoria.Id = id;
            
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, categoria);
                return categoria;
            }
        }

        public async Task<bool> DeletarCategoria(int id)
        {
            var query = "DELETE FROM Categoria WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
        }
    }
}