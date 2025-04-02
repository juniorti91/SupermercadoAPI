namespace SupermercadoAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string NomeCategoria { get; set; } // Join com a tabela Categoria
        public string NomeFornecedor { get; set; } // Join com a tabela Fornecedor
        public string CodigoBarras { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}