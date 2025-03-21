using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly string _connectionString;

        public ClienteService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ClienteDTO>> ListarClientes()
        {
            var query = "SELECT * FROM Cliente";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<ClienteDTO>(query);
                return result;
            }
        }

        public async Task<ClientePorIdDTO> ObterClientePorId(int id)
        {
            var query = "SELECT * FROM Cliente WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<ClientePorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<ClienteDTO> CriarCliente(ClienteDTO cliente)
        {
            var query = "INSERT INTO Cliente (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, cliente);
                return cliente;
            }
        }

        public async Task<ClienteDTO> AtualizarCliente(int id, ClienteDTO cliente)
        {
            var query = "UPDATE Cliente SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";

            cliente.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, cliente);
                return cliente;
            }
        }        

        public async Task<bool> DeletarCliente(int id)
        {
            var query = "DELETE FROM Cliente WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, new { Id = id });
                return true;
            }
        }        
    }
}