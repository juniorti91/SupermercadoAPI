using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly string _connectionString;

        public FuncionarioService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<FuncionarioDTO>> ListarFuncionarios()
        {
            var query = "SELECT * FROM Funcionario";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<FuncionarioDTO>(query);
                return result;
            }
        }

        public async Task<FuncionarioPorIdDTO> ObterFuncionarioPorId(int id)
        {
            var query = "SELECT * FROM Funcionario WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<FuncionarioPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<FuncionarioDTO> CriarFuncionario(FuncionarioDTO funcionario)
        {
            var query = "INSERT INTO Funcionario (Nome, Cargo, Salario) VALUES (@Nome, @Cargo, @Salario)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, funcionario);
                return funcionario;
            }
        }

        public async Task<FuncionarioDTO> AtualizarFuncionario(int id, FuncionarioDTO funcionario)
        {
            var query = "UPDATE Funcionario SET Nome = @Nome, Cargo = @Cargo, Salario = @Salario WHERE Id = @Id";

            funcionario.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, funcionario);
                return funcionario;
            }
        }

        public async Task<bool> DeletarFuncionario(int id)
        {
            var query = "DELETE FROM Funcionario WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
        }
    }
}