using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class VendaService : IVendaService
    {
        private readonly string _connectionString;

        public VendaService(IConfiguration configuaration)
        {
            _connectionString = configuaration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<VendaDTO>> ListarVendas()
        {
            var query = "SELECT * FROM Venda";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<VendaDTO>(query);
                return result;
            }
        }

        public async Task<VendaPorIdDTO> ObterVendaPorId(int id)
        {
            var query = "SELECT * FROM Venda WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<VendaPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<VendaDTO> CriarVenda(VendaDTO venda)
        {
            var query = "INSERT INTO Venda (Data_Venda, Valor_Total, Cliente_Id, Funcionario_Id) VALUES (@Data_Venda, @Valor_Total, @Cliente_Id, @Funcionario_Id)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, venda);
                return venda; // Retorna a venda criada
            }
        }

        public async Task<VendaDTO> AtualizarVenda(int id, VendaDTO venda)
        {
            var query = "UPDATE Venda SET Data_Venda = @Data_Venda, Valor_Total = @Valor_Total, Cliente_Id = @Cliente_Id, Funcionario_Id = @Funcionario_Id WHERE Id = @Id";

            venda.Id = id; // Atualiza o ID da venda com o ID fornecido

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, venda);
                return venda; // Retorna a venda atualizada
            }
        }        

        public async Task<bool> DeletarVenda(int id)
        {
            var query = "DELETE FROM Venda WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0; // Retorna true se a venda foi deletada com sucesso
            }
        }

        
    }
}