namespace SupermercadoAPI.DTOs
{
    public class ItemCompraDTO
    {
        public int Id { get; set; }
        public string ValorCompra { get; set; } // Join com a tabela Compra
        public string NomeProduto { get; set; } // Join com a tabela Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }

    public class ItemCompraPorIdDTO
    {
        public string ValorCompra { get; set; } // Join com a tabela Compra
        public string NomeProduto { get; set; } // Join com a tabela Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }
}