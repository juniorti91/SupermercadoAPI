using Dapper;
using MySql.Data.MySqlClient;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly string _connectionString;

        public ProdutoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ProdutoDTO>> ListarProdutos()
        {
            var query = @"SELECT 
                            p.*,
                            c.nome AS NomeCategoria, 
                            f.nome AS NomeFornecedor
                            from Produto AS p
                        INNER JOIN categoria c ON p.categoria_id = c.id
                        INNER JOIN fornecedor f ON p.fornecedor_id = f.id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<ProdutoDTO>(query);
                return result;
            }
        }

        public async Task<ProdutoPorIdDTO> ObterProdutoPorId(int id)
        {
            var query = @"SELECT 
                            p.*,
                            c.nome AS NomeCategoria, 
                            f.nome AS NomeFornecedor
                            from Produto AS p
                        INNER JOIN categoria c ON p.categoria_id = c.id
                        INNER JOIN fornecedor f ON p.fornecedor_id = f.id
                        WHERE p.id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<ProdutoPorIdDTO>(query, new { Id = id });
                return result;
            }
        }

        public async Task<ProdutoDTO> CriarProduto(ProdutoDTO produto)
        {
            var query = "INSERT INTO Produto (Nome, Descricao, Preco, QuantidadeEstoque, CategoriaId, FornecedorId, CodigoBarras, DataValidade) VALUES (@Nome, @Descricao, @Preco, @QuantidadeEstoque, @CategoriaId, @FornecedorId, @CodigoBarras, @DataValidade)";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, produto);
                return produto;
            }
        }

        public async Task<ProdutoDTO> AtualizarProduto(int id, ProdutoDTO produto)
        {
            var query = "UPDATE Produto SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, QuantidadeEstoque = @QuantidadeEstoque, CategoriaId = @CategoriaId, FornecedorId = @FornecedorId, CodigoBarras = @CodigoBarras, DataValidade = @DataValidade WHERE Id = @Id";

            produto.Id = id;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, produto);
                return produto;
            }
        }        

        public async Task<bool> DeletarProduto(int id)
        {
            var query = "DELETE FROM Produto WHERE Id = @Id";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result > 0; 
            }
        }        
    }
}