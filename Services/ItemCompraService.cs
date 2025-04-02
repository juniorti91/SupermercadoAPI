using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class ItemCompraService : IItemCompraService
    {
        private readonly string _connectionString;

        public ItemCompraService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ItemCompraDTO>> ListarItensCompra()
        {
            var query = @"SELECT 
                              ic.*, 
                              c.valor_total AS ValorCompra, 
                              p.nome AS NomeProduto 
                              FROM itemcompra AS ic
                          INNER JOIN compra c ON ic.compra_id = c.id
                          INNER JOIN produto p ON ic.produto_id = p.id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<ItemCompraDTO>(query);
                return result;
            }
        }

        public async Task<ItemCompraPorIdDTO> ObterItemCompraPorId(int id)
        {
            var query = @"SELECT 
                              ic.*, 
                              c.valor_total AS ValorCompra, 
                              p.nome AS NomeProduto 
                              FROM itemcompra AS ic
                          INNER JOIN compra c ON ic.compra_id = c.id
                          INNER JOIN produto p ON ic.produto_id = p.id
                          WHERE ic.id = @Id;";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<ItemCompraPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<ItemCompraDTO> CriarItemCompra(ItemCompraDTO itemCompra)
        {
            var query = "INSERT INTO ItemCompra (ProdutoId, CompraId, Quantidade) VALUES (@ProdutoId, @CompraId, @Quantidade)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, itemCompra);
                return itemCompra;
            }
        }

        public async Task<ItemCompraDTO> AtualizarItemCompra(int id, ItemCompraDTO itemCompra)
        {
            var query = "UPDATE ItemCompra SET ProdutoId = @ProdutoId, CompraId = @CompraId, Quantidade = @Quantidade WHERE Id = @Id";

            itemCompra.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, itemCompra);
                return itemCompra;
            }
        }        

        public async Task<bool> DeletarItemCompra(int id)
        {
            var query = "DELETE FROM ItemCompra WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
        }        
    }
}