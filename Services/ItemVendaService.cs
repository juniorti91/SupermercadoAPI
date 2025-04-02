using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly string _connectionString;

        public ItemVendaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ItemVendaDTO>> ListarItensVenda()
        {
            var query = @"SELECT 
                              iv.*, 
                              v.valor_total AS ValorVenda, 
                              p.nome AS NomeProduto
                              from itemvenda AS iv
                          INNER JOIN venda v ON iv.venda_id = v.id
                          INNER JOIN produto p ON iv.produto_id = p.id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<ItemVendaDTO>(query);
                return result;
            }
        }

        public async Task<ItemVendaPorIdDTO> ObterItemVendaPorId(int id)
        {
            var query = @"SELECT 
                              iv.*, 
                              v.valor_total AS ValorVenda, 
                              p.nome AS NomeProduto
                              from itemvenda AS iv
                          INNER JOIN venda v ON iv.venda_id = v.id
                          INNER JOIN produto p ON iv.produto_id = p.id
                          WHERE iv.id = @Id"; 

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<ItemVendaPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<ItemVendaDTO> CriarItemVenda(ItemVendaDTO itemVenda)
        {
            var query = "INSERT INTO ItemVenda (ProdutoId, VendaId, Quantidade) VALUES (@ProdutoId, @VendaId, @Quantidade)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, itemVenda);
                return itemVenda;
            }
        }

        public async Task<ItemVendaDTO> AtualizarItemVenda(int id, ItemVendaDTO itemVenda)
        {
            var query = "UPDATE ItemVenda SET ProdutoId = @ProdutoId, VendaId = @VendaId, Quantidade = @Quantidade WHERE Id = @Id";

            itemVenda.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, itemVenda);
                return itemVenda;
            }
        }

        public async Task<bool> DeletarItemVenda(int id)
        {
            var query = "DELETE FROM ItemVenda WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
        }
    }
}