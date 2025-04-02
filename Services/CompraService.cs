using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class CompraService : ICompraService
    {
        private readonly string _connectionString;

        public CompraService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<CompraDTO>> ListarCompras()
        {
            var query = @"SELECT 
                             c.*,
                             f.nome AS NomeFornecedor 
                          FROM compra c
                          INNER JOIN fornecedor f ON c.fornecedor_id = f.id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<CompraDTO>(query);
                return result;
            }
        }

        public async Task<CompraPorIdDTO> ObterCompraPorId(int id)
        {
            var query = @"SELECT 
                             c.*,
                             f.nome AS NomeFornecedor 
                          FROM compra c
                          INNER JOIN fornecedor f ON c.fornecedor_id = f.id
                          WHERE c.id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<CompraPorIdDTO>(query, new { Id = id });
                return result;
            }
        }        

        public Task<CompraDTO> CriarCompra(CompraDTO compra)
        {
            var query = "INSERT INTO Compra (DataCompra, ValorTotal, FornecedorId) VALUES (@DataCompra, @ValorTotal, @FornecedorId)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(query, compra);
                return Task.FromResult(compra);
            }
        }

        public Task<CompraDTO> AtualizarCompra(int id, CompraDTO compra)
        {
            var query = "UPDATE Compra SET DataCompra = @DataCompra, ValorTotal = @ValorTotal, FornecedorId = @FornecedorId WHERE Id = @Id";

            compra.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(query, compra);
                return Task.FromResult(compra);
            }
        }

        public Task<bool> DeletarCompra(int id)
        {
            var query = "DELETE FROM Compra WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = connection.Execute(query, new { Id = id });
                return Task.FromResult(result > 0);
            }
        }
    }
}