using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly string _connectionString;

        public FornecedorService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<FornecedorDTO>> ListarFornecedores()
        {
            var query = "SELECT * FROM Fornecedor";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<FornecedorDTO>(query);
                return result;
            }
        }

        public async Task<FornecedorPorIdDTO> ObterFornecedorPorId(int id)
        {
            var query = "SELECT * FROM Fornecedor WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<FornecedorPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<FornecedorDTO> CriarFornecedor(FornecedorDTO fornecedor)
        {
            var query = "INSERT INTO Fornecedor (Nome, CNPJ, Endereco, Telefone, Email) VALUES (@Nome, @CNPJ, @Endereco, @Telefone, @Email)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, fornecedor);
                return fornecedor;
            }
        }

        public async Task<FornecedorDTO> AtualizarFornecedor(int id, FornecedorDTO fornecedor)
        {
            var query = "UPDATE Fornecedor SET Nome = @Nome, CNPJ = @CNPJ, Endereco = @Endereco, Telefone = @Telefone, Email = @Email WHERE Id = @Id";
            
            fornecedor.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {                
                await connection.ExecuteAsync(query, fornecedor);
                return fornecedor;
            }
        }        

        public async Task<bool> DeletarFornecedor(int id)
        {
            var query = "DELETE FROM Fornecedor WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
        }
    }
}