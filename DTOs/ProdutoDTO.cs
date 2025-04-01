namespace SupermercadoAPI.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int? CategoriaId { get; set; } // Chave estrangeira para Categoria
        public int? FornecedorId { get; set; } // Chave estrangeira para Fornecedor
        public string CodigoBarras { get; set; }
        public DateTime? DataValidade { get; set; }
    }

    public class ProdutoPorIdDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int? CategoriaId { get; set; } // Chave estrangeira para Categoria
        public int? FornecedorId { get; set; } // Chave estrangeira para Fornecedor
        public string CodigoBarras { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}